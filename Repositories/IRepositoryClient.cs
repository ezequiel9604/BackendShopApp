using backendShopApp.Models;

namespace backendShopApp.Repositories;

public interface IRepositoryClient
{
    public List<Client> GetAll();

    public int Create(Client obj);

    public Client GetById(string id);

    public Client GetByEmail(string email);

    public int Delete(Client obj);

    public int Update(Client obj);
}

