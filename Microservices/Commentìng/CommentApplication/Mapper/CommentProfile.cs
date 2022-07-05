
using AutoMapper;
using backendShopApp.Microservices.Commenting.CommentDomains.Dtos;
using backendShopApp.Microservices.Commenting.CommentDomains.Entities;

namespace backendShopApp.Microservices.Commenting.CommentApplications.Mapper;

public class CommentProfile : Profile
{

    public CommentProfile()
    {

        // createMap<source, destination>
        CreateMap<CommentDto, Comment>();

        // createMap<destination, source>
        CreateMap<CommentDto, Comment>().ReverseMap();

    }

}