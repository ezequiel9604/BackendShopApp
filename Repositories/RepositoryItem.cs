using backendShopApp.Models;
using backendShopApp.DataContext;

namespace backendShopApp.Repositories;

public class RepositoryItem : IRepositoryItem
{
    private readonly BackendShopAppDbContext _dbContext;

    public RepositoryItem(BackendShopAppDbContext dbContext)
    {
        _dbContext= dbContext;
    }

    public int Create(Item obj)
    {
        try
        {
            _dbContext.Items.Add(obj);
            return _dbContext.SaveChanges();

        }
        catch (Exception)
        {
            throw;
        }
    }

    public int Delete(Item obj)
    {
        try
        {
            _dbContext.Items.Remove(obj);
            return _dbContext.SaveChanges();

        }
        catch (Exception)
        {
            throw;
        }
    }

    public List<Item> GetAll()
    {
        try
        {
            var items = _dbContext.Items.ToList();

            if(items is not null)
                return items;
            else
                return null;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public int Update(Item obj)
    {
        try
        {
            _dbContext.Items.Update(obj);
            return _dbContext.SaveChanges();

        }
        catch (Exception)
        {
            throw;
        }
    }

    public Item GetById(string id)
    {
        try
        {
            var item = (from i in _dbContext.Items.ToList()
                        where i.Id == id select i).FirstOrDefault();
            
            if(item is not null)
                return item;
            else
                return null;

        }
        catch (Exception)
        {
            throw;
        }
    }

}