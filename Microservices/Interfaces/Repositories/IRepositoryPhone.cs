using backendShopApp.Microservices.Clienting.ClientDomains.Entities;

namespace backendShopApp.Microservices.Interfaces.Repositories;

public interface IRepositoryPhone : IRepositoryGeneric<Phone>
{
    public Task<Phone> GetById(int id);

    public Task<List<Phone>> GetByClientId(string id);

}
