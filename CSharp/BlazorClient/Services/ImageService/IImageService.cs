using Microsoft.AspNetCore.Components.Forms;

namespace BlazorClient.Services.ImageService;

public interface IImageService
{
    Task<string> UploadImageAsync(IBrowserFile file);
}