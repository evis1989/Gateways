using System.Net;

namespace Gateways.Api.Helpers.CustomErrors
{
    public class UnauthorizedError : BaseError
    {
        public UnauthorizedError(string message) : base(HttpStatusCode.Unauthorized, message)
        {
        }
    }
}