using Microsoft.AspNetCore.Http;
using Warehousing.ApplicationService.Features.Inventory.Commands.Create;
using Warehousing.ApplicationService.VariableProfiles;
using Warehousing.Common;
using Warehousing.Domain.Freamwork.Extensions;
using Warehousing.Domain.Repository;
using Warehousing.Domain.Repository.Base;

namespace Warehousing.ApplicationService.Features.Inventory.CommandHandlers
{
    public class CreateCustomerCommandHandler : MediatR.IRequestHandler<CreateCustomerCommand, ApiResponse>
    {
        #region Constructor
        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private static string _userId = "0";
        public CreateCustomerCommandHandler(ICustomerRepository customerRepository,
                                            IUnitOfWork unitOfWork)
        {
            _customerRepository = customerRepository;
            _userId = _httpContextAccessor.GetUserId();
            _unitOfWork = unitOfWork;
        }
        #endregion
        public async Task<ApiResponse> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            if (await _customerRepository.IsExistCustomerName(request.CustomerName, request.EconomicCode, cancellationToken) == true)
                throw new AppException("عنوان نمی تواند تکراری باشد");

            var customer = new Warehousing.Domain.Entities.Customer()
            {
                CustomerName = request.CustomerName,
                CustomerAddress = request.CustomerAddress,
                CustomerTel = request.CustomerTel,
                EconomicCode = request.EconomicCode,
                CreatorUserId = _userId,
                WarehouseId = request.WarehouseId
            };
            await _customerRepository.AddAsync(customer, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new ApiResponse(true, ApiResponseStatusCode.Success, "عملیات با موفقیت انجام شد.");
        }
    }
}
