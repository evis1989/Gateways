using System.Net;

namespace Gateways.Api.Helpers.CustomErrors
{
    public class BadRequestError : BaseError
    {
        public BadRequestError(string message) : base(HttpStatusCode.BadRequest, message)
        {
        }
    }
}