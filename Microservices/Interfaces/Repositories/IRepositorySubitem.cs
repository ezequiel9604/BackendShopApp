using backendShopApp.Microservices.Iteming.ItemDomains.Entities;

namespace backendShopApp.Microservices.Interfaces.Repositories;

public interface IRepositorySubitem : IRepositoryGeneric<SubItem>
{
    public Task<SubItem> GetById(int id);

    public Task<List<SubItem>> GetByItemId(string id);

}
