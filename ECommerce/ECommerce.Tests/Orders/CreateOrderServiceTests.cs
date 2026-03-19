using ECommerce.Application.Features.Orders.CreateOrder;
using ECommerce.Application.Interfaces;
using ECommerce.Domain.Entities;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;

public class CreateOrderServiceTests {
    [Fact]
    public async Task Should_Create_Order_Successfully() {
        // Arrange
        var options = new DbContextOptionsBuilder<TestDbContext>()
            .UseInMemoryDatabase(databaseName: "CreateOrderDb")
            .Options;

        var context = new TestDbContext(options);

        var service = new CreateOrderService(context);

        var request = new CreateOrderRequest
        {
            UserId = Guid.NewGuid(),
            Items = new List<OrderItemDto>
            {
                new() { ProductId = Guid.NewGuid(), Quantity = 2 }
            }
        };

        // Act
        var result = await service.Execute(request);

        // Assert
        result.OrderId.Should().NotBeEmpty();

        var order = await context.Orders.FirstOrDefaultAsync();
        order.Should().NotBeNull();
        order!.Items.Should().HaveCount(1);
    }
}