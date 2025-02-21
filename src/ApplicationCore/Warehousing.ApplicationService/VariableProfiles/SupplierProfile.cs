using Warehousing.ApplicationService.Features.Suppliers.Commands.Create;
using Warehousing.ApplicationService.Features.Suppliers.Commands.Update;
using Warehousing.ApplicationService.ViewModels;
using Warehousing.Domain.Entities;

namespace Warehousing.ApplicationService.VariableProfiles
{
    public class SupplierProfile
    {
        public static GetSupplierResponseVM Map(Supplier command)
        {
            return new GetSupplierResponseVM
            {
                Id = command.Id,
                SupplierName = command.SupplierName,
                SupplerTel = command.SupplerTel,
                SupplerWebsite = command.SupplerWebsite
            };
        }

    }
}
