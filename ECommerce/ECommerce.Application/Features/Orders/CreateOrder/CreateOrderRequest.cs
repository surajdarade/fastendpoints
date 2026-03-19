using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.Features.Orders.CreateOrder {
    public class CreateOrderRequest {
        public Guid UserId { get; set; }

        public List<OrderItemDto> Items { get; set; } = new();
    }

    public class OrderItemDto {
        public Guid ProductId { get; set; }

        public int Quantity { get; set; }
    }
}
