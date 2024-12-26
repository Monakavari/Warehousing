using MediatR;
using Warehousing.Common.Enums;
using Warehousing.Common;

namespace Warehousing.ApplicationService.Features.Inventory.Commands.CreateExit
{
    public class CreateExitProductFromInventoryCommand : IRequest<ApiResponse>
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

        //تاریخ خروج کالا از انبار
        public string OperationDate { get; set; }
        public string Description { get; set; }
        public string? BalanceStockRemove { get; set; }
        public int RefferenceInventoryId { get; set; }
        public OperationTypeStatus OperationType { get; set; }
    }
}
