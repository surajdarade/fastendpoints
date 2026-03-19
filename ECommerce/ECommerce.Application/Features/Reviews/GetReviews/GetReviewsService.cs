using ECommerce.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.Features.Reviews.GetReviews {
    public class GetReviewsService {
        private readonly IApplicationDbContext _context;

        public GetReviewsService(IApplicationDbContext context) {
            _context = context;
        }

        public async Task<List<ReviewDto>> Execute(GetReviewsRequest request) {
            return await _context.Reviews
                .AsNoTracking()
                .Where(r => r.ProductId == request.ProductId)
                .Select(r => new ReviewDto
                {
                    Comment = r.Comment,
                    Rating = r.Rating
                })
                .ToListAsync();
        }
    }
}
