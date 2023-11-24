using Azure;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace Service.Service.Blob;

public class BlobService : IBlobService
{
    private readonly BlobServiceClient blobServiceClient;

    public BlobService(BlobServiceClient blobServiceClient)
    {
        this.blobServiceClient = blobServiceClient;
    }


    public bool DeleteBlob(string containerName, string blobName)
    {
        var containerClient = blobServiceClient.GetBlobContainerClient(containerName);

        var blobClient = containerClient.GetBlobClient(blobName);

        return blobClient.DeleteIfExists();
    }

    public string UploadBlob(string containerName, IFormFile blobDto)
    {
        if (blobDto == null || blobDto.Length == 0)
            throw new ArgumentException("Invalid file");

        try
        {
            var containerClient = blobServiceClient.GetBlobContainerClient(containerName);
            containerClient.CreateIfNotExists(PublicAccessType.Blob);

            var blobId = Guid.NewGuid().ToString();
            var contentType = blobDto.ContentType;
            var blobName = $"{blobDto.Name}_{blobId}.{GetExtensionFromContentType(contentType)}";

            var blob = containerClient.GetBlobClient(blobName);
            var httpHeaders = new BlobHttpHeaders()
            {
                ContentType = contentType
            };

            using (var stream = blobDto.OpenReadStream())
            {
                blob.Upload(stream, httpHeaders);
            }
            
            return blobName;
        }
        catch (RequestFailedException ex)
        {
            throw new Exception(ex.Message);
        }
    }


    private string GetExtensionFromContentType(string contentType)
    {
        var mediaType = new MediaType(contentType);
        return mediaType.SubType.ToString();
    }
}