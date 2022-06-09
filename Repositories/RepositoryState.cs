using backendShopApp.Models;
using backendShopApp.DataContext;

namespace backendShopApp.Repositories;

public class RepositoryState : IRepositoryState
{
    private readonly BackendShopAppDbContext _dbContext;

    public RepositoryState(BackendShopAppDbContext dbContext)
    {
        _dbContext= dbContext;
    }

    public List<State> GetAll()
    {
        try
        {
            var states = _dbContext.States.ToList();

            return states;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public State GetById(int id)
    {
        try
        {
            var state= (from i in _dbContext.States.ToList()
                        where i.Id == id select i).FirstOrDefault();
            
            return state;

        }
        catch (Exception)
        {
            throw;
        }
    }

    public State GetByName(string name)
    {

        try
        {
            var state = (from c in _dbContext.States.ToList()
                            where c.Name == name select c).FirstOrDefault();
            
            return state;

        }
        catch (Exception)
        {
            throw;
        }

    }

}