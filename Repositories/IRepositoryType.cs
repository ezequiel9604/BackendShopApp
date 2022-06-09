using backendShopApp.Models;

namespace backendShopApp.Repositories;

public interface IRepositoryType
{
    public List<backendShopApp.Models.Type> GetAll();

    public backendShopApp.Models.Type GetById(int id);

    public backendShopApp.Models.Type GetByName(string name);


}