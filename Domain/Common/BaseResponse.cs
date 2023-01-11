using System.Net;

namespace Domain.Common
{
    public record BaseResponse
    {
        public HttpStatusCode StatusCode { get; init; } = HttpStatusCode.OK;
        public string ErrorMessage { get; set; }
    }
}