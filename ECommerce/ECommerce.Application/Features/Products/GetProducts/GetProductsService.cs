using ECommerce.Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Application.Features.Products.GetProducts {
    public class GetProductsService {
        private readonly IApplicationDbContext _context;

        public GetProductsService(IApplicationDbContext context) {
            _context = context;
        }

        public async Task<GetProductsResponse> Execute(GetProductsRequest request) {
            var products = await _context.Products
                .AsNoTracking()
                .Skip((request.Page - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(p => new ProductDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price
                })
                .ToListAsync();

            return new GetProductsResponse
            {
                Products = products
            };
        }
    }
}
