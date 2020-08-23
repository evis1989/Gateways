using System.Net;

namespace Gateways.Api.Helpers.CustomErrors
{
    public class ServerError : BaseError
    {
        public ServerError(string message) : base(HttpStatusCode.InternalServerError, message)
        {
        }
    }
}