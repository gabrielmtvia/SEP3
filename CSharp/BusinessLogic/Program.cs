
using BusinessLogicServer.Models.Books;
using BusinessLogicServer.Models.Cart;
using BusinessLogicServer.Models.Genre;
using BusinessLogicServer.Models.Order;
//using BusinessLogicServer.Models.Orders;
using BusinessLogicServer.Models.Register;
using BusinessLogicServer.Networking.Books;
using BusinessLogicServer.Networking.Cart;
using BusinessLogicServer.Networking.Genre;
using BusinessLogicServer.Networking.Order;
//using BusinessLogicServer.Networking.Orders;
using BusinessLogicServer.Networking.Register;
//using BusinessLogicServer.Service.CartService;
//using BusinessLogicServer.Service.GenreService;
using Grpc.Net.Client;
//using IBookService = BusinessLogicServer.Service.BookService.IBookService;

using OrderService = BlazorClient.Services.OrderService.OrderService;

//using OrderService = BlazorClient.Services.OrderService.OrderService;

//using GenreService = BlazorClient.Services.GenreService.GenreService;

//using CartService = BlazorClient.Services.CartService.CartService;
//using GenreService = BlazorClient.Services.GenreService.GenreService;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//builder.Services.AddScoped<IOrderNetworkingExtendingIOrderDao, OrderNetworking>();
builder.Services.AddScoped<IBookNetworking, BookNetworking>();

//builder.Services.AddScoped<IBookService, BusinessLogicServer.Service.BookService.BookService>();
//builder.Services.AddScoped<IOrdersDao, OrderModel>();
//builder.Services.AddScoped<IBookService, BusinessLogicServer.Service.BookService.BookService>();
//builder.Services.AddScoped<IGenreService, GenreService>();
builder.Services.AddScoped<IBookModel, BookModel>();
builder.Services.AddScoped<IGenreModel, GenreModel>();
builder.Services.AddScoped<IgenreNetworking, GenreNetworking>();
builder.Services.AddScoped<ICartModel, CartModel>();
builder.Services.AddScoped<IRegisterModel, RegisterModel>();
builder.Services.AddScoped<IRegisterNetworking, RegisterNetworking>();
builder.Services.AddScoped<ICartNetworking, CartNetworking>();
builder.Services.AddScoped<IOrderModel, OrderModel>();
builder.Services.AddScoped<IOrderNetworking, OrderNetworking>();


builder.Services.AddGrpc();
//builder.Services.AddSingleton(new OrderService.OrderServiceClient(GrpcChannel.ForAddress("http://localhost:9090")));
builder.Services.AddSingleton(new BookService.BookServiceClient(GrpcChannel.ForAddress("http://localhost:9090")));
builder.Services.AddSingleton(new UserService.UserServiceClient(GrpcChannel.ForAddress("http://localhost:9090")));
builder.Services.AddSingleton(new CartService.CartServiceClient(GrpcChannel.ForAddress("http://localhost:9090")));
builder.Services.AddSingleton(new GenreService.GenreServiceClient(GrpcChannel.ForAddress("http://localhost:9090")));
builder.Services.AddSingleton(new global::OrderService.OrderServiceClient(GrpcChannel.ForAddress("http://localhost:9090")));

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


