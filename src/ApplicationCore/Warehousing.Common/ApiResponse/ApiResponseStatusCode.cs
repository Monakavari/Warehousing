using System.ComponentModel.DataAnnotations;

namespace Warehousing.Common
{
    public enum ApiResponseStatusCode
    {
        [Display(Name = "عملیات با موفقیت انجام شد")]
        Success = 200,
        [Display(Name = "خطایی در سرور رخ داده است")]
        ServerError = 500,
        [Display(Name = "پارامتر های ارسالی معتبر نیستند")]
        BadRequest = 400,
        [Display(Name = "یافت نشد")]
        NotFound = 404,
        [Display(Name = "لیست خالی است")]
        ListEmpty = 4,
        [Display(Name = "خطایی در پردازش رخ داد")]
        LogicError = 5,
        [Display(Name = "خطای احراز هویت")]
        UnAuthorized = 401,
        [Display(Name = "خطای درخواست زیاد")]
        TooManyRequest = 429,
        [Display(Name = "خطای عدم دسترسی")]
        Forbidden = 403,
        Gone = 410
    }
}
