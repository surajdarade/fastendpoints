using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.Features.Products.GetProducts {
    public class ProductDto {
        public Guid Id { get; set; }

        public string Name { get; set; } = default!;

        public decimal Price { get; set; }
    }

    public class GetProductsResponse {
        public List<ProductDto> Products { get; set; } = new();
    }
}
