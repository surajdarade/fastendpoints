using ECommerce.Application.Features.Reviews.CreateReview;
using FastEndpoints;

namespace ECommerce.API.Endpoints.Reviews {
    public class CreateReviewEndpoint
    : Endpoint<CreateReviewRequest> {
        private readonly CreateReviewService _service;

        public CreateReviewEndpoint(CreateReviewService service) {
            _service = service;
        }

        public override void Configure() {
            Post("/reviews");
            AllowAnonymous();
        }

        public override async Task HandleAsync(
            CreateReviewRequest req,
            CancellationToken ct) {
            await _service.Execute(req);
            await HttpContext.Response.WriteAsJsonAsync(new { Message = "Review added" }, cancellationToken: ct);
        }
    }
}
