using Microsoft.AspNetCore.Mvc;
using test_examen.Models.Dto;
using test_examen.Services;

namespace test_examen.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderController : ControllerBase
{
    private readonly IOrderService _orderService;
    private readonly IProductService _productService;
    private readonly IUserService _userService;
    
    public OrderController(IOrderService orderService, IProductService productService, IUserService userService)
    {
        _orderService = orderService;
        _productService = productService;
        _userService = userService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrder(CreateOrderDto orderDto)
    {
        var order = await _orderService.CreateOrder(orderDto);
        return Ok(order);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllOrders()
    {
        var orders = await _orderService.GetAllOrders();
        return Ok(orders);
    }
}