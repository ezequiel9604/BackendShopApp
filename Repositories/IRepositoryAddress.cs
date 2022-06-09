using backendShopApp.Models;

namespace backendShopApp.Repositories;

public interface IRepositoryAddress
{
    public List<Address> GetAll();

    public Address GetById(int id);

    public List<Address> GetByClientId(string id);

    public int Create(Address obj);
    
    public int Delete(Address obj);
    
    public int Update(Address obj);

}

