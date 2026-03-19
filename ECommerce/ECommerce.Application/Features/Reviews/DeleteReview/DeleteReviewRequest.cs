using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.Features.Reviews.DeleteReview {
    public class DeleteReviewRequest {
        public Guid ReviewId { get; set; }

        public Guid UserId { get; set; }
    }
}
