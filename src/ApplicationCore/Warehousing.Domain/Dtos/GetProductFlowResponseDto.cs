using System;
using System.Net.NetworkInformation;

namespace Warehousing.Domain.Dtos
{
    public class GetProductFlowResponseDto
    {
        public OperationalStatus OperationType { get; set; }
        public string ExpireDate { get; set; }
        public string OperationDate { get; set; }
        public int MainProductCount { get; set; }
        public int WastageProductCount { get; set; }
        public string Description { get; set; }
        public string CreatorUserFullName { get; set; }
    }
}
