using ECommerce.Application.Features.Reviews.DeleteReview;
using ECommerce.Domain.Entities;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Xunit;

namespace ECommerce.Tests.Reviews {
    public class DeleteReviewServiceTests {
        [Fact]
        public async Task Should_Delete_Review_When_User_Is_Owner() {
            var options = new DbContextOptionsBuilder<TestDbContext>()
                .UseInMemoryDatabase(databaseName: "DeleteReviewDb")
                .Options;

            var context = new TestDbContext(options);

            var userId = Guid.NewGuid();

            var review = new Review
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                ProductId = Guid.NewGuid(),
                Comment = "Test review",
                Rating = 5
            };

            context.Reviews.Add(review);
            await context.SaveChangesAsync();

            var service = new DeleteReviewService(context);

            var request = new DeleteReviewRequest
            {
                ReviewId = review.Id,
                UserId = userId
            };

            await service.Execute(request);

            context.Reviews.Should().BeEmpty();
        }

        [Fact]
        public async Task Should_Throw_Exception_When_User_Is_Not_Owner() {
            var options = new DbContextOptionsBuilder<TestDbContext>()
                .UseInMemoryDatabase(databaseName: "DeleteReviewDb_NotOwner")
                .Options;

            var context = new TestDbContext(options);

            var ownerId = Guid.NewGuid();
            var otherUserId = Guid.NewGuid();

            var review = new Review
            {
                Id = Guid.NewGuid(),
                UserId = ownerId,
                ProductId = Guid.NewGuid(),
                Comment = "Test review",
                Rating = 5
            };

            context.Reviews.Add(review);
            await context.SaveChangesAsync();

            var service = new DeleteReviewService(context);

            var request = new DeleteReviewRequest
            {
                ReviewId = review.Id,
                UserId = otherUserId
            };

            Func<Task> act = async () => await service.Execute(request);

            await act.Should().ThrowAsync<Exception>()
                .WithMessage("Review not found");
        }
    }
}