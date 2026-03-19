using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.Features.Orders.GetMyOrders {
    public class OrderDto {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsCancelled { get; set; }
    }

    public class GetMyOrdersResponse {
        public List<OrderDto> Orders { get; set; } = new();
    }
}
