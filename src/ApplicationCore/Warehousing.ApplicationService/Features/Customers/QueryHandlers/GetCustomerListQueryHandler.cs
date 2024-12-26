using Microsoft.EntityFrameworkCore;
using Warehousing.ApplicationService.Features.Inventory.Queries;
using Warehousing.ApplicationService.ViewModels;
using Warehousing.Common;
using Warehousing.Common.Utilities.Extensions;
using Warehousing.DataAccess.EF.Repository;
using Warehousing.Domain.Dtos;
using Warehousing.Domain.Repository;
using Warehousing.Domain.Repository.Base;

namespace Warehousing.ApplicationService.Features.Customers.QueryHandlers
{
    public class GetCustomerListQueryHandler : MediatR.IRequestHandler<GetCustomerListQuery, ApiResponse<List<GetCustomerResponseVM>>>
    {
        #region Constructor
        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWork _unitOfWork;
        public GetCustomerListQueryHandler(ICustomerRepository customerRepository,
                                           IUnitOfWork unitOfWork)
        {
            _customerRepository = customerRepository;
            _unitOfWork = unitOfWork;
        }
        #endregion

        //Customers list of any user
        public async Task<ApiResponse<List<GetCustomerResponseVM>>> Handle(GetCustomerListQuery request, CancellationToken cancellationToken)
        {
            var data = await _customerRepository
                                   .FetchIQueryableEntity()
                                   .Where(x => x.CreatorUserId == request.UserId)
                                   .Select(x => new GetCustomerResponseVM
                                   {
                                       Id = x.Id,
                                       WarehouseId = x.WarehouseId,
                                       EconomicCode = x.EconomicCode,
                                       CustomerAddress = x.CustomerAddress,
                                       CustomerName = x.CustomerName,
                                       CustomerTel = x.CustomerTel,
                                   })
                                   .ToListAsync(cancellationToken);

            return new ApiResponse<List<GetCustomerResponseVM>>(true, ApiResponseStatusCode.Success, data, "عملیات با موفقیت انجام شد");
        }
    }
}
