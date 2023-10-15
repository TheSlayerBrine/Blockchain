namespace Blockchain.Services.Service.Accounts;

public class AccountDetailsDto
{
    public string PublicKey { get; set; }
    public string? Nickname { get; set; }
    public double Balance { get; set; }  
}