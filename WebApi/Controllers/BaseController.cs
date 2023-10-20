using System.Security.Claims;
using Blockchain.Services.Service.Users;
using Blockchain.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Service.SmartContracts;
using Service.Service.TransactionContracts;
using Service.Service.Transactions;

namespace WebApi.Controllers;
[ApiController]
[Authorize]
public abstract class BaseController : ControllerBase
{
   protected string? AccountKey
   {
      get
      {
         if (HttpContext is null || HttpContext.User is null)
         {
            return null;
         }

         var currentUser = HttpContext.User;
         if (!currentUser.HasClaim(c => c.Type == ClaimTypes.NameIdentifier))
         {
            return null;
         }
         var key = currentUser.Claims.FirstOrDefault(p => p.Type == ClaimTypes.NameIdentifier)?.Value;
         if (key is not null)
         {
            return key;
         }

         return null;
      }
   }
   protected void ValidateAccountKey()
   {
      if (AccountKey is null)
      {
         throw new ArgumentNullException(nameof(AccountKey), "User Id not found");
      }
   }
   
}