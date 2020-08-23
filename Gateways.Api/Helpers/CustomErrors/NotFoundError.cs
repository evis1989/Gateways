using System.Net;

namespace Gateways.Api.Helpers.CustomErrors
{
    public class NotFoundError : BaseError
    {
        public NotFoundError(string message) : base(HttpStatusCode.NotFound, message)
        {
        }
    }
}