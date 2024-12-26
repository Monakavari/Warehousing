using Warehousing.ApplicationService.Features.Warehouse.Commands.Create;
using Warehousing.ApplicationService.VariableProfiles;
using Warehousing.Common;
using Warehousing.Domain.Repository.Base;
using Warehousing.Domain.Repository;

namespace Warehousing.ApplicationService.Features.Warehouse.CommandHandlers
{
    public class CreateWarehouseCommandHandler : MediatR.IRequestHandler<CreateWarehouseCommand, ApiResponse>
    {
        #region Constructor
        private readonly IWarehouseRepository _warehouseRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CreateWarehouseCommandHandler(IWarehouseRepository warehouseRepository,
                                             IUnitOfWork unitOfWork)
        {
            _warehouseRepository = warehouseRepository;
            _unitOfWork = unitOfWork;
        }
        #endregion
        public async Task<ApiResponse> Handle(CreateWarehouseCommand request, CancellationToken cancellationToken)
        {
            if (await _warehouseRepository.IsExistWarehouseName(request.WarehouseName, cancellationToken))
                throw new AppException("عنوان نمی تواند تکراری باشد");

            var mapper = WarehouseProfile.Map(request);
            await _warehouseRepository.AddAsync(mapper, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new ApiResponse(true, ApiResponseStatusCode.Success, "عملیات با موفقیت انجام شد.");
        }
    }
}
