using Microsoft.AspNetCore.Identity;
using Warehousing.ApplicationService.Features.Users.Commands.Create;
using Warehousing.Common;
using Warehousing.Domain.Entities;
using Warehousing.Domain.Repository.Base;
using Warehousing.Domain.Repository;

namespace Warehousing.ApplicationService.Features.Users.CommandHandlers
{
    public class CreateUserAccessCommandHandler : MediatR.IRequestHandler<CreateUserAccessCommand, ApiResponse>
    {
        #region Constructor
        private readonly UserManager<ApplicationUsers> _userManager;
        public CreateUserAccessCommandHandler(UserManager<ApplicationUsers> userManager)
        {
            _userManager = userManager;
        }
        #endregion
        public async Task<ApiResponse> Handle(CreateUserAccessCommand request, CancellationToken cancellationToken)
        {
            var getUser = await _userManager.FindByIdAsync(request.UserIdAccess);
            //پیدا کردن رول های کاربر
            var roles = await _userManager.GetRolesAsync(getUser);
            //حذف همه رول های کاربر
            IdentityResult deleteAllrole = await _userManager.RemoveFromRolesAsync(getUser, roles);
            //ثبت مجدد دسترسی ها
            if (request.InvoiceList == "on") 
                          await _userManager.AddToRoleAsync(getUser, "InvoiceList");
            if (request.Inventory == "on") 
                          await _userManager.AddToRoleAsync(getUser, "Inventory");
            if (request.CreateInvoice == "on") 
                          await _userManager.AddToRoleAsync(getUser, "CreateInvoice");
            if (request.ProductFlow == "on") 
                          await _userManager.AddToRoleAsync(getUser, "ProductFlow");
            if (request.InvoiceSeparation == "on") 
                          await _userManager.AddToRoleAsync(getUser, "InvoiceSeparation");
            if (request.AllProductInvoiced == "on") 
                          await _userManager.AddToRoleAsync(getUser, "AllProductInvoiced");
            if (request.ProductLocation == "on") 
                          await _userManager.AddToRoleAsync(getUser, "ProductLocation");
            if (request.ProductPrice == "on") 
                          await _userManager.AddToRoleAsync(getUser, "ProductPrice");
            if (request.WareHousingHandle == "on") 
                          await _userManager.AddToRoleAsync(getUser, "WareHousingHandle");
            if (request.WastageRiallyStock == "on") 
                          await _userManager.AddToRoleAsync(getUser, "WastageRiallyStock");
            if (request.RiallyStock == "on") 
                          await _userManager.AddToRoleAsync(getUser, "RiallyStock");

            await _userManager.AddToRoleAsync(getUser, "user");

            return new ApiResponse(true, ApiResponseStatusCode.Success, "عملیات با موفقیت انجام شد.");
        }
    }
}
