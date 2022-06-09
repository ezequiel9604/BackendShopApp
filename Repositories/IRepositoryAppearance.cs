using backendShopApp.Models;

namespace backendShopApp.Repositories;

public interface IRepositoryAppearance
{
    public List<Appearance> GetAll();

    public Appearance GetById(int id);

    public Appearance GetByName(string name);


}