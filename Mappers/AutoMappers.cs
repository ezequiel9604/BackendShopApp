using AutoMapper;
using backendShopApp.Models;

namespace backendShopApp.Mappers;

public class AutoMappers : Profile
{
    public AutoMappers()
    {
        CreateMap<ClientDto, Client>().ReverseMap()
            .ForMember(dest => dest.DayOfBirth, opt => opt.MapFrom(src => src.DateOfBirth.Day))
            .ForMember(dest => dest.MonthOfBirth, opt => opt.MapFrom(src => src.DateOfBirth.Month))
            .ForMember(dest => dest.YearOfBirth, opt => opt.MapFrom(src => src.DateOfBirth.Year));
    
        CreateMap<ClientDto, Client>()
            .ForMember(dest => dest.DateOfBirth, opt => opt.Ignore())
            .ForMember(dest => dest.Appearance, opt => opt.Ignore())
            .ForMember(dest => dest.Currancy, opt => opt.Ignore())
            .ForMember(dest => dest.Type, opt => opt.Ignore())
            .ForMember(dest => dest.State, opt => opt.Ignore())
            .ForMember(dest => dest.Comment, opt => opt.Ignore())
            .ForMember(dest => dest.Language, opt => opt.Ignore());

        CreateMap<AddressDto, Address>().ReverseMap();
        CreateMap<PhoneDto, Phone>().ReverseMap();
        CreateMap<ImageDto, Image>().ReverseMap();
        
        CreateMap<ItemDto, Item>().ReverseMap();
        CreateMap<ItemDto, Item>()
            .ForMember(dest => dest.Brand, opt => opt.Ignore())
            .ForMember(dest => dest.Category, opt => opt.Ignore())
            .ForMember(dest => dest.Comment, opt => opt.Ignore());

        CreateMap<SubItemDto, SubItem>().ReverseMap();

        CreateMap<CommentDto, Comment>().ReverseMap();

    }
}