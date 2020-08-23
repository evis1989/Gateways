
namespace Gateways.Api.Helpers.CustomErrors
{
    public class ErrorMessageWithStatusResult 
    {
        public ErrorMessage errors { get; set; }

        public bool status { get; set; }
    }
}