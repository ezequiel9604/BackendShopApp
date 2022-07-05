using backendShopApp.Microservices.Iteming.ItemDomains.Entities;

namespace backendShopApp.Microservices.Interfaces.Repositories;

public interface IRepositoryItem : IRepositoryGeneric<Item>
{
    public Task<Item> GetById(string id);


}