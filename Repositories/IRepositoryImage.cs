using backendShopApp.Models;

namespace backendShopApp.Repositories;

public interface IRepositoryImage
{
    public List<Image> GetAll();

    public Image GetById(int id);


    public int Create(Image obj);
    
    public int Delete(Image obj);
    
    public int Update(Image obj);

}