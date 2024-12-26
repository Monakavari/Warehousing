using MediatR;
using Warehousing.Common;
using Warehousing.Common.Enums;

namespace Warehousing.ApplicationService.Features.Inventory.Commands.Create
{
    public class AddWastageProductStockCommand:IRequest<ApiResponse>
    {
        public int WastageProductId { get; set; }
        public int WastageWarehouseId { get; set; }
        public int WastageFiscalYearId { get; set; }
        public int WastageProductLocationId { get; set; }

        //تعداد تراکنش در انبار ضایعات
        public int WastageProductCount { get; set; }
        public string WastageExpireDate { get; set; }
        public string WastageOperationDate { get; set; }
        public string WastageDescription { get; set; }
        public int WastageInvRefferenceId { get; set; }
        public OperationTypeStatus WastageOperationType { get; set; }
    }
}
