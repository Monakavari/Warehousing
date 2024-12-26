using Warehousing.Common.Enums;

namespace Warehousing.ApplicationService.Models.Identity
{
    public class AuthResponse
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Token { get; set; }
        public FiscalYearStatus FiscalYearStatus { get; set; }
        public IList<string>? Roles { get; set; }
    }
}
