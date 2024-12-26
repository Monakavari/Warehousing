using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Warehousing.ApplicationService.Models.Identity;
using Warehousing.ApplicationService.Models.Identity.JwtUtility.Contract;
using Warehousing.ApplicationService.Services.Contracts;
using Warehousing.Common;
using Warehousing.Common.Enums;
using Warehousing.Common.Utilities.Extensions;
using Warehousing.Domain.Entities;
using Warehousing.Domain.Repository;

namespace Warehousing.ApplicationService.Services.Implementations
{
    public class AuthService : IAuthService
    {
        #region Constructor
        private readonly UserManager<ApplicationUsers> _userManager;
        private readonly SignInManager<ApplicationUsers> _signInManager;
        private readonly IFiscalYearRepository _fiscalYearRepository;
        private readonly IJwtTokenGenerator _token;
        public AuthService(UserManager<ApplicationUsers> userManager,
                           SignInManager<ApplicationUsers> signInManager,
                           IJwtTokenGenerator token,
                           IFiscalYearRepository fiscalYearRepository)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _token = token;
            _fiscalYearRepository = fiscalYearRepository;
        }
        #endregion Constructor
        public async Task<ApiResponse<AuthResponse>> Login(AuthRequest request, CancellationToken cancellationToken)
        {
            var fiscalYearStatus = FiscalYearStatus.Undefined;
            var user = await _userManager.Users
                                           .Where(x => x.UserName == request.UserName)
                                           .SingleOrDefaultAsync(cancellationToken);

            if (user == null)
                throw new AppException("کاربری یافت نشد.");

            var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);

            if (!result.Succeeded)
                throw new AppException("نام کاربری یا پسورد نادرست می باشد.");

            fiscalYearStatus = await CheckFiscalYearStatus(request, fiscalYearStatus, cancellationToken);
            var roles = await _userManager.GetRolesAsync(user);

            var usertoken = new AuthResponse
            {
                Roles = await _userManager.GetRolesAsync(user),
                Token = await _token.CreateTokenAsync(user),
                UserName = user.UserName,
                UserId = user.Id,
                FiscalYearStatus = fiscalYearStatus
            };

            return new ApiResponse<AuthResponse>(true, ApiResponseStatusCode.Success, usertoken, "عملیات با موفقیت انجام شد");
        }
        private async Task<FiscalYearStatus> CheckFiscalYearStatus(AuthRequest request, FiscalYearStatus fiscalYearStatus, CancellationToken cancellationToken)
        {
            var fiscalStatus = await _fiscalYearRepository.CheckFiscalYearStatus(request.FiscalYearId, cancellationToken);

            if (fiscalStatus.FiscalFlag == true &&
                fiscalStatus.EndDate.Date >= DateTime.Now)
            {
                //همه چیز درست می باشد
                fiscalYearStatus = FiscalYearStatus.Open;
            }
            else if (fiscalStatus.FiscalFlag == true &&
                     fiscalStatus.EndDate.Date < DateTime.Now)
            {
                //سال مالی باز می باشد ولی تاریخ روز از تاریخ پایان سال مالی عبور کرده است
                fiscalYearStatus = FiscalYearStatus.Expired;
            }
            else if (fiscalStatus.FiscalFlag == false)
            {
                //سال مالی بسته است
                fiscalYearStatus = FiscalYearStatus.Close;
            }

            return fiscalYearStatus;
        }
    }
}
