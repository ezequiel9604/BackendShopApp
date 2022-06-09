using backendShopApp.Models;

namespace backendShopApp.Repositories;

public interface IRepositorySubitems
{
    public List<SubItem> GetAll();

    public SubItem GetById(int id);

    public int Create(SubItem obj);
    
    public int Delete(SubItem obj);
    
    public int Update(SubItem obj);

}