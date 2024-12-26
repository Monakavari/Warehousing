using Azure.Core;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using Warehousing.ApplicationService.ViewModels;
using Warehousing.Common;
using Warehousing.Common.Enums;
using Warehousing.DataAccess.EF.Context;
using Warehousing.DataAccess.EF.Repositories.Base;
using Warehousing.Domain.Entities;
using Warehousing.Domain.Repository;

namespace Warehousing.DataAccess.EF.Repository
{
    public class FiscalYearRepository : BaseRepository<FiscalYear>, IFiscalYearRepository
    {
        #region Constructor
        private readonly WarehousingDbContext _dbContext;
        public FiscalYearRepository(WarehousingDbContext context) : base(context)
        {
            _dbContext = context;
        }
        #endregion Constructor
        public async Task<bool> IsExistFiscalYearName(string fiscalYearDescription, CancellationToken cancellationToken)
        {
            return await _dbContext.FiscalYears
                                       .Where(x => x.FiscalYearDescription == fiscalYearDescription)
                                       .AnyAsync(cancellationToken);
        }
        public async Task<bool> CheckDateForFiscalYear(DateTime startDate, DateTime endDate)
        {
            if (endDate <= startDate)
                throw new AppException("تاریخ پایان نمیتواند از تارخ شروع کمتر باشد.");

            if (startDate.Date <= await _dbContext.FiscalYears
                                                .Where(x => x.StartDate.Date != startDate.Date)
                                                .MaxAsync(x => x.EndDate.Date))
                throw new AppException("تاریخ شروع سال مالی باید از همه تاریخهای پایان قبلی بجز خودش بزرگتر باشد");

            if (endDate != startDate.AddYears(1).AddDays(-1))
                throw new AppException("سال مالی نمیتواند کمتر از یکسال باشد.");

            return true;
        }

        public async Task<List<GetDropDownListResponseDto>> FiscalYearListDropDown(CancellationToken cancellationToken)
        {
            return await _dbContext.FiscalYears
                                                   .Select(x => new GetDropDownListResponseDto
                                                   {
                                                       Id = x.Id,
                                                       Name = x.FiscalYearDescription
                                                   })
                                                   .ToListAsync(cancellationToken);
        }
        public async Task<FiscalYear> CheckFiscalYearStatus(int fiscalYearId, CancellationToken cancellationToken)
        {
            return await _dbContext.FiscalYears
                                        .Where(f => f.Id == fiscalYearId)
                                        .SingleOrDefaultAsync(cancellationToken);
        }
        public async Task<FiscalYear> GetCurrentFiscalYear(int fiscalYearId, CancellationToken cancellationToken)
        {
            return await _dbContext.FiscalYears
                                        .Where(x => x.Id == fiscalYearId)
                                        .SingleOrDefaultAsync(cancellationToken);
        }
        public async Task<FiscalYear> GetNewFiscalYear(int fiscalYearId, CancellationToken cancellationToken)
        {
            var lastEnddate = await _dbContext.FiscalYears
                                                    .Where(x => x.FiscalFlag == true)
                                                    .Select(x => x.EndDate)
                                                    .SingleOrDefaultAsync(cancellationToken);

            var newFiscalYearId = await _dbContext.FiscalYears
                                                          .Where(x => x.FiscalFlag == false &&
                                                                      x.StartDate > lastEnddate.Date)
                                                          .Select(x => x.Id)
                                                          .SingleOrDefaultAsync(cancellationToken);
            return await _dbContext.FiscalYears
                                        .Where(x => x.Id == newFiscalYearId)
                                        .SingleOrDefaultAsync(cancellationToken);
        }
        public async Task<DateTime> GetLastEndDate(CancellationToken cancellationToken)
        {
            return await _dbContext.FiscalYears
                                        .Where(x => x.FiscalFlag == true)
                                        .Select(x => x.EndDate)
                                        .SingleOrDefaultAsync(cancellationToken);
        }
    }
}
