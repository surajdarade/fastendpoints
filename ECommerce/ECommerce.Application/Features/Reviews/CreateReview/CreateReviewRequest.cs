using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.Features.Reviews.CreateReview {
    public class CreateReviewRequest {
        public Guid ProductId { get; set; }

        public Guid UserId { get; set; }

        public string Comment { get; set; } = default!;

        public int Rating { get; set; }
    }
}
