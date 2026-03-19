using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Domain.Entities {
    public class Order {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public List<OrderItem> Items { get; set; }
        
        public DateTime CreatedAt { get; set; }

        public bool IsCancelled { get; set; }
    }
}
