
using backendShopApp.Microservices.Interfaces.Services;
using backendShopApp.Microservices.Ordering.OrderDomains.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace backendShopApp.Microservices.Ordering.OrderApplication.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{

    private readonly IServiceOrder _servOrder;

    public OrderController(IServiceOrder servOrder)
    {
        _servOrder = servOrder;
    }


    [HttpGet("GetAll")]
    public async Task<ActionResult<List<OrderDto>>> GetAll()
    {
        var orders = await _servOrder.GetAll();

        return orders;
    }

    [HttpGet("GetByClientId")]
    public async Task<ActionResult<List<OrderDto>>> GetByClientId(string clientid)
    {
        var ordersByClient = await _servOrder.GetByClientId(clientid);

        return ordersByClient;
    }

}
