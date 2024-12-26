using Warehousing.ApplicationService.Features.Inventory.Commands.Create;
using Warehousing.Common;
using Warehousing.Domain.Repository.Base;
using Warehousing.Domain.Repository;
using Warehousing.ApplicationService.VariableProfiles;
using Warehousing.Common.Enums;
using Warehousing.Common.Utilities.Extensions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Warehousing.DataAccess.EF.Repository;
using Warehousing.ApplicationService.Features.Customers.Commands.Update;

namespace Warehousing.ApplicationService.Features.Inventory.CommandHandlers
{
    public class UpdateCustomerCommandHandler : MediatR.IRequestHandler<UpdateCustomerCommand, ApiResponse>
    {
        #region Constructor
        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWork _unitOfWork;
        public UpdateCustomerCommandHandler(ICustomerRepository customerRepository,
                                            IUnitOfWork unitOfWork)
        {
            _customerRepository = customerRepository;
            _unitOfWork = unitOfWork;
        }
        #endregion
        public async Task<ApiResponse> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var data = await _customerRepository.GetByIdAsync(request.Id, cancellationToken);
            if (data is null)
                throw new AppException("محصول یافت نشد");

            data.Id = request.Id;
            data.CustomerName = request.CustomerName;
            data.CustomerAddress = request.CustomerAddress;
            data.CustomerTel = request.CustomerTel;
            data.EconomicCode = request.EconomicCode;
            data.ModifierUserId = "0";
            data.WarehouseId = request.WarehouseId;

            if (data.CustomerName != request.CustomerName || 
                data.EconomicCode != request.EconomicCode)
            {
                if (await _customerRepository.IsExistCustomerName(request.CustomerName, request.EconomicCode, cancellationToken))
                    throw new AppException("عنوان نمی تواند تکراری باشد");
            }

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new ApiResponse(true, ApiResponseStatusCode.Success, "عملیات با موفقیت انجام شد.");
        }
    }
}
