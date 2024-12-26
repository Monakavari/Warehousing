using System.Net;

namespace Warehousing.Common
{
    public class AppException : Exception
    {
        public HttpStatusCode HttpStatusCode { get; set; }

        public ApiResponseStatusCode ApiStatusCode { get; set; }

        public object AdditionalData { get; set; }

        public AppException()
            : this(ApiResponseStatusCode.ServerError)
        {
        }

        public AppException(ApiResponseStatusCode statusCode)
            : this(statusCode, null)
        {
        }

        public AppException(string message)
            : this(ApiResponseStatusCode.ServerError, message)
        {
        }

        public AppException(ApiResponseStatusCode statusCode, string message)
            : this(statusCode, message, HttpStatusCode.InternalServerError)
        {
        }

        public AppException(string message, object additionalData)
            : this(ApiResponseStatusCode.ServerError, message, additionalData)
        {
        }

        public AppException(ApiResponseStatusCode statusCode, object additionalData)
            : this(statusCode, null, additionalData)
        {
        }

        public AppException(ApiResponseStatusCode statusCode, string message, object additionalData)
            : this(statusCode, message, HttpStatusCode.InternalServerError, additionalData)
        {
        }

        public AppException(ApiResponseStatusCode statusCode, string message, HttpStatusCode httpStatusCode)
            : this(statusCode, message, httpStatusCode, null)
        {
        }

        public AppException(ApiResponseStatusCode statusCode, string message, HttpStatusCode httpStatusCode, object additionalData)
            : this(statusCode, message, httpStatusCode, null, additionalData)
        {
        }

        public AppException(string message, Exception exception)
            : this(ApiResponseStatusCode.ServerError, message, exception)
        {
        }

        public AppException(string message, Exception exception, object additionalData)
            : this(ApiResponseStatusCode.ServerError, message, exception, additionalData)
        {
        }

        public AppException(ApiResponseStatusCode statusCode, string message, Exception exception)
            : this(statusCode, message, HttpStatusCode.InternalServerError, exception)
        {
        }

        public AppException(ApiResponseStatusCode statusCode, string message, Exception exception, object additionalData)
            : this(statusCode, message, HttpStatusCode.InternalServerError, exception, additionalData)
        {
        }

        //public AppException(ApiResponse statusCode, string message, HttpStatusCode httpStatusCode, Exception exception)
        //    : this(statusCode,message, httpStatusCode, exception, null)
        //{
        //}

        public AppException(ApiResponseStatusCode statusCode, string message, HttpStatusCode httpStatusCode, Exception exception, object additionalData)
            : base(message, exception)
        {
            ApiStatusCode = statusCode;
            HttpStatusCode = httpStatusCode;
            AdditionalData = additionalData;
        }
    }

}
