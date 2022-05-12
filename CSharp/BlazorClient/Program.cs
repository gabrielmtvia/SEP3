
global using ModelClasses;
global using BlazorClient.authentication;
global using BlazorClient.Services;
global using BlazorClient.Services.BookService;
global using BlazorClient.Services.OrderService;
global using BlazorClient.Services.UserService;
using BlazorClient.Services.CartService;
using BlazorClient.Services.CategoryService;
using BlazorClient.Services.GenreService;
using Microsoft.AspNetCore.Components.Authorization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddScoped(sp => new HttpClient {BaseAddress = new Uri("https://localhost:7031")});
// builder.Services.AddHttpClient<IOrderService, OrderService>(client =>
// {
//     client.BaseAddress = new Uri("https://localhost:7031");
// });
builder.Services.AddScoped<IAuthService, AuthServiceIMP>();
builder.Services.AddScoped<IUserService, UserServiceIMP>();
builder.Services.AddScoped<AuthenticationStateProvider, SimpleAuthenticationStateProvider>();
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IGenreService, GenreService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<ICartService, CartService>();
// builder.Services.AddHttpClient<IBookService, BookService>(client =>
// {
//     client.BaseAddress = new Uri("https://localhost:7031");
// });


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();