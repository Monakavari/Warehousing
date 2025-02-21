using Microsoft.AspNetCore.Http;
using Warehousing.ApplicationService.Features.FiscalYear.Commands.Update;
using Warehousing.ApplicationService.VariableProfiles;
using Warehousing.Common;
using Warehousing.Common.Utilities.Extensions;
using Warehousing.Domain.Freamwork.Extensions;
using Warehousing.Domain.Repository;
using Warehousing.Domain.Repository.Base;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Warehousing.ApplicationService.Features.FiscalYear.CommandHandler
{
    public class UpdateFiscalYearCommandHandler : MediatR.IRequestHandler<UpdateFiscalYearCommand, ApiResponse>
    {
        #region Constructor
        private readonly IFiscalYearRepository _fiscalYearRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private static string _userId = "0";
        public UpdateFiscalYearCommandHandler(IFiscalYearRepository fiscalYearRepository,
                                              IUnitOfWork unitOfWork)
        {
            _fiscalYearRepository = fiscalYearRepository;
            _userId = _httpContextAccessor.GetUserId();
            _unitOfWork = unitOfWork;
        }
        #endregion Constructor
        public async Task<ApiResponse> Handle(UpdateFiscalYearCommand request, CancellationToken cancellationToken)
        {
            var data = await _fiscalYearRepository.GetByIdAsync(request.Id, cancellationToken);
            if (data is null)
                throw new AppException("محصول یافت نشد");

                data.StartDate = PersianDate.ToMiladi(request.StartDate);
                data.EndDate = PersianDate.ToMiladi(request.EndDate);
                data.FiscalYearDescription = request.FiscalYearDescription;
                data.FiscalFlag = request.FiscalFlag;
                data.ModifierUserId = _userId;
                data.UpdateDate = DateTime.Now;

            if (data.FiscalYearDescription != request.FiscalYearDescription) 
            {
                if (await _fiscalYearRepository.IsExistFiscalYearName(request.FiscalYearDescription, cancellationToken))
                    throw new AppException("عنوان نمی تواند تکراری باشد");
            }

            if (!await _fiscalYearRepository.CheckDateForFiscalYear(PersianDate.ToMiladi(request.StartDate),
                                                                    PersianDate.ToMiladi(request.EndDate)))
                throw new AppException("تاریخ شروع یا پایان صحیح نمیباشد.");

            
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new ApiResponse(true, ApiResponseStatusCode.Success, "عملیات با موفقیت انجام شد.");
        }
    }
}
