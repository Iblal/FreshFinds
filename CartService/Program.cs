using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var redisConnection = builder.Configuration.GetValue<string>("Redis:ConnectionString");

builder.Services.AddSingleton<IConnectionMultiplexer>(ConnectionMultiplexer.Connect(redisConnection));

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
