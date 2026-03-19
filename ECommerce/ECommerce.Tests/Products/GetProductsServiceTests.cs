using ECommerce.Application.Features.Products.GetProducts;
using ECommerce.Domain.Entities;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;

public class GetProductsServiceTests {
    [Fact]
    public async Task Should_Return_Paginated_Products() {
        var options = new DbContextOptionsBuilder<TestDbContext>()
            .UseInMemoryDatabase("ProductsDb")
            .Options;

        var context = new TestDbContext(options);

        context.Products.AddRange(
            new Product { Id = Guid.NewGuid(), Name = "A", Price = 10 },
            new Product { Id = Guid.NewGuid(), Name = "B", Price = 20 },
            new Product { Id = Guid.NewGuid(), Name = "C", Price = 30 }
        );

        await context.SaveChangesAsync();

        var service = new GetProductsService(context);

        var result = await service.Execute(new GetProductsRequest
        {
            Page = 1,
            PageSize = 2
        });

        result.Products.Should().HaveCount(2);
    }
}