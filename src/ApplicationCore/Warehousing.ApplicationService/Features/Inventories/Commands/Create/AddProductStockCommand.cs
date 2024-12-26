using MediatR;
using Warehousing.Common;
using Warehousing.Common.Enums;

namespace Warehousing.ApplicationService.Features.Inventory.Commands.Create
{
    public class AddProductStockCommand : IRequest<ApiResponse>
    {
        public int ProductId { get; set; }
        public int WarehouseId { get; set; }
        public int FiscalYearId { get; set; }
        public int ProductLocationId { get; set; }

        //تعداد تراکنش در انبار اصلی
        public int MainProductCount { get; set; }

        //تعداد تراکنش در انبار ضایعات
        public int WastageProductCount { get; set; }
        public string ExpireDate { get; set; }
        public string? AddBalanceStock { get; set; }
        public string OperationDate { get; set; }
        public string Description { get; set; }
        public int RefferenceID { get; set; }
        public OperationTypeStatus OperationType { get; set; }
    }
}
