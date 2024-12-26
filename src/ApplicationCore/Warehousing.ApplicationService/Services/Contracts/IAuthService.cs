using Warehousing.ApplicationService.Models.Identity;
using Warehousing.Common;

namespace Warehousing.ApplicationService.Services.Contracts
{
    public interface IAuthService
    {
        Task<ApiResponse<AuthResponse>> Login(AuthRequest request, CancellationToken cancellationToken);
    }
}
