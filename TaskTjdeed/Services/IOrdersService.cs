using TaskTjdeed.DTOs;
using TaskTjdeed.Models;

namespace TaskTjdeed.Services
{
    public interface IOrdersService
    {
        Task<List<Order>> GetOrders();
        Task<Order?> GetOrderById(int id);
        Task<Order?> CreateOrder(OrderDto orderDto);
        Task<bool> UpdateOrder(int orderId, OrderDto orderDto);
    }
}
