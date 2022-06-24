
using Microsoft.EntityFrameworkCore;
using backendShopApp.Microservices.Interfaces.Repositories;
using backendShopApp.Microservices.Commenting.CommentDomains.Entities;
using backendShopApp.Microservices.Commenting.CommentInfrastructure.Data;

namespace backendShopApp.Microservices.Commenting.CommentInfrastructure.Repositories;

public class RepositoryComment : IRepositoryComment
{

    private readonly CommentContext _dbContext;

    public RepositoryComment(CommentContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Comment>> GetAll()
    {
        try
        {
            var comments = await _dbContext.Comments.ToListAsync();

            return comments;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<Comment> GetById(string id)
    {
        try
        {
            var comment = await _dbContext.Comments.Where(x => x.Id == id).FirstOrDefaultAsync();

            return comment;

        }
        catch (Exception)
        {
            throw;
        }
    }

    public async void Create(Comment obj)
    {
        try
        {
            await _dbContext.Comments.AddAsync(obj);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public void Update(Comment obj)
    {
        try
        {
            _dbContext.Comments.Update(obj);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public void Delete(Comment obj)
    {
        try
        {
            _dbContext.Comments.Remove(obj);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<int> SaveAllChanges()
    {
        try
        {
            return await _dbContext.SaveChangesAsync();
        }
        catch (Exception)
        {
            throw;
        }

    }

}