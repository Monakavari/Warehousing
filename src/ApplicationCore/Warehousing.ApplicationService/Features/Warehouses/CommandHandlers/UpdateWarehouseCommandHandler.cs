using Warehousing.ApplicationService.Features.Warehouse.Commands.Update;
using Warehousing.Common;
using Warehousing.Domain.Repository.Base;
using Warehousing.Domain.Repository;
using Warehousing.ApplicationService.VariableProfiles;
using Warehousing.DataAccess.EF.Repository;

namespace Warehousing.ApplicationService.Features.Warehouse.CommandHandlers
{
    public class UpdateWarehouseCommandHandler : MediatR.IRequestHandler<UpdateWarehouseCommand, ApiResponse>
    {
        #region Constructor
        private readonly IWarehouseRepository _warehouseRepository;
        private readonly IUnitOfWork _unitOfWork;
        public UpdateWarehouseCommandHandler(IWarehouseRepository warehouseRepository,
                                             IUnitOfWork unitOfWork)
        {
            _warehouseRepository = warehouseRepository;
            _unitOfWork = unitOfWork;
        }
        #endregion
        public async Task<ApiResponse> Handle(UpdateWarehouseCommand request, CancellationToken cancellationToken)
        {
            var data = await _warehouseRepository.GetByIdAsync(request.Id, cancellationToken);
            if (data is null)
                throw new AppException("انباری یافت نشد");

            if (await _warehouseRepository.IsExistWarehouseName(request.WarehouseName, cancellationToken))
                throw new AppException("عنوان نمی تواند تکراری باشد");

            WarehouseProfile.Map(data);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new ApiResponse(true, ApiResponseStatusCode.Success, "عملیات با موفقیت انجام شد.");
        }
    }
}
