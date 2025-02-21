using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Warehousing.ApplicationService.Features.Users.Commands.Create;
using Warehousing.ApplicationService.VariableProfiles;
using Warehousing.Common;
using Warehousing.Domain.Entities;
using Warehousing.Domain.Freamwork.Extensions;
using Warehousing.Domain.Repository;
using Warehousing.Domain.Repository.Base;

namespace Warehousing.ApplicationService.Features.Users.CommandHandlers
{

    public class CreateUserCommandHandler : MediatR.IRequestHandler<CreateUserCommand, ApiResponse>
    {
        #region Constructor
        private readonly IUserRepository _userRepository;
        private readonly IUserWarehouseRepository _userWarehouseRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private static string _userId = "0";
        private readonly UserManager<ApplicationUsers> _userManager;
        public CreateUserCommandHandler(IUserRepository userRepository,
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
        public async Task<ApiResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            if (await _userRepository.IsExistUserName(request.UserName, request.NationalCode, cancellationToken))
                throw new AppException("عنوان نمی تواند تکراری باشد");

            var mapper = UserProfile.Map(request);
            IdentityResult result = await _userManager.CreateAsync(mapper, "123456");

            if (result.Succeeded)
            {
                await _userRepository.AddRoleToUser(mapper);
            }

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            foreach (var warehouseId in request.UserWarehouseId)
            {
                var userWarehouse = new UserWarehouse()
                {
                    WarehouseId = request.UserWarehouseId[warehouseId],
                    UserIdInWarehouse = mapper.Id,
                    CreatorUserId = _userId
                };
                await _userWarehouseRepository.AddAsync(userWarehouse, cancellationToken);
            }
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new ApiResponse(true, ApiResponseStatusCode.Success, "عملیات با موفقیت انجام شد.");
        }
    }
}
