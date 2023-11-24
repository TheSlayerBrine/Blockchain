using Microsoft.AspNetCore.Http;

namespace Service.Service.SmartContracts;

public interface ISmartContractService
{
    SmartContractDetailsDto GetDetails(string? key);
    SmartContractDto CreateSmartContract(CreateSmartContractDto dto, string? accountKey);
    public void ChangeSmartContractDetails(string smartKey, SmartContractDto smartContractDto);
    void PurchaseNft( string smartKey, string? accountKey);
    double WithdrawFunds(double amount,string smartKey, string? accountKey);
}