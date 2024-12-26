using MediatR;
using Warehousing.ApplicationService.Features.Customers.Queries;
using Warehousing.ApplicationService.VariableProfiles;
using Warehousing.ApplicationService.ViewModels;
using Warehousing.Common;
using Warehousing.Domain.Repository.Base;
using Warehousing.Domain.Repository;

namespace Warehousing.ApplicationService.Features.Customers.QueryHandlers
{
    public class GetCustomerDetailQueryHandler : MediatR.IRequestHandler<GetCustomerDetailQuery, ApiResponse<GetCustomerResponseVM>>
    {
        #region Constructor
        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWork _unitOfWork;
        public GetCustomerDetailQueryHandler(ICustomerRepository customerRepository,
                                            IUnitOfWork unitOfWork)
        {
            _customerRepository = customerRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ApiResponse<GetCustomerResponseVM>> Handle(GetCustomerDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = await _customerRepository.GetByIdAsync(request.Id, cancellationToken);
            if (entity == null)
                throw new AppException("مشتری یافت نشد.");

            var mapper = new GetCustomerResponseVM()
            {
                CustomerAddress = entity.CustomerAddress,
                CustomerName = entity.CustomerName,
                CustomerTel = entity.CustomerTel,
                EconomicCode = entity.EconomicCode,
                Id = entity.Id,
                WarehouseId = entity.WarehouseId
            };

            return new ApiResponse<GetCustomerResponseVM>(true, ApiResponseStatusCode.Success, mapper, "عملیات با موفقیت انجام شد");
        }
        #endregion
    }
}
