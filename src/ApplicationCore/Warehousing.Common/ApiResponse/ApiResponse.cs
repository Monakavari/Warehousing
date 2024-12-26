using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;

namespace Warehousing.Common
{
    public class ApiResponse
    {
        [JsonProperty("isSuccess")]
        public bool IsSuccess { get; set; }

        [JsonProperty("statusCode")]
        public int StatusCode { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        public ApiResponse(bool isSuccess, ApiResponseStatusCode statusCode, string message = null)
        {
            IsSuccess = isSuccess;
            StatusCode = (int)statusCode;
            Message = message ?? statusCode.ToDisplay();
        }

        public ApiResponse(bool isSuccess, HttpStatusCode statusCode, string message = null)
        {
            IsSuccess = isSuccess;
            StatusCode = (int)statusCode;
            Message = message ?? statusCode.ToDisplay();
        }

        public static implicit operator ApiResponse(OkResult result)
        {
            return new ApiResponse(isSuccess: true, ApiResponseStatusCode.Success);
        }

        public static implicit operator ApiResponse(BadRequestResult result)
        {
            return new ApiResponse(isSuccess: false, ApiResponseStatusCode.BadRequest);
        }

        public static implicit operator ApiResponse(BadRequestObjectResult result)
        {
            Dictionary<string, string[]> source = (Dictionary<string, string[]>)result.Value!.GetType().GetProperty("Errors")!.GetValue(result.Value, null);
            string message = result.ToString();
            IEnumerable<string> enumerable = source.SelectMany((KeyValuePair<string, string[]> p) => p.Value).Distinct();
            if (enumerable.Count() > 0)
            {
                message = string.Join(" | ", enumerable);
            }

            return new ApiResponse(isSuccess: false, ApiResponseStatusCode.BadRequest, message);
        }

        public static implicit operator ApiResponse(ContentResult result)
        {
            return new ApiResponse(isSuccess: true, ApiResponseStatusCode.Success, result.Content);
        }

        public static implicit operator ApiResponse(NotFoundResult result)
        {
            return new ApiResponse(isSuccess: false, ApiResponseStatusCode.NotFound);
        }
    }

}
