using System.Net;

namespace Gateways.Api.Helpers.CustomErrors
{
    public class ServiceUnavailableError : BaseError
    {
        public ServiceUnavailableError(string message) : base(HttpStatusCode.ServiceUnavailable, message)
        {
        }
    }
}