using Warehousing.ApplicationService.Features.FiscalYear.Commands.Create;
using Warehousing.Common;
using Warehousing.Domain.Repository.Base;
using Warehousing.Domain.Repository;
using Warehousing.ApplicationService.VariableProfiles;
using Warehousing.Common.Utilities.Extensions;
using Microsoft.AspNetCore.Http;
using Warehousing.Domain.Freamwork.Extensions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Warehousing.Domain.Entities;

namespace Warehousing.ApplicationService.Features.FiscalYear.CommandHandler
{
    public class CreateFiscalYearCommandHandler : MediatR.IRequestHandler<CreateFiscalYearCommand, ApiResponse>
    {
        #region Constructor
        private readonly IFiscalYearRepository _fiscalYearRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private static string _userId = "0";
        public CreateFiscalYearCommandHandler(IFiscalYearRepository fiscalYearRepository,
                                              IUnitOfWork unitOfWork)
        {
            _fiscalYearRepository = fiscalYearRepository;
            _userId = _httpContextAccessor.GetUserId();
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

            var fiscal = new Warehousing.Domain.Entities.FiscalYear
            {
                StartDate = PersianDate.ToMiladi(request.StartDate),
                EndDate = PersianDate.ToMiladi(request.EndDate),
                FiscalYearDescription = request.FiscalYearDescription,
                FiscalFlag = request.FiscalFlag,
                CreatorUserId = _userId,
            };
            var mapper = FiscalYearProfile.Map(request);
            await _fiscalYearRepository.AddAsync(mapper, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new ApiResponse(true, ApiResponseStatusCode.Success, "عملیات با موفقیت انجام شد.");
        }
    }
}
