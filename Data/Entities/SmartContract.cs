using Blockchain.Data.Entities;

namespace BlockChain.Data.Entities
{
    public class SmartContract
    {
        public string PublicKey { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public Account Owner { get; set; }
        public string OwnerId { get; set; }
        public int MaxSupply { get; set; }
        public int SuppySold { get; set; }
        public IEnumerable<Nft> Nfts { get; set; }
        public IEnumerable<TransactionPurchase> TransactionPurchases { get; set; }
        public IEnumerable<TransactionContract> TransactionContracts { get; set; }
    }
}
