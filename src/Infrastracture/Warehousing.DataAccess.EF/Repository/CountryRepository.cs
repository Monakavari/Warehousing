using Microsoft.EntityFrameworkCore;
using Warehousing.ApplicationService.ViewModels;
using Warehousing.DataAccess.EF.Context;
using Warehousing.DataAccess.EF.Repositories.Base;
using Warehousing.Domain.Entities;
using Warehousing.Domain.Repository;

namespace Warehousing.DataAccess.EF.Repository
{
    public class CountryRepository : BaseRepository<Country>, ICountryRepository
    {
        #region Constructor

        private readonly WarehousingDbContext _dbContext;
        public CountryRepository(WarehousingDbContext context) : base(context)
        {
            _dbContext = context;
        }
        #endregion Constructor
        public async Task<bool> IsExistCountryName(string countryName, CancellationToken cancellationToken)
        {
            return await _dbContext.Countries
                                       .Where(x => x.CountryName == countryName)
                                       .AnyAsync(cancellationToken);
        }
        public async Task<List<GetDropDownListResponseDto>> CountryListDropDown(CancellationToken cancellationToken)
        {
            return await _dbContext.Countries
                                        .Select(x => new GetDropDownListResponseDto
                                        {
                                            Id = x.Id,
                                            Name = x.CountryName
                                        })
                                        .ToListAsync(cancellationToken);
        }
    }
}
