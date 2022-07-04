
using AutoMapper;
using backendShopApp.Microservices.Ordering.OrderDomains.Dtos;
using backendShopApp.Microservices.Ordering.OrderDomains.Entities;

namespace backendShopApp.Microservices.Ordering.OrderApplication.Mapper;

public class OrderProfile : Profile
{

    public OrderProfile()
    {

        // createMpa<source, destination>
        CreateMap<OrderDto, Order>();

        // createMpa<destination, source>
        CreateMap<OrderDto, Order>().ReverseMap();


        // createMpa<source, destination>
        CreateMap<PurchaseDto, Order>();

        // createMpa<destination, source>
        CreateMap<PurchaseDto, Order>().ReverseMap();

    }

}