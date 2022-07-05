
using AutoMapper;
using backendShopApp.Microservices.Clienting.ClientDomains.Dtos;
using backendShopApp.Microservices.Clienting.ClientDomains.Entities;

namespace backendShopApp.Microservices.Clienting.ClientApplication.Mapper;

public class ClientProfile : Profile
{
    public ClientProfile()
    {
        // CHECK OUT

        // createMpa<destination, source>
        CreateMap<ClientDto, Client>().ReverseMap()
            .ForMember(dest => dest.Appearance, opt => opt.MapFrom(src => src.Appearance.Name))
            .ForMember(dest => dest.Currancy, opt => opt.MapFrom(src => src.Currancy.Name))
            .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type.Name))
            .ForMember(dest => dest.State, opt => opt.MapFrom(src => src.State.Name))
            .ForMember(dest => dest.Language, opt => opt.MapFrom(src => src.Language.Name))
            .ForMember(dest => dest.DayOfBirth, opt => opt.MapFrom(src => src.DateOfBirth.Day))
            .ForMember(dest => dest.MonthOfBirth, opt => opt.MapFrom(src => src.DateOfBirth.Month))
            .ForMember(dest => dest.YearOfBirth, opt => opt.MapFrom(src => src.DateOfBirth.Year));

        // createMpa<source, destination>
        CreateMap<ClientDto, Client>()
            .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(
                src => new DateTime(src.YearOfBirth, src.MonthOfBirth, src.DayOfBirth)))
            .ForMember(dest => dest.Currancy, opt => opt.Ignore())
            .ForMember(dest => dest.Type, opt => opt.Ignore())
            .ForMember(dest => dest.State, opt => opt.Ignore())
            .ForMember(dest => dest.Language, opt => opt.Ignore());

        // createMpa<destination, source>
        CreateMap<AddressDto, Address>().ReverseMap();

        // createMpa<destination, source>
        CreateMap<PhoneDto, Phone>().ReverseMap();

    }
}
