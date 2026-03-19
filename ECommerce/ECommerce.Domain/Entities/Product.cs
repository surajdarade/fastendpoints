using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Domain.Entities {
    public class Product {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }


        public List<Review> Reviews { get; set; }

    }
}
