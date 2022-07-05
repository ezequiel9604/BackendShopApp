using backendShopApp.Microservices.Iteming.ItemDomains.Entities;

namespace backendShopApp.Microservices.Interfaces.Repositories;

public interface IRepositoryImage : IRepositoryGeneric<Image>
{
    public Task<Image> GetById(int id);

    public Task<List<Image>> GetByItemId(string id);

}
