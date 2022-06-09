using backendShopApp.Models;
using backendShopApp.DataContext;
using Microsoft.IdentityModel.Tokens;

namespace backendShopApp.Repositories;

public class RepositoryClient : IRepositoryClient
{
    private readonly BackendShopAppDbContext _dbContext;

    public RepositoryClient(BackendShopAppDbContext dbContext)
    {
        _dbContext= dbContext;
    }

    public List<Client> GetAll()
    {
        try
        {
            var clients = _dbContext.Clients.ToList();

            return clients;
        }
        catch (Exception)
        {
            throw;
        }
    }


    public Client GetById(string id)
    {
        try
        {
            var client = (from c in _dbContext.Clients.ToList()
                        where c.Id == id select c).FirstOrDefault();
            
            return client;

        }
        catch (Exception)
        {
            throw;
        }
    }


    public Client GetByEmail(string email)
    {
        try
        {
            var client = (from c in _dbContext.Clients.ToList()
                        where c.Email == email select c).FirstOrDefault();
            
            return client;

        }
        catch (Exception)
        {
            throw;
        }
    }


    public int Delete(Client obj)
    {
        try
        {
            _dbContext.Clients.Remove(obj);
            return _dbContext.SaveChanges();
        }
        catch (Exception)
        {
            throw;
        }
    }


    public int Update(Client obj)
    {
        try
        {
            _dbContext.Clients.Update(obj);
            return _dbContext.SaveChanges();

        }
        catch (Exception)
        {
            throw;
        }
    }


    public int Create(Client obj)
    {
        try
        {
            _dbContext.Clients.Add(obj);
            return _dbContext.SaveChanges();

        }
        catch (Exception)
        {
            throw;
        }
    }


}