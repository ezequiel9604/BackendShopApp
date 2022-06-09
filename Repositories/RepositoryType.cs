using backendShopApp.Models;
using backendShopApp.DataContext;

namespace backendShopApp.Repositories;

public class RepositoryType : IRepositoryType
{
    private readonly BackendShopAppDbContext _dbContext;

    public RepositoryType(BackendShopAppDbContext dbContext)
    {
        _dbContext= dbContext;
    }

    public List<backendShopApp.Models.Type> GetAll()
    {
        try
        {
            var types = _dbContext.Types.ToList();

            return types;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public backendShopApp.Models.Type GetById(int id)
    {
        try
        {
            var type= (from i in _dbContext.Types.ToList()
                        where i.Id == id select i).FirstOrDefault();
            
            return type;

        }
        catch (Exception)
        {
            throw;
        }
    }

    public backendShopApp.Models.Type GetByName(string name)
    {

        try
        {
            var type = (from c in _dbContext.Types.ToList()
                            where c.Name == name select c).FirstOrDefault();
            
            return type;

        }
        catch (Exception)
        {
            throw;
        }

    }

}