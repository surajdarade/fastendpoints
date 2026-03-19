using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.Features.Reviews.GetReviews {
    public class ReviewDto {
        public string Comment { get; set; } = default!;

        public int Rating { get; set; }
    }
}
