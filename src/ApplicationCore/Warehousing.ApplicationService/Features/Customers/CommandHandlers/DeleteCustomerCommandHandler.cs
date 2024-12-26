using Warehousing.ApplicationService.Features.Customers.Commands.Delete;
using Warehousing.ApplicationService.Features.Inventory.Commands.CreateExit;
using Warehousing.ApplicationService.VariableProfiles;
using Warehousing.Common;
using Warehousing.Common.Enums;
using Warehousing.Common.Utilities.Extensions;
using Warehousing.DataAccess.EF.Repository;
using Warehousing.Domain.Repository;
using Warehousing.Domain.Repository.Base;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Warehousing.ApplicationService.Features.Inventory.CommandHandlers
{
    public class DeleteCustomerCommandHandler : MediatR.IRequestHandler<DeleteCustomerCommand, ApiResponse>
    {
        #region Constructor
        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWork _unitOfWork;
        public DeleteCustomerCommandHandler(ICustomerRepository customerRepository,
                                            IUnitOfWork unitOfWork)
        {
            _customerRepository = customerRepository;
            _unitOfWork = unitOfWork;
        }
        #endregion
        public async Task<ApiResponse> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            _customerRepository.DeleteById(request.Id);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new ApiResponse(true, ApiResponseStatusCode.Success, "عملیات با موفقیت انجام شد.");
        }
    }
}
