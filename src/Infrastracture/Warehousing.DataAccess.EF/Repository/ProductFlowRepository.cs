using Microsoft.EntityFrameworkCore;
using System.Net.NetworkInformation;
using Warehousing.Common.Utilities.Extensions;
using Warehousing.DataAccess.EF.Context;
using Warehousing.Domain.Dtos;
using Warehousing.Domain.Repository;

namespace Warehousing.DataAccess.EF.Repository
{
    public class ProductFlowRepository : IProductFlowRepository
    {
        #region Constructor

        private readonly WarehousingDbContext _Context;
        public ProductFlowRepository(WarehousingDbContext context)
        {
            _Context = context;
        }
        #endregion Constructor
        public async Task<List<GetProductFlowResponseDto>> GetProductFlow(ProductFlowRequestDto request, CancellationToken cancellationToken)
        {
            if (request.FromDate == "" || request.FromDate == null)
            {
                request.FromDate = "1300/01/01";
            }
            if (request.ToDate == "" || request.ToDate == null)
            {
                request.ToDate = "1800/01/01";
            }
            return await _Context.Inventories
                                     .Where(x => x.ProductId == request.ProductId &&
                                                 x.FiscalYearId == request.FiscalYearId &&
                                                 x.WarehouseId == request.WarehouseId &&
                                                 x.OperationDate >= PersianDate.ToMiladi(request.FromDate) &&
                                                 x.OperationDate <= PersianDate.ToMiladi(request.ToDate))
                                     .Select(x => new GetProductFlowResponseDto
                                     {
                                         OperationType = (OperationalStatus)(x.OperationType),
                                         ExpireDate = PersianDate.ToShamsi(x.ExpireDate),
                                         Description = x.Description,
                                         OperationDate = PersianDate.ToShamsi(x.OperationDate),
                                         MainProductCount = x.MainProductCount,
                                         WastageProductCount = x.WastageProductCount
                                         //CreatorUserFullName

                                     })
                                     .ToListAsync(cancellationToken);
        }
    }
}
