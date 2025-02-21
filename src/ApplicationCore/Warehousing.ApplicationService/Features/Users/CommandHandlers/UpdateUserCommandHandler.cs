using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Warehousing.ApplicationService.Features.Users.Commands.Update;
using Warehousing.ApplicationService.VariableProfiles;
using Warehousing.Common;
using Warehousing.Common.Utilities.Extensions;
using Warehousing.Domain.Entities;
using Warehousing.Domain.Freamwork.Extensions;
using Warehousing.Domain.Repository;
using Warehousing.Domain.Repository.Base;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Warehousing.ApplicationService.Features.Suppliers.CommandHandlers
{
    public class UpdateUserCommandHandler : MediatR.IRequestHandler<UpdateUserCommand, ApiResponse>
    {
        #region Constructor
        private readonly IUserRepository _userRepository;
        private readonly UserManager<ApplicationUsers> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserWarehouseRepository _userWarehouseRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private static string _userId = "0";
        public UpdateUserCommandHandler(IUserRepository userRepository,
                                        IUnitOfWork unitOfWork,
                                        UserManager<ApplicationUsers> userManager,
                                        IUserWarehouseRepository userWarehouseRepository)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _userId = _httpContextAccessor.GetUserId();
            _userWarehouseRepository = userWarehouseRepository;
        }
        #endregion
        public async Task<ApiResponse> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var data = await _userRepository.GetByIdAsync(request.UserIdInWarehouse, cancellationToken);

            if (data is null)
                throw new AppException("تامین کننده یافت نشد.");

            data.Id = request.UserIdInWarehouse;
            data.FirstName = request.FirstName;
            data.LastName = request.LastName;
            data.UserImage = request.UserImage;
            data.NationalCode = request.NationalCode;
            data.PersonalCode = request.PersonalCode;
            data.BirthDate = PersianDate.ToMiladi(request.BirthDate);
            data.Gender = request.Gender;
            data.UserName = request.UserName;
            //data.ModifierUserId = _userId;

            if (data.UserName != request.UserName) 
            {
                if (await _userRepository.IsExistUserName(request.UserName, request.NationalCode, cancellationToken))
                    throw new AppException("نام کاربری نمی تواند تکراری باشد");
            }
            var userIdsInWarehouse = await _userWarehouseRepository.GetUserIdInWarehouseList(request.UserIdInWarehouse, cancellationToken);
            _userWarehouseRepository.DeleteRange(userIdsInWarehouse);

            foreach (var warehouseId in request.UserWarehouseId)
            {
                var userWarehouse = new UserWarehouse()
                {
                    WarehouseId = warehouseId,
                    UserIdInWarehouse = request.UserIdInWarehouse,
                    CreatorUserId = _userId
                };
                await _userWarehouseRepository.AddAsync(userWarehouse, cancellationToken);
            }
            var mapper = UserProfile.Map(request);
            IdentityResult result = await _userManager.UpdateAsync(mapper);

            if (result.Succeeded)

                await _unitOfWork.SaveChangesAsync(cancellationToken);
            return new ApiResponse(true, ApiResponseStatusCode.Success, "عملیات با موفقیت انجام شد.");

        }
    }
}
