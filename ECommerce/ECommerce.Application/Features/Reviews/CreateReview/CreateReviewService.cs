using ECommerce.Application.Interfaces;
using ECommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.Features.Reviews.CreateReview {
    public class CreateReviewService {
        private readonly IApplicationDbContext _context;

        public CreateReviewService(IApplicationDbContext context) {
            _context = context;
        }

        public async Task Execute(CreateReviewRequest request) {
            var review = new Review
            {
                Id = Guid.NewGuid(),
                ProductId = request.ProductId,
                UserId = request.UserId,
                Comment = request.Comment,
                Rating = request.Rating
            };

            _context.Reviews.Add(review);
            await _context.SaveChangesAsync(CancellationToken.None);
        }
    }
}
