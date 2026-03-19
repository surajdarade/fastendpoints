using ECommerce.Application.Features.Orders.CancelOrder;
using ECommerce.Domain.Entities;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;

public class CancelOrderServiceTests {
    [Fact]
    public async Task Should_Cancel_Order_When_User_Is_Owner() {
        var options = new DbContextOptionsBuilder<TestDbContext>()
            .UseInMemoryDatabase("CancelOrderDb")
            .Options;

        var context = new TestDbContext(options);

        var userId = Guid.NewGuid();

        var order = new Order
        {
            Id = Guid.NewGuid(),
            UserId = userId
        };

        context.Orders.Add(order);
        await context.SaveChangesAsync();

        var service = new CancelOrderService(context);

        var request = new CancelOrderRequest
        {
            OrderId = order.Id,
            UserId = userId
        };

        await service.Execute(request);

        order.IsCancelled.Should().BeTrue();
    }
}