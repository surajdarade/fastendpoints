using ECommerce.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.Features.Orders.CancelOrder {
    public class CancelOrderService {
        private readonly IApplicationDbContext _context;

        public CancelOrderService(IApplicationDbContext context) {
            _context = context;
        }

        public async Task Execute(CancelOrderRequest request) {
            var order = await _context.Orders.FindAsync(request.OrderId);

            if (order == null || order.UserId != request.UserId)
                throw new Exception("Order not found");

            order.IsCancelled = true;

            await _context.SaveChangesAsync(CancellationToken.None);
        }
    }
}
