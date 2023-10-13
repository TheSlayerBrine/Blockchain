using BlockChain.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace Blockchain.Data.Entities
{
    public class Account
    {
        public string PublicKey { get; set; }
        public string? Nickname { get; set; }
        public string PrivateKey { get; set; }
        public float Balance { get; set; }
        public IEnumerable<TransactionPurchase> TransactionPurchases { get; set; }
        public IEnumerable<TransactionContract> TransactionContracts { get; set; }
        public IEnumerable<SmartContract> SmartContracts { get; set; }
        public IEnumerable<Nft> Nfts { get; set; }

    }
}
