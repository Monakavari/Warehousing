using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Warehousing.ApplicationService.ViewModels;
using Warehousing.Domain.Entities;
using Warehousing.Domain.Repository.Base;

namespace Warehousing.Domain.Repository
{
    public interface ICountryRepository : IBaseRepository<Country>
    {
        Task<bool> IsExistCountryName(string countryName, CancellationToken cancellationToken);
        Task<List<GetDropDownListResponseDto>> CountryListDropDown(CancellationToken cancellationToken);
    }
}
