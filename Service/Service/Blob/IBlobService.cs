using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Service.Service.Blob;

public interface IBlobService
{
    bool DeleteBlob(string containerName, string blobName);
    string UploadBlob(string containerName, IFormFile file);
}