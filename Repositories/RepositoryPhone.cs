using backendShopApp.Models;
using backendShopApp.DataContext;

namespace backendShopApp.Repositories;

public class RepositoryPhone : IRepositoryPhone
{

    private readonly BackendShopAppDbContext _dbContext;

    public RepositoryPhone(BackendShopAppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Phone GetById(int id)
    {
        try
        {
            var phone = (from a in _dbContext.Phones.ToList()
                        where a.Id == id select a).FirstOrDefault();
            
            return phone;

        }
        catch (Exception)
        {
            throw;
        }
    }

    public int Create(Phone obj)
    {
        try
        {
            _dbContext.Phones.Add(obj);
            return _dbContext.SaveChanges();

        }
        catch (Exception)
        {
            throw;
        }
    }

    public int Delete(Phone obj)
    {
        try
        {
            _dbContext.Phones.Remove(obj);
            return _dbContext.SaveChanges();

        }
        catch (Exception)
        {
            throw;
        }
    }

    public List<Phone> GetAll()
    {
        try
        {
            var phones = _dbContext.Phones.ToList();
            return phones;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public int Update(Phone obj)
    {
        try
        {
            _dbContext.Phones.Update(obj);
            return _dbContext.SaveChanges();

        }
        catch (Exception)
        {
            throw;
        }
    }

    public List<Phone> GetByClientId(string id)
    {
        try
        {
            var phones = (from p in _dbContext.Phones.ToList()
                            where p.ClientId == id select p).ToList();
            return phones;
        }
        catch (Exception)
        {
            throw;
        }
    }

}