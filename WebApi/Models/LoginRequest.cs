using System.ComponentModel.DataAnnotations;
using Microsoft.Build.Framework;

namespace Blockchain.WebApi.Models;

public class LoginRequest
{
    public string PublicKey { get; set; }
    public string PrivateKey { get; set; }
}