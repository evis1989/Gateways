using System.Text;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Gateways.Api.Helpers.CustomErrors
{
    public class BaseError : IHttpActionResult
    {
        private string message;
        private HttpStatusCode statusCode;

        public BaseError(HttpStatusCode statusCode, string message)
        {
            this.statusCode = statusCode;
            this.message = message;
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var content = new ErrorMessageWithStatusResult
            {
                status = false,
                errors = new ErrorMessage { error = message }
            };
            
            var response = new HttpResponseMessage
            {
                StatusCode = statusCode,
                Content = new StringContent(
                    JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json")
            };

            return Task.FromResult(response);
        }
    }
}