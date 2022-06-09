using backendShopApp.Models;

namespace backendShopApp.Repositories;

public interface IRepositoryComment
{
    public List<Comment> GetAll();

    public Comment GetById(string id);


    public int Create(Comment obj);
    
    public int Delete(Comment obj);
    
    public int Update(Comment obj);

}