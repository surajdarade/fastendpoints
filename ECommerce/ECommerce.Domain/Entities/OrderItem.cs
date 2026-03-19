using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Domain.Entities {
    public class OrderItem {
        public Guid Id { get; set; }

        public Guid ProductId { get; set; } 

        public Product Product { get; set; }

        public int Quantity { get; set; }

        public Guid OrderId { get; set; }
    }
}
