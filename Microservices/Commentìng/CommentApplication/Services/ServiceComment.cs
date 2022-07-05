
using AutoMapper;
using backendShopApp.Microservices.Commenting.CommentDomains.Dtos;
using backendShopApp.Microservices.Commenting.CommentDomains.Entities;
using backendShopApp.Microservices.Interfaces.Repositories;
using backendShopApp.Microservices.Interfaces.Services;

namespace backendShopApp.Microservices.Commenting.CommentApplications.Services;

public class ServiceComment : IServiceComment
{

    private readonly IMapper _mapper;
    private readonly IRepositoryComment _repoComment;

    public ServiceComment(IMapper mapper, IRepositoryComment repoComment)
    {
        _mapper = mapper;
        _repoComment = repoComment;
    }

    public async Task<List<CommentDto>> GetAll()
    {
        try
        {
            var comments = await _repoComment.GetAll();

            if(comments is null)
                return new List<CommentDto>();

            var commentdtos = _mapper.Map<List<CommentDto>>(comments);

            return commentdtos;

        }
        catch (Exception)
        {
            return new List<CommentDto>();
        }
    }

    public async Task<List<CommentDto>> GetCommentsByItemId(string itemid)
    {
        try
        {
            var comments = await _repoComment.GetAll();

            if (comments is null)
                return new List<CommentDto>();

            var commentdtos = new List<CommentDto>();
            foreach (var comment in comments)
            {
                if(comment.ItemId == itemid)
                {
                    commentdtos.Add(_mapper.Map<CommentDto>(comment));
                }
            }

            return commentdtos;

        }
        catch (Exception)
        {
            return new List<CommentDto>();
        }

    }

    public async Task<string> Create(CommentDto commentdto)
    {
        
        if(string.IsNullOrEmpty(commentdto.Text) || string.IsNullOrEmpty(commentdto.ClientId) ||
            string.IsNullOrEmpty(commentdto.ItemId))
        {
            return "No empty allow!";
        }

        try
        {
            // creating an id to new comment
            var randomId = "CMT-" + new Random().Next(1000, 9999);
            while (true)
            {
                if (await _repoComment.GetById(randomId) is null)
                    break;

                randomId = "CMT-" + new Random().Next(1000, 9999);
            }

            var comment = _mapper.Map<Comment>(commentdto);
            comment.Id = randomId;
            comment.Date = DateTime.Now;
            comment.State = "visible";

            _repoComment.Create(comment);

            int affectedRows = await _repoComment.SaveAllChanges();

            if (affectedRows > 0)
                return "Success!";

            return "No action!";

        }
        catch (Exception)
        {
            return "Database error!";
        }

    }

    Task<string> IServiceGeneric<CommentDto>.Update(CommentDto obj)
    {
        throw new NotImplementedException();
    }

    Task<string> IServiceGeneric<CommentDto>.Delete(string obj)
    {
        throw new NotImplementedException();
    }

    
}