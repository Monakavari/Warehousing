using Warehousing.ApplicationService.Features.FiscalYear.Commands.Update;
using Warehousing.ApplicationService.VariableProfiles;
using Warehousing.Common;
using Warehousing.Common.Utilities.Extensions;
using Warehousing.Domain.Repository;
using Warehousing.Domain.Repository.Base;

namespace Warehousing.ApplicationService.Features.FiscalYear.CommandHandler
{
    public class UpdateFiscalYearCommandHandler : MediatR.IRequestHandler<UpdateFiscalYearCommand, ApiResponse>
    {
        #region Constructor
        private readonly IFiscalYearRepository _fiscalYearRepository;
        private readonly IUnitOfWork _unitOfWork;
        public UpdateFiscalYearCommandHandler(IFiscalYearRepository fiscalYearRepository,
                                              IUnitOfWork unitOfWork)
        {
            _fiscalYearRepository = fiscalYearRepository;
            _unitOfWork = unitOfWork;
        }
        #endregion Constructor
        public async Task<ApiResponse> Handle(UpdateFiscalYearCommand request, CancellationToken cancellationToken)
        {
            var data = await _fiscalYearRepository.GetByIdAsync(request.Id, cancellationToken);
            if (data is null)
                throw new AppException("محصول یافت نشد");

            if (data.FiscalYearDescription != request.FiscalYearDescription)
            {
                if (await _fiscalYearRepository.IsExistFiscalYearName(request.FiscalYearDescription, cancellationToken))
                    throw new AppException("عنوان نمی تواند تکراری باشد");
            }

            if (!await _fiscalYearRepository.CheckDateForFiscalYear(PersianDate.ToMiladi(request.StartDate),
                                                                    PersianDate.ToMiladi(request.EndDate)))
                throw new AppException("تاریخ شروع یا پایان صحیح نمیباشد.");

            FiscalYearProfile.Map(request);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new ApiResponse(true, ApiResponseStatusCode.Success, "عملیات با موفقیت انجام شد.");
        }
    }
}
