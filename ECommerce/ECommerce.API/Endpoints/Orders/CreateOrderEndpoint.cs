using ECommerce.Application.Features.Orders.CreateOrder;
using FastEndpoints;

namespace ECommerce.API.Endpoints.Orders {
    public class CreateOrderEndpoint
    : Endpoint<CreateOrderRequest, CreateOrderResponse> {
        private readonly CreateOrderService _service;

        public CreateOrderEndpoint(CreateOrderService service) {
            _service = service;
        }

        public override void Configure() {
            Post("/orders");
            AllowAnonymous();
        }

        public override async Task HandleAsync(
            CreateOrderRequest req,
            CancellationToken ct) {
            var result = await _service.Execute(req);
            await HttpContext.Response.WriteAsJsonAsync(result, cancellationToken: ct);
        }
    }
}
