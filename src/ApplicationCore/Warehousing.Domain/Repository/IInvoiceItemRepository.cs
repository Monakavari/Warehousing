using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using Warehousing.Domain.Dtos;
using Warehousing.Domain.Entities;
using Warehousing.Domain.Repository.Base;

namespace Warehousing.Domain.Repository
{
    public interface IInvoiceItemRepository : IBaseRepository<InvoiceItem>
    {
        Task<List<InvoiceItemInfoResponseDto>> GetInvoiceItemListInfo(int invoiceId, CancellationToken cancellationToken);
        Task<List<InvoiceItem>> GetInvoiceItemForRegisterInventoryOperation(int invoiceId, CancellationToken cancellationToken);
        Task<List<int>> GetInvoiceItemIds(int invoiceId, CancellationToken cancellationToken);
    }
}
