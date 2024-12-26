using Warehousing.ApplicationService.Features.Warehouse.Commands.Delete;
using Warehousing.Common;
using Warehousing.Domain.Repository.Base;
using Warehousing.Domain.Repository;

namespace Warehousing.ApplicationService.Features.Warehouse.CommandHandlers
{
    public class DeleteWarehouseCommandHandler : MediatR.IRequestHandler<DeleteWarehouseCommand, ApiResponse>
    {
        #region Constructor
        private readonly IWarehouseRepository _warehouseRepository;
        private readonly IUnitOfWork _unitOfWork;
        public DeleteWarehouseCommandHandler(IWarehouseRepository warehouseRepository,
                                             IUnitOfWork unitOfWork)
        {
            _warehouseRepository = warehouseRepository;
            _unitOfWork = unitOfWork;
        }
        #endregion
        public async Task<ApiResponse> Handle(DeleteWarehouseCommand request, CancellationToken cancellationToken)
        {
            _warehouseRepository.DeleteById(request.Id);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new ApiResponse(true, ApiResponseStatusCode.Success, "عملیات با موفقیت انجام شد.");
        }
    }
}
