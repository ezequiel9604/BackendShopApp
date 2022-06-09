using Microsoft.AspNetCore.Mvc;
using backendShopApp.Models;
using backendShopApp.Services;
using Microsoft.AspNetCore.Authorization;

namespace backendShopApp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ItemController : ControllerBase
{
    private readonly IServiceItem _serviceItem;

    public ItemController(IServiceItem serviceItem)
    {
        _serviceItem= serviceItem;
    }

    // DONE
    [AllowAnonymous]
    [HttpGet("GetAll")]
    public ActionResult<List<ItemDto>> GetAll()
    {
        var clientDtos = _serviceItem.GetAll();

        return clientDtos;
    }

    // DONE
    //[Authorize(Roles= "Admin")]
    [HttpPost("Create")]
    public IActionResult Create(ItemDto req)
    {
        var result = _serviceItem.Create(req);

        if(result == "No empty allow!")
            return BadRequest("Error: There are empty values, No empty values allow!");
        else if(result == "Database error!")
            return BadRequest("Error: Request to database failed!");
        else if(result == "No inserted!")
            return BadRequest("Error: client not inserted!");

        return Ok(result);
    }

    // DONE
    //[Authorize(Roles= "Admin")]
    [HttpPut("Edit")]
    public IActionResult Update(ItemDto req)
    {
        var result = _serviceItem.Update(req);

        if(result == "No exist!")
            return BadRequest("Error: Client does not exist!");
        else if(result == "Database error!")
            return BadRequest("Error: Request to database failed!");

        return Ok(result);
    }
    
    // DONE
    //[Authorize(Roles= "Admin")]
    [HttpPost("Remove")]
    public IActionResult Remove(ItemDto req)
    {
        var result = _serviceItem.Delete(req.Id);

        if(result == "No empty allow!")
            return BadRequest("Error: There are empty values, No empty values allow!");
        else if(result == "Database error!")
            return BadRequest("Error: Request to database failed!");
        else if(result == "No inserted!")
            return BadRequest("Error: client not inserted!");

        return Ok(result);
    }

}