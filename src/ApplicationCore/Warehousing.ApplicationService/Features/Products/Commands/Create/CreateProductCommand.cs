using MediatR;
using Warehousing.Common;
using Warehousing.Common.Enums;

namespace Warehousing.ApplicationService.Features.Product.Commands.Create
{
    public class CreateProductCommand : IRequest<ApiResponse>
    {
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public PackingType PackingType { get; set; }
        public int CountInPacking { get; set; }
        public int ProductWeight { get; set; }
        public string ProductImage { get; set; }
        //1=یخچالی
        //2=غیریخچالی
        public bool IsRefregrator { get; set; }
        public int SupplierId { get; set; }
        public int CountryId { get; set; }
    }
}
