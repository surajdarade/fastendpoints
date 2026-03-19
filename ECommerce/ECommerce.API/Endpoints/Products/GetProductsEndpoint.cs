using ECommerce.Application.Features.Products.GetProducts;
using FastEndpoints;

namespace ECommerce.API.Endpoints.Products {
    public class GetProductsEndpoint
    : Endpoint<GetProductsRequest, GetProductsResponse> {
        private readonly GetProductsService _service;

        public GetProductsEndpoint(GetProductsService service) {
            _service = service;
        }

        public override void Configure() {
            Get("/products");
            AllowAnonymous();
        }

        public override async Task HandleAsync(
            GetProductsRequest req,
            CancellationToken ct) {
            var result = await _service.Execute(req);
            await HttpContext.Response.WriteAsJsonAsync(result, cancellationToken: ct);
        }
    }
}
