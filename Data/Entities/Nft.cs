using BlockChain.Data.Entities;
using Microsoft.VisualBasic;

namespace Blockchain.Data.Entities
{
    public class Nft
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public SmartContract Collection { get; set; }
        public string CollectionKey { get; set; }
        public Account? Owner { get; set; }
        public string? OwnerKey { get; set; }
    }
}
