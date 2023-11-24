using Blockchain.WebApi.Models;
using Service.Service.Blob;

namespace Blockchain.WebApi.Mappers;

public static class BlobMapper
{
    public static UploadBlobModel ToApiModel(this BlobDto dto)
    {
        if (dto is null)
        {
            return null;
        }

        return new UploadBlobModel
        {
            Name = dto.Name,
            ContentType = dto.ContentType,
            Uri = dto.Uri,
        };
    }

    public static BlobDto ToDto(this UploadBlobModel model)
    {
        if (model is null)
        {
            return null;
        }

        return new BlobDto
        {
            Name = model.Name,
            ContentType = model.ContentType,
            Blob = model.Blob
        };
    }
}