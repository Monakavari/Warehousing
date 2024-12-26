using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using Warehousing.DataAccess.EF.Context;
using Warehousing.DataAccess.EF.Repositories.Base;
using Warehousing.Domain.Dtos;
using Warehousing.Domain.Entities;
using Warehousing.Domain.Repository;

namespace Warehousing.DataAccess.EF.Repository
{
    public class InvoiceItemRepository : BaseRepository<InvoiceItem>, IInvoiceItemRepository
    {
        #region Constructor
        private readonly WarehousingDbContext _dbContext;
        public InvoiceItemRepository(WarehousingDbContext context) : base(context)
        {
            _dbContext = context;
        }
        #endregion Constructor

        public async Task<List<InvoiceItemInfoResponseDto>> GetInvoiceItemListInfo(int invoiceId, CancellationToken cancellationToken)
        {
            return await _dbContext.InvoiceItems
                                              .Where(x => x.InvoiceId == invoiceId)
                                              .Select(x => new InvoiceItemInfoResponseDto
                                              {
                                                  CoverPrice = x.CoverPrice,
                                                  ProductCode = x.Product.ProductCode,
                                                  ProductCount = x.ProductCount,
                                                  ProductId = x.ProductId,
                                                  ProductName = x.Product.ProductName,
                                                  PurchasePrice = x.PurchasePrice,
                                                  SalesPrice = x.SalePrice
                                              })
                                              .ToListAsync(cancellationToken);
        }
        public async Task<List<InvoiceItem>> GetInvoiceItemForRegisterInventoryOperation(int invoiceId, CancellationToken cancellationToken)
        {
            return await _dbContext.InvoiceItems
                                        .Where(x => x.InvoiceId == invoiceId)
                                        .ToListAsync(cancellationToken);
        }
        public async Task<List<int>> GetInvoiceItemIds(int invoiceId, CancellationToken cancellationToken)
        {
            return await _dbContext.InvoiceItems
                                            .Where(x => x.InvoiceId == invoiceId)
                                            .Select(x => x.Id)
                                            .ToListAsync(cancellationToken);
        }

    }
}
