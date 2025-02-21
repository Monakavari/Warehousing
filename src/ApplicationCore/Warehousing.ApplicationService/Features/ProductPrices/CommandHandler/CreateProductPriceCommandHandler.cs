using MediatR;
using Warehousing.ApplicationService.Features.ProductPrice.Commands;
using Warehousing.ApplicationService.VariableProfiles;
using Warehousing.Common;
using Warehousing.Domain.Repository.Base;
using Warehousing.Domain.Repository;
using Microsoft.AspNetCore.Http;
using Warehousing.Domain.Freamwork.Extensions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Warehousing.Common.Utilities.Extensions;

namespace Warehousing.ApplicationService.Features.ProductPrice.CommandHandler
{
    public class CreateProductPriceCommandHandler : IRequestHandler<CreateProductPriceCommand, ApiResponse>
    {
        #region Constructor
        private readonly IProductPriceRepository _productPriceRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private static string _userId = "0";
        public CreateProductPriceCommandHandler(IProductPriceRepository productPriceRepository,
                                             IUnitOfWork unitOfWork)
        {
            _productPriceRepository = productPriceRepository;
            _userId = _httpContextAccessor.GetUserId();
            _unitOfWork = unitOfWork;
        }
        #endregion
        public async Task<ApiResponse> Handle(CreateProductPriceCommand request, CancellationToken cancellationToken)
        {
            if (await _productPriceRepository.GetProductPrice(request.ProductId, cancellationToken))
                throw new AppException("تاریخ شروع قیمت تکراریست.");

            var price = new Warehousing.Domain.Entities.ProductPrice
            {
                ProductId = request.ProductId,
                FiscalYearId = request.FiscalYearId,
                ActionDate = PersianDate.ToMiladi(request.ActionDate),
                CoverPrice = request.CoverPrice,
                PurchasePrice = request.PurchasePrice,
                SalesPrice = request.SalesPrice,
                CreatorUserId = _userId
            };
            await _productPriceRepository.AddAsync(price, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new ApiResponse(true, ApiResponseStatusCode.Success, "عملیات با موفقیت انجام شد.");
        }
    }
}
