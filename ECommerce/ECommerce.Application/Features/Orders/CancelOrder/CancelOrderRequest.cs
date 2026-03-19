using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.Features.Orders.CancelOrder {
    public class CancelOrderRequest {
        public Guid OrderId { get; set; }
        public Guid UserId { get; set; }
    }
}
