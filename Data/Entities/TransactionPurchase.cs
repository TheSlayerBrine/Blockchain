using Blockchain.Data.Entities;

namespace BlockChain.Data.Entities
{
    public class TransactionPurchase
    {
        public Guid Id { get; set; }
        public string FromAddress { get; set; }
        public SmartContract FromSmartContract { get; set; }
        public string ToAddress { get; set; }
        public Account ToAccount { get; set; }
        public float AmountExchanged { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
