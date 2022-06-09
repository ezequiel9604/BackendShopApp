using backendShopApp.Models;
using backendShopApp.DataContext;

namespace backendShopApp.Repositories;

public class RepositoryAppearance : IRepositoryAppearance
{
    private readonly BackendShopAppDbContext _dbContext;

    public RepositoryAppearance(BackendShopAppDbContext dbContext)
    {
        _dbContext= dbContext;
    }

    public List<Appearance> GetAll()
    {
        try
        {
            var appearances = _dbContext.Appearances.ToList();

            return appearances;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public Appearance GetById(int id)
    {
        try
        {
            var appearance= (from i in _dbContext.Appearances.ToList()
                        where i.Id == id select i).FirstOrDefault();
            
            return appearance;

        }
        catch (Exception)
        {
            throw;
        }
    }

    public Appearance GetByName(string name)
    {

        try
        {
            var appearance = (from c in _dbContext.Appearances.ToList()
                            where c.Name == name select c).FirstOrDefault();
            
            return appearance;

        }
        catch (Exception)
        {
            throw;
        }

    }

}