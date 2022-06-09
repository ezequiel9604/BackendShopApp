using backendShopApp.Models;
using backendShopApp.DataContext;

namespace backendShopApp.Repositories;

public class RepositorySubitems : IRepositorySubitems
{
    private readonly BackendShopAppDbContext _dbContext;

    public RepositorySubitems(BackendShopAppDbContext dbContext)
    {
        _dbContext= dbContext;
    }

    public int Create(SubItem obj)
    {
        try
        {
            _dbContext.SubItems.Add(obj);
            return _dbContext.SaveChanges();

        }
        catch (Exception)
        {
            throw;
        }
    }

    public int Delete(SubItem obj)
    {
        try
        {
            _dbContext.SubItems.Remove(obj);
            return _dbContext.SaveChanges();

        }
        catch (Exception)
        {
            throw;
        }
    }

    public List<SubItem> GetAll()
    {
        try
        {
            var subitems = _dbContext.SubItems.ToList();

            return subitems;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public int Update(SubItem obj)
    {
        try
        {
            _dbContext.SubItems.Update(obj);
            return _dbContext.SaveChanges();

        }
        catch (Exception)
        {
            throw;
        }
    }

    public SubItem GetById(int id)
    {
        try
        {
            var subitem = (from i in _dbContext.SubItems.ToList()
                        where i.Id == id select i).FirstOrDefault();
            
            return subitem;
        }
        catch (Exception)
        {
            throw;
        }
    }

}