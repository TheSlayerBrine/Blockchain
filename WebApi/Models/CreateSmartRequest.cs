using System.ComponentModel.DataAnnotations;

namespace Blockchain.WebApi.Models;

public class CreateSmartRequest
{
    [Required]
    public string Name { get; set; }
    [Required]
    public double Price { get; set; }
    [Required]
    public UploadBlobModel CollectionImage { get; set; }
    [Required]
    public int MaxSupply { get; set; }
}