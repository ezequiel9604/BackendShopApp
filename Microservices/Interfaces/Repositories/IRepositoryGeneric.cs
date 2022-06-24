
namespace backendShopApp.Microservices.Interfaces.Repositories;

public interface IRepositoryGeneric<T>
{
    public Task<List<T>> GetAll();

    public void Create(T obj);

    public void Delete(T obj);

    public void Update(T obj);

    public Task<int> SaveAllChanges();
}
