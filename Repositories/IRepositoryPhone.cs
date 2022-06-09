using backendShopApp.Models;

namespace backendShopApp.Repositories;

public interface IRepositoryPhone
{
    public List<Phone> GetAll();

    public Phone GetById(int id);

    public List<Phone> GetByClientId(string id);

    public int Create(Phone obj);
    
    public int Delete(Phone obj);
    
    public int Update(Phone obj);

}