using AutoMapper;
using backendShopApp.Microservices.Iteming.ItemDomains.Dtos;
using backendShopApp.Microservices.Iteming.ItemDomains.Entities;
using backendShopApp.Microservices.Commenting.CommentDomains.Dtos;
using backendShopApp.Microservices.Commenting.CommentDomains.Entities;

namespace backendShopApp.Microservices.Iteming.ItemApplication.Mapper;

public class ItemProfile : Profile
{
    public ItemProfile()
    {
        // CHECK OUT

        // createMpa<destination, source>
        CreateMap<ItemDto, Item>().ReverseMap()
            .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category.Name))
            .ForMember(dest => dest.Brand, opt => opt.MapFrom(src => src.Brand.Name));

        // createMpa<source, destination>
        CreateMap<ItemDto, Item>()
            .ForMember(dest => dest.Brand, opt => opt.Ignore())
            .ForMember(dest => dest.Category, opt => opt.Ignore());

        // createMpa<destination, source>
        CreateMap<ImageDto, Image>().ReverseMap();

        // createMpa<destination, source>
        CreateMap<SubItemDto, SubItem>().ReverseMap();

        // createMpa<destination, source>
        CreateMap<CommentDto, Comment>().ReverseMap();

    }
}