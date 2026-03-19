using ECommerce.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.Features.Reviews.DeleteReview {
    public class DeleteReviewService {
        private readonly IApplicationDbContext _context;

        public DeleteReviewService(IApplicationDbContext context) {
            _context = context;
        }

        public async Task Execute(DeleteReviewRequest request) {
            var review = await _context.Reviews.FindAsync(request.ReviewId);

            if (review == null || review.UserId != request.UserId)
                throw new Exception("Review not found");

            _context.Reviews.Remove(review);
            await _context.SaveChangesAsync(CancellationToken.None);
        }
    }
}
