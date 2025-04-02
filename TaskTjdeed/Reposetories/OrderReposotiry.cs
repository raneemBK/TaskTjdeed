using Microsoft.EntityFrameworkCore;
using TaskTjdeed.DTOs;
using TaskTjdeed.Models;

namespace TaskTjdeed.Reposetories
{
    public class OrderReposotiry: IOrderRepository
    {
        private readonly TaskTjdeedContext _context;

        public OrderReposotiry(TaskTjdeedContext context)
        {
            _context = context;
        }
        public async Task<List<Order>> GetOrders()
        {
            return await _context.Orders
                .Include(o => o.User)
                .Include(o => o.OrderProducts)
                .ThenInclude(op => op.Product)
                .ToListAsync();
        }

        public async Task<Order?> GetOrderById(int id)
        {
            return await _context.Orders
                .Include(o => o.User)
                .Include(o => o.OrderProducts)
                .ThenInclude(op => op.Product)
                .FirstOrDefaultAsync(o => o.OrderId == id);
        }

        public async Task<Order?> CreateOrder(OrderDto orderDto)
        {
            var user = await _context.Users.FindAsync(orderDto.UserId);
            if (user == null) return null; // User not found

            var order = new Order
            {
                UserId = orderDto.UserId,
                OrderProducts = new List<OrderProduct>()
            };

            decimal totalPrice = 0;

            foreach (var item in orderDto.Products)
            {
                var product = await _context.Products.FindAsync(item.ProductId);
                if (product == null) continue; // Skip invalid products

                order.OrderProducts.Add(new OrderProduct
                {
                    ProductId = item.ProductId,
                    Quantities = item.Quantity
                });

                totalPrice += (product.Price ?? 0) * item.Quantity;
            }

            order.TotalPrice = totalPrice;

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task<bool> UpdateOrder(int orderId, OrderDto orderDto)
        {
            var order = await _context.Orders
                .Include(o => o.OrderProducts)
                .FirstOrDefaultAsync(o => o.OrderId == orderId);

            if (order == null) return false;

            order.OrderProducts.Clear();
            decimal totalPrice = 0;

            foreach (var item in orderDto.Products)
            {
                var product = await _context.Products.FindAsync(item.ProductId);
                if (product == null) continue;

                order.OrderProducts.Add(new OrderProduct
                {
                    ProductId = item.ProductId,
                    Quantities = item.Quantity
                });

                totalPrice += (product.Price ?? 0) * item.Quantity;
            }

            order.TotalPrice = totalPrice;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
