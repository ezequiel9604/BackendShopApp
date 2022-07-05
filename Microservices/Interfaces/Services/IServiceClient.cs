
using backendShopApp.Microservices.Clienting.ClientDomains.Dtos;

namespace backendShopApp.Microservices.Interfaces.Services;

public interface IServiceClient : IServiceGeneric<ClientDto>
{
    public Task<object> Login(string email, string password);

    public Task<string> Signup(ClientDto obj);

    public Task<string> Logout(string email);

}
