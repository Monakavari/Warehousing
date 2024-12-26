using Warehousing.Common.DTOs;
using Warehousing.Domain.Dtos;

namespace Warehousing.ApplicationService.Services.Contracts
{
    public interface ICalculationService
    {
        int CalculateInvoicePrice(List<InvoiceProductDto> invoiceProducts);
    }
}
