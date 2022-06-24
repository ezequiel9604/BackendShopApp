using backendShopApp.Microservices.Clienting.ClientDomains.Entities;

namespace backendShopApp.Microservices.Interfaces.Repositories;

public interface IRepositoryAddress : IRepositoryGeneric<Address>
{
    public Task<Address> GetById(int id);

    public Task<List<Address>> GetByClientId(string id);

}
