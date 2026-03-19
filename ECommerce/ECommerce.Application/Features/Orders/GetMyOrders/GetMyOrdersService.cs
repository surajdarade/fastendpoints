using ECommerce.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.Features.Orders.GetMyOrders {
    public class GetMyOrdersService {
        private readonly IApplicationDbContext _context;

        public GetMyOrdersService(IApplicationDbContext context) {
            _context = context;
        }

        public async Task<GetMyOrdersResponse> Execute(GetMyOrdersRequest request) {
            var orders = await _context.Orders
                .AsNoTracking()
                .Where(o => o.UserId == request.UserId)
                .Select(o => new OrderDto
                {
                    Id = o.Id,
                    CreatedAt = o.CreatedAt,
                    IsCancelled = o.IsCancelled
                })
                .ToListAsync();

            return new GetMyOrdersResponse
            {
                Orders = orders
            };
        }
    }
}
