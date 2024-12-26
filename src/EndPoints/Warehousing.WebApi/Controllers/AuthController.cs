using Microsoft.AspNetCore.Mvc;
using Warehousing.ApplicationService.Models.Identity;
using Warehousing.ApplicationService.Services.Contracts;

namespace Warehousing.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpGet]
        public async Task<IActionResult> Login(AuthRequest request, CancellationToken cancellationToken)
        {
            var result = await _authService.Login(request, cancellationToken);
            return Ok(result);
        }
    }
}
