using System.ComponentModel.DataAnnotations;

namespace Warehousing.ApplicationService.Models.Identity
{
    public class AuthRequest
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "UserName is empty !!!")]
        public string UserName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Password is empty !!!")]
        public string Password { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "FiscalYear is empty !!!")]
        public int FiscalYearId { get; set; }
    }
}
