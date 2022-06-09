using backendShopApp.Models;

namespace backendShopApp.Services;

public interface IServiceClient
{

    public object Login(string email, string password);

    public string Signup(ClientDto clientdto);

    public string Create(ClientDto clientdto);

    public string Delete(string email, string password);

    public string Logout(string email);

    public List<ClientDto> GetAll();

    public string Update(ClientDto clientdto);

}