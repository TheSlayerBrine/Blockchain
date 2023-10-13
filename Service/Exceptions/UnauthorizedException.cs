using Blockchain.Services.Enums;

namespace Blockchain.Services.Exceptions
{
    public class UnauthorizedException : BaseException
    {
        public UnauthorizedException() : base(ErrorCodes.UnauthorizedError) { }

    }
}
