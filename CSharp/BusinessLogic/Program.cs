using BlazorClient.Services.BookService;
using BusinessLogicServer.Models.Books;
using BusinessLogicServer.Models.Genres;
using BusinessLogicServer.Networking.Books;
using BusinessLogicServer.Networking.Genres;
using Grpc.Net.Client;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IBookNetworking, BookNetworking>();
builder.Services.AddScoped<IBookModel, BookModel>();
builder.Services.AddScoped<IGenreNetworking, GenreNetworking>();
builder.Services.AddScoped<IGenreModel, GenreModel>();




builder.Services.AddGrpc();
builder.Services.AddSingleton(new BookGrpcService.BookGrpcServiceClient(GrpcChannel.ForAddress("http://localhost:9090")));
builder.Services.AddSingleton(new GenreGrpcService.GenreGrpcServiceClient(GrpcChannel.ForAddress("http://localhost:9090")));

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


