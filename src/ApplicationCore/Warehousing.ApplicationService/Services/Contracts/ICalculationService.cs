using Warehousing.Common.DTOs;
using Warehousing.Domain.Dtos;
using Warehousing.Domain.Entities;

namespace Warehousing.ApplicationService.Services.Contracts
{
    public interface ICalculationService
    {
        int CalculateInvoicePrice(List<InvoiceProductDto> invoiceProducts);
        int GetSalesPrice(int productId);
        int GetCoverPrice(int productId);
        int GetPurchasePrice(int productId);
    }
}
