using Warehousing.ApplicationService.Features.FiscalYear.Commands.Create;
using Warehousing.ApplicationService.Features.FiscalYear.Commands.Update;
using Warehousing.ApplicationService.ViewModels;
using Warehousing.Common.Utilities.Extensions;
using Warehousing.Domain.Entities;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Warehousing.ApplicationService.VariableProfiles
{
    public class FiscalYearProfile
    {
        public static FiscalYear Map(CreateFiscalYearCommand command)
        {
            return new FiscalYear
            {
                StartDate = PersianDate.ToMiladi(command.StartDate),
                EndDate = PersianDate.ToMiladi(command.EndDate),
                FiscalYearDescription = command.FiscalYearDescription,
                FiscalFlag = command.FiscalFlag,
            };
        }
        public static GetFiscalYearResponseVM Map(FiscalYear command)
        {
            return new GetFiscalYearResponseVM
            {
                Id = command.Id,
                StartDate = PersianDate.ToShamsi(command.StartDate),
                EndDate = PersianDate.ToShamsi(command.EndDate),
                FiscalYearDescription = command.FiscalYearDescription,
                FiscalFlag = command.FiscalFlag,
            };
        }
        public static FiscalYear Map(UpdateFiscalYearCommand command)
        {
            return new FiscalYear
            {
                Id = command.Id,
                StartDate = PersianDate.ToMiladi(command.StartDate),
                EndDate = PersianDate.ToMiladi(command.EndDate),
                FiscalYearDescription = command.FiscalYearDescription,
                FiscalFlag = command.FiscalFlag,
            };
        }
    }
}
