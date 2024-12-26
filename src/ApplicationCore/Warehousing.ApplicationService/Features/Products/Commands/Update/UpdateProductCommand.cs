using MediatR;
using Warehousing.Common;
using Warehousing.Common.Enums;
using Warehousing.Domain.Entities;

namespace Warehousing.ApplicationService.Features.Product.Commands.Update
{
    public class UpdateProductCommand : IRequest<ApiResponse>
    {
        public int Id { get; set; }
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
