using ECommerce.Application.Features.Orders.CancelOrder;
using ECommerce.Application.Features.Orders.CreateOrder;
using ECommerce.Application.Features.Orders.GetMyOrders;
using ECommerce.Application.Features.Products.GetProducts;
using ECommerce.Application.Features.Reviews.CreateReview;
using ECommerce.Application.Features.Reviews.DeleteReview;
using ECommerce.Application.Features.Reviews.GetReviews;
using ECommerce.Infrastructure;
using FastEndpoints;

var builder = WebApplication.CreateBuilder(args);

// FastEndpoints
builder.Services.AddFastEndpoints();

// Infrastructure (DbContext, etc.)
builder.Services.AddInfrastructure(builder.Configuration);

// Application Services
builder.Services.AddScoped<GetProductsService>();
builder.Services.AddScoped<CreateOrderService>();
builder.Services.AddScoped<GetMyOrdersService>();
builder.Services.AddScoped<CancelOrderService>();
builder.Services.AddScoped<CreateReviewService>();
builder.Services.AddScoped<GetReviewsService>();
builder.Services.AddScoped<DeleteReviewService>();

var app = builder.Build();

app.UseFastEndpoints();

app.Run();
