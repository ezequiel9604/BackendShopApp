
using backendShopApp.Microservices.Commenting.CommentDomains.Entities;

namespace backendShopApp.Microservices.Interfaces.Repositories;

public interface IRepositoryComment : IRepositoryGeneric<Comment>
{
    public Task<Comment> GetById(string id);
}

