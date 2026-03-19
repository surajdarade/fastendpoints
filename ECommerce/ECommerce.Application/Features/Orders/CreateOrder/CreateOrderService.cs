using ECommerce.Application.Interfaces;
using ECommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.Features.Orders.CreateOrder {
    public class CreateOrderService {
        private readonly IApplicationDbContext _context;

        public CreateOrderService(IApplicationDbContext context) {
            _context = context;
        }

        public async Task<CreateOrderResponse> Execute(CreateOrderRequest request) {
            var order = new Order
            {
                Id = Guid.NewGuid(),
                UserId = request.UserId,
                CreatedAt = DateTime.UtcNow,
                Items = request.Items.Select(i => new OrderItem
                {
                    Id = Guid.NewGuid(),
                    ProductId = i.ProductId,
                    Quantity = i.Quantity
                }).ToList()
            };

            _context.Orders.Add(order);
            await _context.SaveChangesAsync(CancellationToken.None);

            return new CreateOrderResponse
            {
                OrderId = order.Id
            };
        }
    }
}
