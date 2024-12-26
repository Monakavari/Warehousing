using MediatR;
using Warehousing.ApplicationService.Features.Invoices.Queries;
using Warehousing.Common;
using Warehousing.Domain.Dtos;
using Warehousing.Domain.Repository.Base;
using Warehousing.Domain.Repository;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Microsoft.IdentityModel.Tokens;

namespace Warehousing.ApplicationService.Features.Invoices.QueryHandler
{
    public class GetAllInvoicedProductQueryHandler : MediatR.IRequestHandler<GetAllInvoicedProductQuery, ApiResponse<List<GetAllInvoicedProductResponseDto>>>
    {
        #region Constructor
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IUnitOfWork _unitOfWork;
        public GetAllInvoicedProductQueryHandler(IInvoiceRepository invoiceRepository,
                                                  IUnitOfWork unitOfWork)
        {
            _invoiceRepository = invoiceRepository;
            _unitOfWork = unitOfWork;
        }
        #endregion Constructor
        public async Task<ApiResponse<List<GetAllInvoicedProductResponseDto>>> Handle(GetAllInvoicedProductQuery request, CancellationToken cancellationToken)
        {
            if (request.FromDate.IsNullOrEmpty())
            {
                request.FromDate = "1300/01/01";
            }
            if (request.ToDate.IsNullOrEmpty())
            {
                request.ToDate = "1600/01/01";
            }

            var data = await _invoiceRepository.GetAllInvoicedProduct(new GetAllInvoicedProductRequestDto
            {
                ToDate = request.ToDate,
                FromDate = request.FromDate,
                FiscalYearId = request.FiscalYearId,
                WarehouseId = request.WarehouseId,
            }, cancellationToken);

            return new ApiResponse<List<GetAllInvoicedProductResponseDto>>(true, ApiResponseStatusCode.Success, data, "عملیات با موفقیت انجام شد");
        }
    }
}
