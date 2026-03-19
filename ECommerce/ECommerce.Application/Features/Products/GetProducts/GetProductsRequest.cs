using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.Features.Products.GetProducts {
    public class GetProductsRequest {
        public int Page { get; set; } = 1;

        public int PageSize { get; set; } = 10;
    }
}
