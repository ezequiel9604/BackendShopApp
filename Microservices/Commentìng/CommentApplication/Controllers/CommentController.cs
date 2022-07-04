
using backendShopApp.Microservices.Commenting.CommentDomains.Dtos;
using backendShopApp.Microservices.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace backendShopApp.Microservices.Commenting.CommentApplications.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CommentController : ControllerBase
{

    private readonly IServiceComment _servComment;

    public CommentController(IServiceComment servComment)
    {
        _servComment = servComment;
    }

    [HttpGet("GetAll")]
    public async Task<ActionResult<List<CommentDto>>> GetAll()
    {
        return await _servComment.GetAll();
    }

    [HttpGet("GetByItemId")]
    public async Task<ActionResult<List<CommentDto>>> GetByItemId(string id)
    {
        return await _servComment.GetCommentsByItemId(id);
    }

}