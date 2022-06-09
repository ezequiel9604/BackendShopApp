using backendShopApp.Models;
using backendShopApp.DataContext;

namespace backendShopApp.Repositories;

public class RepositoryLanguage : IRepositoryLanguage
{
    private readonly BackendShopAppDbContext _dbContext;

    public RepositoryLanguage(BackendShopAppDbContext dbContext)
    {
        _dbContext= dbContext;
    }

    public List<Language> GetAll()
    {
        try
        {
            var languages = _dbContext.Languages.ToList();

            return languages;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public Language GetById(int id)
    {
        try
        {
            var language= (from i in _dbContext.Languages.ToList()
                        where i.Id == id select i).FirstOrDefault();
            
            return language;

        }
        catch (Exception)
        {
            throw;
        }
    }

    public Language GetByName(string name)
    {

        try
        {
            var language = (from c in _dbContext.Languages.ToList()
                            where c.Name == name select c).FirstOrDefault();
            
            return language;

        }
        catch (Exception)
        {
            throw;
        }

    }

}