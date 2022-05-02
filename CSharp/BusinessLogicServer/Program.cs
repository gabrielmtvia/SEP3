using BusinessLogicServer.Model.Order;
using BusinessLogicServer.Networking.Order;
using Grpc.Net.Client;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IOrderNetworking, OrderNetworking>();
builder.Services.AddSingleton<IOrderModel, OrderModel>();



builder.Services.AddGrpc();
builder.Services.AddSingleton(
    new OrderService.OrderServiceClient(GrpcChannel.ForAddress("http://localhost:9090")));
builder.Services.AddSingleton(new BookService.BookServiceClient(GrpcChannel.ForAddress("http://localhost:9090")));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();