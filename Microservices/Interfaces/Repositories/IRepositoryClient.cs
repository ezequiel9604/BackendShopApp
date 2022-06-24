

using backendShopApp.Microservices.Clienting.ClientDomains.Entities;

namespace backendShopApp.Microservices.Interfaces.Repositories;

public interface IRepositoryClient : IRepositoryGeneric<Client>
{

    public Task<Client> GetById(string id);

    public Task<Client> GetByEmail(string email);

}
