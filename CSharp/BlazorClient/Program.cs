
global using BlazorClient.authentication;
 
global using BlazorClient.Services.UserService;
using BlazorClient.Services.BookService;
using BlazorClient.Services.CartService;
using BlazorClient.Services.GenreService;
using BlazorClient.Services.ImageService;
using BlazorClient.Services.OrderService;
using BlazorClient.Services.RegisterService;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddSingleton(sp => new HttpClient {BaseAddress = new Uri("https://localhost:7031")});

builder.Services.AddScoped<IAuthService, AuthServiceIMP>();
builder.Services.AddScoped<IUserService, UserServiceIMP>();
builder.Services.AddScoped<AuthenticationStateProvider, SimpleAuthenticationStateProvider>();
builder.Services.AddScoped<IBookService, BlazorClient.Services.BookService.BookService>();
builder.Services.AddScoped<IGenreService, BlazorClient.Services.GenreService.GenreService>();
builder.Services.AddScoped<IOrderService, BlazorClient.Services.OrderService.OrderService>();
builder.Services.AddScoped<ICartService, BlazorClient.Services.CartService.CartService>();

builder.Services.AddScoped<IRegisterService, RegisterServiceIMP>();
builder.Services.AddScoped<IImageService, ImageService>();

builder.Services.AddScoped<IOrderService, BlazorClient.Services.OrderService.OrderService>();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("MustBeAdmin",
        pb =>
            pb.RequireAuthenticatedUser().RequireClaim("Role", "Admin"));

    options.AddPolicy("MustBeCustomer",
        a => 
            a.RequireAuthenticatedUser().RequireClaim("Role", "Customer"));
    
    options.AddPolicy("MustBeEmployee",
        a => 
            a.RequireAuthenticatedUser().RequireClaim("Role", "Employee"));
    
    
});

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