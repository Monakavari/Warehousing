namespace Warehousing.Common
{
    public class ApiResponse<TData> : ApiResponse
    {
        public TData Data { get; set; }

        public ApiResponse(bool isSuccess, ApiResponseStatusCode statusCode, TData data, string message = null)
            : base(isSuccess, statusCode, message)
        {
            Data = data;
        }
    }
}
