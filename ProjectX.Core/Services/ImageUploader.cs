using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using ProjectX.Core.Contracts;
using System.Net.Http.Headers;

namespace ProjectX.Core.Services
{
    /// <summary>
    /// Service for uploading images to Imgur.
    /// </summary>
    public class ImageUploader : IImageUploader
    {
        private readonly HttpClient _httpClient;
        private readonly string _clientId;

        public ImageUploader(HttpClient httpClient, string clientId)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _clientId = clientId ?? throw new ArgumentNullException(nameof(clientId));
        }

        /// <summary>
        /// Uploads an image asynchronously to Imgur.
        /// </summary>
        /// <param name="imageFile">The image file to upload.</param>
        /// <returns>The URL of the uploaded image.</returns>
        public async Task<string> UploadImageAsync(IFormFile imageFile)
        {
            if (imageFile == null || imageFile.Length <= 0)
                throw new ArgumentException("Invalid image file");

            // Convert the image file to a byte array
            byte[] imageBytes;
            using (var memoryStream = new MemoryStream())
            {
                await imageFile.CopyToAsync(memoryStream);
                imageBytes = memoryStream.ToArray();
            }

            // Prepare the HTTP request
            using (var content = new ByteArrayContent(imageBytes))
            {
                content.Headers.ContentType = MediaTypeHeaderValue.Parse("image/jpeg");
                content.Headers.ContentLength = imageBytes.Length;

                // Set Imgur API authorization header
                _httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Client-ID", _clientId);

                // Send the HTTP request to upload the image
                using (var response = await _httpClient.PostAsync("https://api.imgur.com/3/image", content))
                {
                    response.EnsureSuccessStatusCode();

                    // Read the response content
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var responseData = JsonConvert.DeserializeObject<dynamic>(responseContent);

                    // Extract the image link from the response data
                    return responseData.data.link;
                }
            }
        }
    }
}
