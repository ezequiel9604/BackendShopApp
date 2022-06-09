using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using backendShopApp.Models;
using backendShopApp.Services;

namespace backendShopApp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClientController : ControllerBase
{
    private readonly IServiceClient _serviceClient;

    public ClientController(IServiceClient serviceClient)
    {
        _serviceClient= serviceClient;
    }

    // DONE
    [AllowAnonymous]
    [HttpPost("Signup")]
    public IActionResult Signup(ClientDto req)
    {

        var result = _serviceClient.Signup(req);

        if(result == "No empty allow!")
            return BadRequest("Error: There are empty values, No empty values allow!");
        else if(result == "Database error!")
            return BadRequest("Error: Request to database failed!");
        else if(result == "Already exist!")
            return BadRequest("Error: Email already exists!");
        else if(result == "No inserted!")
            return BadRequest("Error: client not inserted!");

        return Ok(result);

    }

    // DONE
    //[Authorize(Roles= "Admin")]
    [HttpPost("Create")]
    public IActionResult Create(ClientDto req)
    {

        var result = _serviceClient.Create(req);

        if(result == "No empty allow!")
            return BadRequest("Error: There are empty values, No empty values allow!");
        else if(result == "Database error!")
            return BadRequest("Error: Request to database failed!");
        else if(result == "Already exist!")
            return BadRequest("Error: Email already exists!");
        else if(result == "No inserted!")
            return BadRequest("Error: client not inserted!");

        return Ok(result);
    }

    // DONE
    [AllowAnonymous]
    [HttpPost("Login")]
    public IActionResult Login(ClientDto req)
    {
        var result = _serviceClient.Login(req.Email, req.Password); 

        if(Convert.ToString(result) == "No empty allow!")
            return BadRequest("Error: There are empty values, No empty values allow!");
        else if(Convert.ToString(result) == "No exist!")
            return BadRequest("Error: Email does not exist!");
        else if(Convert.ToString(result) == "No password!")
            return BadRequest("Error: Password is incorrect!");
        else if(Convert.ToString(result) == "Database error!")
            return BadRequest("Error: Request to database failed!");
        else if(Convert.ToString(result) == "No inserted!")
            return BadRequest("Error: client not inserted!");
        
        // returns an object with token and client.
        return Ok(result);
    }

    //[Authorize(Roles = "Client")]
    [HttpPost("Logout")]
    public IActionResult Logout(ClientDto req)
    {
        var result = _serviceClient.Logout(req.Email);

         if(result == "No empty allow!")
            return BadRequest("Error: There are empty values, No empty values allow!");
        else if(result == "No exist!")
            return BadRequest("Error: Email does not exist!");
        else if(result == "Database error!")
            return BadRequest("Error: Request to database failed!");
        
        return Ok(result);

    }

    // DONE
    //[Authorize(Roles = "Client")]
    [HttpPost("Signout")]
    public IActionResult Signout(ClientDto req)
    {
        var result = _serviceClient.Delete(req.Email, req.Password);

         if(result == "No empty allow!")
            return BadRequest("Error: There are empty values, No empty values allow!");
        else if(result == "No exist!")
            return BadRequest("Error: Email does not exist!");
        else if(result == "No password!")
            return BadRequest("Error: Password is incorrect!");
        else if(result == "Database error!")
            return BadRequest("Error: Request to database failed!");
        else if(result == "No inserted!")
            return BadRequest("Error: client not inserted!");
        
        return Ok(result);
    }

    // DONE
    //[Authorize(Roles = "Admin")]
    [HttpGet("GetAll")]
    public ActionResult<List<ClientDto>> GetAll()
    {
        var clientDtos = _serviceClient.GetAll();

        return clientDtos;
    }

    //[Authorize(Roles = "Client, Admin")]
    [HttpPut("Edit")]
    public IActionResult EditClient(ClientDto req)
    {
        
        var result = _serviceClient.Update(req);

        if(result == "No exist!")
            return BadRequest("Error: Client does not exist!");
        else if(result == "Database error!")
            return BadRequest("Error: Request to database failed!");

        return Ok("client updated!");
    }


}