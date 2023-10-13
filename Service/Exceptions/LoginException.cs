using Blockchain.Services.Enums;

namespace Blockchain.Services.Exceptions;

public class LoginException : BaseException
{
    public LoginException(string message) : base(ErrorCodes.AuthenticationError, message)
    {
        
    }
}