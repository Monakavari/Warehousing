using Warehousing.ApplicationService.Features.FiscalYear.Commands.Create;
using Warehousing.Common;
using Warehousing.Domain.Repository.Base;
using Warehousing.Domain.Repository;
using Warehousing.ApplicationService.VariableProfiles;
using Warehousing.Common.Utilities.Extensions;

namespace Warehousing.ApplicationService.Features.FiscalYear.CommandHandler
{
    public class CreateFiscalYearCommandHandler : MediatR.IRequestHandler<CreateFiscalYearCommand, ApiResponse>
    {
        #region Constructor
        private readonly IFiscalYearRepository _fiscalYearRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CreateFiscalYearCommandHandler(IFiscalYearRepository fiscalYearRepository,
                                              IUnitOfWork unitOfWork)
        {
            _fiscalYearRepository = fiscalYearRepository;
            _unitOfWork = unitOfWork;
        }
        #endregion
        public async Task<ApiResponse> Handle(CreateFiscalYearCommand request, CancellationToken cancellationToken)
        {
            if (await _fiscalYearRepository.IsExistFiscalYearName(request.FiscalYearDescription, cancellationToken))
                throw new AppException("عنوان نمی تواند تکراری باشد");

            if (!await _fiscalYearRepository.CheckDateForFiscalYear(PersianDate.ToMiladi(request.StartDate),
                                                                    PersianDate.ToMiladi(request.EndDate)))
                throw new AppException("تاریخ شروع یا پایان صحیح نمیباشد.");

            var mapper = FiscalYearProfile.Map(request);
            await _fiscalYearRepository.AddAsync(mapper, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new ApiResponse(true, ApiResponseStatusCode.Success, "عملیات با موفقیت انجام شد.");
        }
    }
}
