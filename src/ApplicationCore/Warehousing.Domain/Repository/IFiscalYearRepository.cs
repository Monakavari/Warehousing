using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Warehousing.ApplicationService.ViewModels;
using Warehousing.Common.Enums;
using Warehousing.Domain.Entities;
using Warehousing.Domain.Repository.Base;

namespace Warehousing.Domain.Repository
{
    public interface IFiscalYearRepository : IBaseRepository<FiscalYear>
    {
        Task<bool> IsExistFiscalYearName(string fiscalYearDescription, CancellationToken cancellationToken);
        Task<bool> CheckDateForFiscalYear(DateTime startDate, DateTime endDate);
        Task<List<GetDropDownListResponseDto>> FiscalYearListDropDown(CancellationToken cancellationToken);
        Task<FiscalYear> CheckFiscalYearStatus(int fiscalYearId, CancellationToken cancellationToken);
        Task<FiscalYear> GetCurrentFiscalYear(int fiscalYearId, CancellationToken cancellationToken);
        Task<FiscalYear> GetNewFiscalYear(int fiscalYearId, CancellationToken cancellationToken);
        Task<DateTime> GetLastEndDate(CancellationToken cancellationToken);
    }
}
