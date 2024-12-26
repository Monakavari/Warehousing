using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Warehousing.Domain.Dtos;
using Warehousing.Domain.Entities;
using Warehousing.Domain.Repository.Base;

namespace Warehousing.Domain.Repository
{
    public interface IInvoiceRepository : IBaseRepository<Invoice>
    {
        string CreateInvoiceNo();
        Task<GetProductItemInfoResponseDto> GetProductItemInfo(GetProductItemInfoRequestDto request, CancellationToken cancellationToken);
        Task<List<GetInvoiceFullInfoResponseDto>> GetSoldAndReturnedInvoiceListForAnyWarehouse(GetInvoiceFullInfoRequestDto request, CancellationToken cancellationToken);
        Task<DateTime> GetInvoiceDate(int invoiceId, CancellationToken cancellationToken);
        Task<GetDetailPrintResponseDto> GetInvoiceDetailListInfoForPrint(int invoiceId, CancellationToken cancellationToken);
        Task<List<GetAllInvoicedProductResponseDto>> GetAllInvoicedProduct(GetAllInvoicedProductRequestDto request, CancellationToken cancellationToken);
        Task<List<ItemReportOfAnyInvoiceResponseDto>> GetSeparatedInvoiceItemsReportListForPacking(ItemReportOfAnyInvoiceRequestDto request, CancellationToken cancellationToken);
    }
}
