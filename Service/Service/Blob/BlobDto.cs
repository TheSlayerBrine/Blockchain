using Microsoft.AspNetCore.Http;

namespace Service.Service.Blob;

public class BlobDto
{
    public IFormFile File { get; set; }
}