using Microsoft.EntityFrameworkCore;
using test_examen.Models;
using test_examen.Models.Dto;

namespace test_examen.Services;

public class OrderService : IOrderService
{
    private readonly AppDbContext _context;
    private readonly IUserService _userService;
    private readonly IProductService _productService;
    
    public OrderService(IUserService userService, IProductService productService, AppDbContext context)
    {
        _userService = userService;
        _productService = productService;
        _context = context;
    }
    
    public async Task<Order?> GetOrder(Guid id)
    {
        var order = await _context.Orders.FindAsync(id);
        return order;
    }
    
    public async Task<IEnumerable<Order>> GetAllOrders()
    {
        var orders = await _context.Orders.Include(o => o.User).Include(o => o.Products).ToListAsync();
        return orders;
    }
    
    public async Task<IEnumerable<Order>> GetAllOrdersByUser(Guid userId)
    {
        var user = await _userService.GetUser(userId);
        if (user == null)
        {
            throw new Exception("User not found!");
        }
        var orders = await _context.Orders.Include(o => o.User).Where(o => o.User.Id == userId).ToListAsync();
        return orders;
    }
    
    public async Task<Order> CreateOrder(CreateOrderDto createOrderDto)
    {
        var user = await _userService.GetUser(createOrderDto.UserId);
        if (user == null)
        {
            throw new Exception("User not found!");
        }
        var products = new List<Product>();
        foreach (var productId in createOrderDto.ProductIds)
        {
            var product = await _productService.GetProduct(productId);
            if (product == null)
            {
                throw new Exception("Product not found!");
            }
            products.Add(product);
        }
        var order = new Order
        {
            User = user,
            OrderDate = DateTime.Now,
            Products = products
        };
        await _context.Orders.AddAsync(order);
        await _context.SaveChangesAsync();
        return order;
    }

    public async Task DeleteOrder(Guid id)
    {
        var order = await GetOrder(id);
        if (order == null)
        {
            throw new Exception("Order not found!");
        }
        _context.Orders.Remove(order);
        await _context.SaveChangesAsync();
    }
}