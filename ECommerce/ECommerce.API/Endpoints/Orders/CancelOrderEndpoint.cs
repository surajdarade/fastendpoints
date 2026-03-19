using ECommerce.Application.Features.Orders.CancelOrder;
using FastEndpoints;

namespace ECommerce.API.Endpoints.Orders {
    public class CancelOrderEndpoint
    : Endpoint<CancelOrderRequest> {
        private readonly CancelOrderService _service;

        public CancelOrderEndpoint(CancelOrderService service) {
            _service = service;
        }

        public override void Configure() {
            Delete("/orders/{OrderId}");
            AllowAnonymous();
        }

        public override async Task HandleAsync(
            CancelOrderRequest req,
            CancellationToken ct) {
            await _service.Execute(req);
            await HttpContext.Response.WriteAsJsonAsync(new { Message = "Order cancelled" }, cancellationToken: ct);
        }
    }
}
