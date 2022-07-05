

namespace backendShopApp.Microservices.Interfaces.Services;

public interface IServiceGeneric<T>
{
    public Task<List<T>> GetAll();

    public Task<string> Create(T obj);

    public Task<string> Update(T obj);

    public Task<string> Delete(string obj);

}