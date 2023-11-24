using System.ComponentModel.DataAnnotations;

namespace Blockchain.WebApi.Models;

public class UploadBlobModel
{
    [Required]
    public string Name { get; set; }
    [Required]
    public string ContentType { get; set; }
    [Required]
    public byte[] Image { get; set; }
}