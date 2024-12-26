using Warehousing.ApplicationService.Features.Invoices.Queries;
using Warehousing.ApplicationService.Services.Contracts;
using Warehousing.ApplicationService.ViewModels;
using Warehousing.Common;
using Warehousing.Domain.Dtos;
using Warehousing.Domain.Repository.Base;
using Warehousing.Domain.Repository;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Warehousing.ApplicationService.Features.Invoices.QueryHandler
{
    public class GetProductItemInfoQueryHandler : MediatR.IRequestHandler<GetProductItemInfoDetailQuery, ApiResponse<GetProductItemInfoResponseDto>>
    {
        #region Constructor

        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IUnitOfWork _unitOfWork;
        public GetProductItemInfoQueryHandler(IInvoiceRepository invoiceRepository,
                                              IUnitOfWork unitOfWork)

        {
            _invoiceRepository = invoiceRepository;
            _unitOfWork = unitOfWork;
        }
        #endregion Constructor
        public async Task<ApiResponse<GetProductItemInfoResponseDto>> Handle(GetProductItemInfoDetailQuery request, CancellationToken cancellationToken)
        {
            var data = await _invoiceRepository.GetProductItemInfo(new GetProductItemInfoRequestDto
            {
                ProductCode = request.ProductCode,
                WarehouseId = request.WarehouseId,
                FiscalYearId = request.FiscalYearId
            }, cancellationToken);

            return new ApiResponse<GetProductItemInfoResponseDto>(true, ApiResponseStatusCode.Success, data, "عملیات با موفقیت انجام شد");
        }
    }
}
