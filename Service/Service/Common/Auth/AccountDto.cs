namespace Blockchain.Services.Service.Common.Auth
{
    public class AccountDto
    {
        public string PublicKey { get; set; }
        public string PrivateKey { get; set; }
        public string? Nickname { get; set; }
        public double Balance { get; set; }  
    }
}
