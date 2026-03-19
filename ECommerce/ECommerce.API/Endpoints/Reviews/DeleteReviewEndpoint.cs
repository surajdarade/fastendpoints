using ECommerce.Application.Features.Reviews.DeleteReview;
using FastEndpoints;

namespace ECommerce.API.Endpoints.Reviews {
    public class DeleteReviewEndpoint
    : Endpoint<DeleteReviewRequest> {
        private readonly DeleteReviewService _service;

        public DeleteReviewEndpoint(DeleteReviewService service) {
            _service = service;
        }

        public override void Configure() {
            Delete("/reviews/{ReviewId}");
            AllowAnonymous();
        }

        public override async Task HandleAsync(
            DeleteReviewRequest req,
            CancellationToken ct) {
            await _service.Execute(req);
            await HttpContext.Response.WriteAsJsonAsync(new { Message = "Review deleted" }, cancellationToken: ct);
        }
    }
}
