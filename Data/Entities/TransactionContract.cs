using BlockChain.Data.Entities;

namespace Blockchain.Data.Entities
{
    public class TransactionContract
    {
        public Guid Id { get; set; }
        public string FromAddress { get; set; }
        public Account FromAccount { get; set; }
        public SmartContract ToSmartContract { get; set; }
        public string ToAddress { get; set; }  
        public string Details { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
