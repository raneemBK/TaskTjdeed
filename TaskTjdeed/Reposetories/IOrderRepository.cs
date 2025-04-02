using TaskTjdeed.DTOs;
using TaskTjdeed.Models;

namespace TaskTjdeed.Reposetories
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetOrders();
        Task<Order?> GetOrderById(int id);
        Task<Order?> CreateOrder(OrderDto orderDto);
        Task<bool> UpdateOrder(int orderId, OrderDto orderDto);
    }
}
