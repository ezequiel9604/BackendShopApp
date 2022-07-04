
using AutoMapper;
using backendShopApp.Microservices.Interfaces.Services;
using backendShopApp.Microservices.Interfaces.Repositories;
using backendShopApp.Microservices.Ordering.OrderDomains.Dtos;

namespace backendShopApp.Microservices.Ordering.OrderApplication.Services;

public class ServiceOrder : IServiceOrder
{

    private readonly IMapper _mapper;
    private readonly IRepositoryOrder _repoOrder;

    public ServiceOrder(IMapper mapper, IRepositoryOrder repoOrder)
    {
        _mapper = mapper;
        _repoOrder = repoOrder;
    }

    public async Task<List<OrderDto>> GetAll()
    {

        try
        {
            var orders = await _repoOrder.GetAll();

            if (orders is null)
                return new List<OrderDto>();

            var orderDtos = new List<OrderDto>();

            foreach (var order in orders)
            {
                var odto = _mapper.Map<OrderDto>(order);
                odto.PurchaseDtos = _mapper.Map<List<PurchaseDto>>(order.Purchases).ToArray();

                orderDtos.Add(odto);
            }

            return orderDtos;

        }
        catch (Exception)
        {
            return new List<OrderDto>();
        }

    }

    public async Task<List<OrderDto>> GetByClientId(string clientId)
    {
        try
        {
            var orders = await _repoOrder.GetAll();

            if (orders is null)
                return new List<OrderDto>();

            var orderDtos = new List<OrderDto>();

            foreach (var order in orders)
            {
                if(order.ClientId == clientId)
                {
                    var odto = _mapper.Map<OrderDto>(order);
                    odto.PurchaseDtos = _mapper.Map<List<PurchaseDto>>(order.Purchases).ToArray();

                    orderDtos.Add(odto);
                }
            }

            return orderDtos;

        }
        catch (Exception)
        {
            return new List<OrderDto>();
        }
    }

    Task<string> IServiceGeneric<OrderDto>.Create(OrderDto obj)
    {
        throw new NotImplementedException();
    }

    Task<string> IServiceGeneric<OrderDto>.Delete(string obj)
    {
        throw new NotImplementedException();
    }

    Task<string> IServiceGeneric<OrderDto>.Update(OrderDto obj)
    {
        throw new NotImplementedException();
    }
}

