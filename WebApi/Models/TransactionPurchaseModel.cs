namespace Blockchain.WebApi.Models;

public class TransactionPurchaseModel
{
    public Guid Id { get; set; }
    public string FromAddress { get; set; }
    public string ToAddress { get; set; }
    public double AmountExchanged { get; set; }
    public DateTime CreatedAt { get; set; }
    public int nftId { get; set; }
}