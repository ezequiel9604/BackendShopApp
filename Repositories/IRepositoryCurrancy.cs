using backendShopApp.Models;

namespace backendShopApp.Repositories;

public interface IRepositoryCurrancy
{
    public List<Currancy> GetAll();

    public Currancy GetById(int id);

    public Currancy GetByName(string name);


}