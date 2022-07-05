
using backendShopApp.Microservices.Commenting.CommentDomains.Dtos;

namespace backendShopApp.Microservices.Interfaces.Services;

public interface IServiceComment : IServiceGeneric<CommentDto>
{

    public Task<List<CommentDto>> GetCommentsByItemId(string id);

}
