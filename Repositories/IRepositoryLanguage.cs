using backendShopApp.Models;

namespace backendShopApp.Repositories;

public interface IRepositoryLanguage
{
    public List<Language> GetAll();

    public Language GetById(int id);

    public Language GetByName(string name);


}