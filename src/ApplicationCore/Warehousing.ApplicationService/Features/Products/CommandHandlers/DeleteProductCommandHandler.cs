using Warehousing.ApplicationService.Features.Product.Commands.Delete;
using Warehousing.Common;
using Warehousing.Domain.Repository;
using Warehousing.Domain.Repository.Base;

namespace Warehousing.ApplicationService.Features.Product.CommandHandlers
{
    public class DeleteProductCommandHandler : MediatR.IRequestHandler<DeleteProductCommand, ApiResponse>
    {
        #region Constructor
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;
        public DeleteProductCommandHandler(IProductRepository productRepository,
                                             IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }
        #endregion
        public async Task<ApiResponse> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            _productRepository.DeleteById(request.Id);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new ApiResponse(true, ApiResponseStatusCode.Success, "عملیات با موفقیت انجام شد.");
        }
    }
}
