using test_examen.Models;
using test_examen.Models.Dto;

namespace test_examen.Services;

public interface IOrderService
{
    public Task<IEnumerable<Order>> GetAllOrdersByUser(Guid userId);
    public Task<IEnumerable<Order>> GetAllOrders();
    public Task<Order?> GetOrder(Guid id);
    public Task<Order> CreateOrder(CreateOrderDto createOrderDto);
    public Task DeleteOrder(Guid id);
}