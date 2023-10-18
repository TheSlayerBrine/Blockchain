namespace Service.Service.SmartContracts;

public interface ISmartContractService
{
    SmartContractDto GetDetails(string? key);
    void CreateSmartContract(string name, int maxSupply, double price, string? accountKey);
    void ChangeSmartContractName(string name, string smartKey, string? accountKey);
    void ChangeSmartContractMaxSupply(int maxSupply, string smartKey, string? accountKey);
    void PurchaseNft( string smartKey, string? accountKey);
    double WithdrawFunds(double amount,string smartKey, string? accountKey);
}