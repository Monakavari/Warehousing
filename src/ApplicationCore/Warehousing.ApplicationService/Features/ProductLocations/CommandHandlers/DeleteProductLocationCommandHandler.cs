using Warehousing.ApplicationService.Features.ProductLocation.Commands.Delete;
using Warehousing.Common;
using Warehousing.Domain.Repository;
using Warehousing.Domain.Repository.Base;

namespace Warehousing.ApplicationService.Features.ProductLocation.CommandHandlers
{
    public class DeleteProductLocationCommandHandler : MediatR.IRequestHandler<DeleteProductLocationCommand, ApiResponse>
    {
        #region Constructor
        private readonly IProductLocationRepository _productLocationRepository;
        private readonly IUnitOfWork _unitOfWork;
        public DeleteProductLocationCommandHandler(IProductLocationRepository productLocationRepository,
                                                   IUnitOfWork unitOfWork)
        {
            _productLocationRepository = productLocationRepository;
            _unitOfWork = unitOfWork;
        }
        #endregion
        public async Task<ApiResponse> Handle(DeleteProductLocationCommand request, CancellationToken cancellationToken)
        {
            _productLocationRepository.DeleteById(request.Id);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new ApiResponse(true, ApiResponseStatusCode.Success, "عملیات با موفقیت انجام شد.");
        }
    }
}