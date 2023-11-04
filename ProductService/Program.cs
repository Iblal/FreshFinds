using FluentValidation;
using ProductService.Data;
using ProductService.DTOs;
using ProductService.Validations;
using ProductService.Data.Repositories;
using MassTransit;
using ProductService.Consumers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddScoped<IValidator<CreateProductDto>, CreateProductValidator>();

builder.Services.AddScoped<IProductRepository, ProductRepository>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddMassTransit(x =>
{
    x.AddConsumersFromNamespaceContaining<GetProductsAvailabilityConsumer>();
    x.AddConsumersFromNamespaceContaining<OrderCreatedConsumer>();

    x.SetEndpointNameFormatter(new KebabCaseEndpointNameFormatter("product", false));

    x.UsingRabbitMq((context, cfg) => {

        cfg.ReceiveEndpoint("product-order-created", e =>
        {
            e.UseMessageRetry(r => r.Interval(5, 5));

            e.ConfigureConsumer<OrderCreatedConsumer>(context);
        });

        cfg.ReceiveEndpoint("product-get-products-availability", e =>
        {
            e.UseMessageRetry(r => r.Interval(5, 5));

            e.ConfigureConsumer<GetProductsAvailabilityConsumer>(context);
        });

        cfg.ConfigureEndpoints(context);
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.MapControllers();

app.Lifetime.ApplicationStarted.Register(async () =>
{
    try
    {
        await DbInitializer.InitDb(app);
    }
    catch (Exception e)
    {
        Console.WriteLine(e);
    }
});

app.Run();
