using backendShopApp.Models;
using backendShopApp.DataContext;

namespace backendShopApp.Repositories;

public class RepositoryCategory : IRepositoryCategory
{
    private readonly BackendShopAppDbContext _dbContext;

    public RepositoryCategory(BackendShopAppDbContext dbContext)
    {
        _dbContext= dbContext;
    }

    public int Create(Category obj)
    {
        try
        {
            _dbContext.Categories.Add(obj);
            return _dbContext.SaveChanges();

        }
        catch (Exception)
        {
            throw;
        }
    }

    public int Delete(Category obj)
    {
        try
        {
            _dbContext.Categories.Remove(obj);
            return _dbContext.SaveChanges();

        }
        catch (Exception)
        {
            throw;
        }
    }

    public List<Category> GetAll()
    {
        try
        {
            var categories = _dbContext.Categories.ToList();

            return categories;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public int Update(Category obj)
    {
        try
        {
            _dbContext.Categories.Update(obj);
            return _dbContext.SaveChanges();

        }
        catch (Exception)
        {
            throw;
        }
    }

    public Category GetById(int id)
    {
        try
        {
            var category = (from i in _dbContext.Categories.ToList()
                        where i.Id == id select i).FirstOrDefault();
            
            return category;

        }
        catch (Exception)
        {
            throw;
        }
    }

    public Category GetByName(string name)
    {

        try
        {
            var category = (from c in _dbContext.Categories.ToList()
                            where c.Name == name select c).FirstOrDefault();
            
            return category;

        }
        catch (Exception)
        {
            throw;
        }

    }

}