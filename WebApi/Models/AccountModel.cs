namespace Blockchain.WebApi.Models
{
    public class AccountModel
    {
        public string PublicKey { get; set; }
        public string? Nickname { get; set; }
        public string PrivateKey { get; set; }
        public float Balance { get; set; }
    }
}
