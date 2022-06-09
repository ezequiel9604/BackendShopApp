using backendShopApp.Models;
using backendShopApp.DataContext;

namespace backendShopApp.Repositories;

public class RepositoryComment : IRepositoryComment
{
    private readonly BackendShopAppDbContext _dbContext;

    public RepositoryComment(BackendShopAppDbContext dbContext)
    {
        _dbContext= dbContext;
    }

    public int Create(Comment obj)
    {
        try
        {
            _dbContext.Comments.Add(obj);
            return _dbContext.SaveChanges();

        }
        catch (Exception)
        {
            throw;
        }
    }

    public int Delete(Comment obj)
    {
        try
        {
            _dbContext.Comments.Remove(obj);
            return _dbContext.SaveChanges();

        }
        catch (Exception)
        {
            throw;
        }
    }

    public List<Comment> GetAll()
    {
        try
        {
            var comments = _dbContext.Comments.ToList();

            return comments;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public int Update(Comment obj)
    {
        try
        {
            _dbContext.Comments.Update(obj);
            return _dbContext.SaveChanges();
        }
        catch (Exception)
        {
            throw;
        }
    }

    public Comment GetById(string id)
    {
        try
        {
            var comment = (from i in _dbContext.Comments.ToList()
                        where i.Id == id select i).FirstOrDefault();
            
            return comment;

        }
        catch (Exception)
        {
            throw;
        }
    }

}