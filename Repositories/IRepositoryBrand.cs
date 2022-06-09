using backendShopApp.Models;

namespace backendShopApp.Repositories;

public interface IRepositoryBrand
{
    public List<Brand> GetAll();

    public Brand GetById(int id);

    public Brand GetByName(string name);

    public int Create(Brand obj);
    
    public int Delete(Brand obj);
    
    public int Update(Brand obj);

}

