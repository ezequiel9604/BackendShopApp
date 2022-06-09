using backendShopApp.Models;

namespace backendShopApp.Repositories;

public interface IRepositoryState
{
    public List<State> GetAll();

    public State GetById(int id);

    public State GetByName(string name);

}