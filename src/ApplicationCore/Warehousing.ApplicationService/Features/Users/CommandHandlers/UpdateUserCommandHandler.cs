using Microsoft.AspNetCore.Identity;
using Warehousing.ApplicationService.Features.Users.Commands.Update;
using Warehousing.ApplicationService.VariableProfiles;
using Warehousing.Common;
using Warehousing.Domain.Entities;
using Warehousing.Domain.Repository;
using Warehousing.Domain.Repository.Base;

namespace Warehousing.ApplicationService.Features.Suppliers.CommandHandlers
{
    public class UpdateUserCommandHandler : MediatR.IRequestHandler<UpdateUserCommand, ApiResponse>
    {
        #region Constructor
        private readonly IUserRepository _userRepository;
        private readonly UserManager<ApplicationUsers> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserWarehouseRepository _userWarehouseRepository;
        public UpdateUserCommandHandler(IUserRepository userRepository,
                                        IUnitOfWork unitOfWork,
                                        UserManager<ApplicationUsers> userManager,
                                        IUserWarehouseRepository userWarehouseRepository)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _userWarehouseRepository = userWarehouseRepository;
        }
        #endregion
        public async Task<ApiResponse> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var data = await _userRepository.GetByIdAsync(request.UserIdInWarehouse, cancellationToken);

            if (data is null)
                throw new AppException("تامین کننده یافت نشد.");

            if (await _userRepository.IsExistUserName(request.UserName, request.NationalCode, cancellationToken))
                throw new AppException("عنوان نمی تواند تکراری باشد");

            var userIdsInWarehouse = await _userWarehouseRepository.GetUserIdInWarehouseList(request.UserIdInWarehouse, cancellationToken);
            _userWarehouseRepository.DeleteRange(userIdsInWarehouse);

            foreach (var warehouseId in request.UserWarehouseId)
            {
                var userWarehouse = new UserWarehouse()
                {
                    WarehouseId = warehouseId,
                    UserIdInWarehouse = request.UserIdInWarehouse
                    //CreatorUserId = 
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
