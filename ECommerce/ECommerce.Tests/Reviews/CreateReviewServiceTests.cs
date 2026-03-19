using ECommerce.Application.Features.Reviews.CreateReview;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;

public class CreateReviewServiceTests {
    [Fact]
    public async Task Should_Add_Review() {
        var options = new DbContextOptionsBuilder<TestDbContext>()
            .UseInMemoryDatabase("ReviewDb")
            .Options;

        var context = new TestDbContext(options);

        var service = new CreateReviewService(context);

        var request = new CreateReviewRequest
        {
            ProductId = Guid.NewGuid(),
            UserId = Guid.NewGuid(),
            Comment = "Good",
            Rating = 5
        };

        await service.Execute(request);

        context.Reviews.Should().HaveCount(1);
    }
}