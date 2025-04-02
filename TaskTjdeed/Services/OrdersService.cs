using System;
using TaskTjdeed.DTOs;
using TaskTjdeed.Models;
using Microsoft.EntityFrameworkCore;
using Azure.Core;
using TaskTjdeed.Reposetories;

namespace TaskTjdeed.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly IOrderRepository _context;

        public OrdersService(IOrderRepository context)
        {
            _context = context;
        }

        public async Task<List<Order>> GetOrders()
        {
            return await _context.GetOrders();
        }

        public async Task<Order?> GetOrderById(int id)
        {
            return await _context.GetOrderById(id);
        }

        public async Task<Order?> CreateOrder(OrderDto orderDto)
        {
           return await _context.CreateOrder(orderDto);
        }

        public async Task<bool> UpdateOrder(int orderId, OrderDto orderDto)
        {
            return await _context.UpdateOrder(orderId, orderDto);
        }
    }
}
