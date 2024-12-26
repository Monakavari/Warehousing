using Warehousing.Domain.Entities;

namespace Warehousing.ApplicationService.Models.Identity.JwtUtility.Contract
{
    public interface IJwtTokenGenerator
    {
        Task<string> CreateTokenAsync(ApplicationUsers user);
    }
}
