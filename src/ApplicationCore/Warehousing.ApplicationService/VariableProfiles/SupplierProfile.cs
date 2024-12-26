using Warehousing.ApplicationService.Features.Suppliers.Commands.Create;
using Warehousing.ApplicationService.Features.Suppliers.Commands.Update;
using Warehousing.ApplicationService.ViewModels;
using Warehousing.Domain.Entities;

namespace Warehousing.ApplicationService.VariableProfiles
{
    public class SupplierProfile
    {
        public static Supplier Map(CreateSupplierCommand command)
        {
            return new Supplier
            {
                SupplierName = command.SupplierName,
                SupplerTel = command.SupplerTel,
                SupplerWebsite = command.SupplerWebsite,
                //CreatorUserId = command.CreatorUserId
            };
        }
        public static Supplier Map(UpdateSupplierCommand command)
        {
            return new Supplier
            {
                Id = command.Id,
                UpdateDate = DateTime.Now,
                SupplierName = command.SupplierName,
                SupplerTel = command.SupplerTel,
                SupplerWebsite = command.SupplerWebsite,
                //data.ModifierUserId = request.CountryName;
            };
        }

        public static GetSupplierResponseVM Map(Supplier command)
        {
            return new GetSupplierResponseVM
            {
                Id = command.Id,
                SupplierName = command.SupplierName,
                SupplerTel= command.SupplerTel,
                SupplerWebsite= command.SupplerWebsite
            };
        }

    }
}
