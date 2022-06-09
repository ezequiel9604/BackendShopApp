using backendShopApp.Models;
using backendShopApp.DataContext;

namespace backendShopApp.Repositories;

public class RepositoryAddress : IRepositoryAddress
{

    private readonly BackendShopAppDbContext _dbContext;

    public RepositoryAddress(BackendShopAppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Address GetById(int id)
    {
        try
        {
            var address = (from a in _dbContext.Addresses.ToList()
                        where a.Id == id select a).FirstOrDefault();
            
            return address;

        }
        catch (Exception)
        {
            throw;
        }
    }

    public List<Address> GetAll()
    {
        try
        {
            var address = _dbContext.Addresses.ToList();
            
            return address;

        }
        catch (Exception)
        {
            throw;
        }
    }

    public List<Address> GetByClientId(string id)
    {
        try
        {
            var address = (from a in _dbContext.Addresses.ToList()
                            where a.ClientId == id select a).ToList();
            
            return address;

        }
        catch (Exception)
        {
            throw;
        }
    }

    public int Create(Address obj)
    {
        try
        {
            _dbContext.Addresses.Add(obj);
            return _dbContext.SaveChanges();

        }
        catch (Exception)
        {
            throw;
        }
    }

    public int Delete(Address obj)
    {
        try
        {
            _dbContext.Addresses.Remove(obj);
            return _dbContext.SaveChanges();

        }
        catch (Exception)
        {
            throw;
        }
    }

    public int Update(Address obj)
    {
        try
        {
            _dbContext.Addresses.Update(obj);
            return _dbContext.SaveChanges();
        }
        catch (Exception)
        {
            throw;
        }
    }
}