

using backendShopApp.Microservices.Ordering.OrderDomains.Dtos;
namespace backendShopApp.Microservices.Interfaces.Services;

public interface IServiceOrder : IServiceGeneric<OrderDto>
{

    public Task<List<OrderDto>> GetByClientId(string clientId);

}
