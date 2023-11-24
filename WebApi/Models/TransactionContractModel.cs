namespace Blockchain.WebApi.Models;

public class TransactionContractModel
{
    public Guid Id { get; set; }
    public string FromAddress { get; set; }
    public string ToAddress { get; set; }  
    public string Details { get; set; }
    public DateTime CreatedAt { get; set; }
}