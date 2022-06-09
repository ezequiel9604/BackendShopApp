using backendShopApp.Models;

namespace backendShopApp.Repositories;

public interface IRepositoryCategory
{
    public List<Category> GetAll();

    public Category GetById(int id);

    public Category GetByName(string name);

    public int Create(Category obj);
    
    public int Delete(Category obj);
    
    public int Update(Category obj);

}