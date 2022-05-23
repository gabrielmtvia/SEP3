using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Components.Forms;

namespace BlazorClient.Services.ImageService;

public class ImageService : IImageService
{
    private Account account;
    private Cloudinary cloudinary;

    public ImageService()
    {
        account = new Account(
            "dklaj3jcr",
            "346124747438848",
            "gWYzb2xNGSQ5dCNX8xbbEp2iejo");
        cloudinary = new Cloudinary(account);
    }

    public async Task<string> UploadImageAsync(IBrowserFile file)
    {
        var imageUploadParams = new ImageUploadParams()
        {
            File = new FileDescription(file.Name, file.OpenReadStream()),
            PublicId = file.Name
        };

        var imageUploadResult = await cloudinary.UploadAsync(imageUploadParams);
        return imageUploadResult.SecureUrl.AbsoluteUri;
    }
}