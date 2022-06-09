using backendShopApp.Models;
using backendShopApp.DataContext;

namespace backendShopApp.Repositories;

public class RepositoryCurrancy : IRepositoryCurrancy
{
    private readonly BackendShopAppDbContext _dbContext;

    public RepositoryCurrancy(BackendShopAppDbContext dbContext)
    {
        _dbContext= dbContext;
    }

    public List<Currancy> GetAll()
    {
        try
        {
            var currancies = _dbContext.Currancies.ToList();

            return currancies;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public Currancy GetById(int id)
    {
        try
        {
            var currancy= (from i in _dbContext.Currancies.ToList()
                            where i.Id == id select i).FirstOrDefault();
            
            return currancy;

        }
        catch (Exception)
        {
            throw;
        }
    }

    public Currancy GetByName(string name)
    {

        try
        {
            var currancy = (from c in _dbContext.Currancies.ToList()
                            where c.Name == name select c).FirstOrDefault();
            
            return currancy;

        }
        catch (Exception)
        {
            throw;
        }

    }

}