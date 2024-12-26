using MediatR;
using Warehousing.Common;
using Warehousing.Common.Enums;

namespace Warehousing.ApplicationService.Features.Inventories.Commands.Create
{
    public class CreateReturnedWastageProductCommand : IRequest<ApiResponse>
    {
        public int ReturnedWastageProductId { get; set; }
        public int ReturnedWastageWarehouseId { get; set; }
        public int ReturnedWastageFiscalYearId { get; set; }
        public int ReturnedWastageProductLocationId { get; set; }

        //تعداد تراکنش در انبار ضایعات
        public int ReturnedWastageProductCount { get; set; }
        public string ReturnedWastageExpireDate { get; set; }
        public string ReturnedWastageOperationDate { get; set; }
        public string ReturnedWastageDescription { get; set; }
        public int ReturnedWastageInvRefferenceId { get; set; }
        public OperationTypeStatus ReturnedOperationType { get; set; }
    }
}
