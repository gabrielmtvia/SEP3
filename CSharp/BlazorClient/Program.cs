
global using BlazorClient.authentication;
global using BlazorClient.Services.BookService;
global using BlazorClient.Services.UserService;
using BlazorClient.Services.ImageService;
using BlazorClient.Services.CartService;
using BlazorClient.Services.GenreService;
using BlazorClient.Services.RegisterService;
using Microsoft.AspNetCore.Components.Authorization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddSingleton(sp => new HttpClient {BaseAddress = new Uri("https://localhost:7031")});

builder.Services.AddScoped<IAuthService, AuthServiceIMP>();
builder.Services.AddScoped<IUserService, UserServiceIMP>();
builder.Services.AddScoped<AuthenticationStateProvider, SimpleAuthenticationStateProvider>();
builder.Services.AddSingleton<IBookService, BookService>();
builder.Services.AddScoped<IGenreService, GenreService>();
builder.Services.AddScoped<IImageService, ImageService>();
builder.Services.AddSingleton<ICartService, BlazorClient.Services.CartService.CartService>();
builder.Services.AddScoped<IRegisterService, RegisterServiceIMP>();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("MustBeAdmin",
        pb =>
            pb.RequireAuthenticatedUser().RequireClaim("Role", "Admin"));

    options.AddPolicy("MustBeCustomer",
        a => 
            a.RequireAuthenticatedUser().RequireClaim("Role", "CUSTOMER"));
    
    options.AddPolicy("MustBeEmployee",
        a => 
            a.RequireAuthenticatedUser().RequireClaim("Role", "Employee"));
    
    // options.AddPolicy("SecurityLevel2",
    //     a => 
    //         a.RequireAuthenticatedUser().RequireAssertion(context =>
    //         {
    //             Claim levelClaim = context.User.FindFirst(claim => claim.Type.Equals("Level"));
    //             if (levelClaim == null) return false;
    //             return int.Parse(levelClaim.Value) >= 2;
    //         }));
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