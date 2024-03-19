using Microsoft.AspNetCore.Http;

namespace ProjectX.Core.Contracts
{
    public interface IImageUploader
    {
        Task<string> UploadImageAsync(IFormFile imageFile);
    }
}
