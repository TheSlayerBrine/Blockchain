namespace Service.Service.Nfts;

public interface INftService
{
    void CreateNft(string smartKey, string newOwner, string name, int index);
}