using backendShopApp.Models;

namespace backendShopApp.Repositories;

public interface IRepositoryItem
{
    public List<Item> GetAll();

    public Item GetById(string id);


    public int Create(Item obj);
    
    public int Delete(Item obj);
    
    public int Update(Item obj);

}