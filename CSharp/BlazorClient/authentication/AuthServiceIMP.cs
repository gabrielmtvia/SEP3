using System.Security.Claims;
using System.Text.Json;
using BlazorClient.Services.UserService;
using Microsoft.JSInterop;

namespace BlazorClient.authentication;

public class AuthServiceIMP : IAuthService
{
   

    
    private readonly IUserService IuserService;
    private readonly IJSRuntime jsRuntime;
    public Action<ClaimsPrincipal> OnAuthStateChanged{ get; set; } = null!; // assigning to null! to suppress null warning.
    public AuthServiceIMP(IUserService userService, IJSRuntime jsRuntime)
    {
        IuserService = userService;
        this.jsRuntime = jsRuntime;
    }

    public async Task LoginAsync(string username, string password)
    {
        User? user = await IuserService.GetUserAsync(username); // Get user from database

        ValidateLoginCredentials(password, user); // Validate input data against data from database
        // validation success
        await CacheUserAsync(user!); // Cache the user object in the browser 

        ClaimsPrincipal principal = CreateClaimsPrincipal(user); // convert user object to ClaimsPrincipal

        OnAuthStateChanged?.Invoke(principal); // notify interested classes in the change of authentication state
    }

    public async Task LogoutAsync()
    {
        await ClearUserFromCacheAsync(); // remove the user object from browser cache
        ClaimsPrincipal principal = CreateClaimsPrincipal(null); // create a new ClaimsPrincipal with nothing.
        OnAuthStateChanged?.Invoke(principal); // notify about change in authentication state
    }

    public async Task<ClaimsPrincipal> GetAuthAsync() // this method is called by the authentication framework, whenever user credentials are reguired
    {
        User? user =  await GetUserFromCacheAsync(); // retrieve cached user, if any

        ClaimsPrincipal principal = CreateClaimsPrincipal(user); // create ClaimsPrincipal

        return principal;
    }

    private async Task<User?> GetUserFromCacheAsync()
    {
        string userAsJson = await jsRuntime.InvokeAsync<string>("sessionStorage.getItem", "currentUser");
        if (string.IsNullOrEmpty(userAsJson)) return null;
        User user = JsonSerializer.Deserialize<User>(userAsJson)!;
        return user;
    }

    public static void ValidateLoginCredentials(string password, User? user)
    {
        if (user == null)
        {
            throw new Exception("Username not found");
        }

        if (!string.Equals(password,user.password))
        {
            throw new Exception("Password incorrect");
        }
    }

    public static ClaimsPrincipal CreateClaimsPrincipal(User? user)
    {
        if (user != null)
        {
            ClaimsIdentity identity = ConvertUserToClaimsIdentity(user);
            return new ClaimsPrincipal(identity);
        }

        return new ClaimsPrincipal();
    }

    private async Task CacheUserAsync(User user)
    {
        string serialisedData = JsonSerializer.Serialize(user);
        await jsRuntime.InvokeVoidAsync("sessionStorage.setItem", "currentUser", serialisedData);
    }

    private async Task ClearUserFromCacheAsync()
    {
        await jsRuntime.InvokeVoidAsync("sessionStorage.setItem", "currentUser", "");
    }

    private static ClaimsIdentity ConvertUserToClaimsIdentity(User user)
    {
        // here we take the information of the User object and convert to Claims
        // this is (probably) the only method, which needs modifying for your own user type
        List<Claim> claims = new()
        {
            new Claim(ClaimTypes.Name, user.userName),
            // new Claim("Role", user..r),
            // new Claim("SecurityLevel", user.SecurityLevel.ToString()),
            // new Claim("BirthYear", user.BirthYear.ToString()),
                 new Claim("Role", user.role)
        };

        return new ClaimsIdentity(claims, "apiauth_type");
    }
}