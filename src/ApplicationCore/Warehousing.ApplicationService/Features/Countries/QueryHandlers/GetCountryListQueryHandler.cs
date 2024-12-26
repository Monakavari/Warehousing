using MediatR;
using Microsoft.EntityFrameworkCore;
using Warehousing.ApplicationService.Features.Countries.Queries;
using Warehousing.ApplicationService.ViewModels;
using Warehousing.Common;
using Warehousing.Domain.Repository;

namespace Warehousing.ApplicationService.Features.Countries.QueryHandlers
{
    public class GetCountryListQueryHandler : IRequestHandler<GetCountryListQuery, ApiResponse<List<GetCountryResponseVM>>>
    {
        #region Constructor
        private readonly ICountryRepository _countryRepository;
        public GetCountryListQueryHandler(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }
        #endregion Constructor
        public async Task<ApiResponse<List<GetCountryResponseVM>>> Handle(GetCountryListQuery request, CancellationToken cancellationToken)
        {
            var data = await _countryRepository.FetchIQueryableEntity()
                                                .Select(x => new GetCountryResponseVM
                                                {
                                                    Id = x.Id,
                                                    Name = x.CountryName
                                                }).ToListAsync(cancellationToken);

            return new ApiResponse<List<GetCountryResponseVM>>(true, ApiResponseStatusCode.Success, data, "عملیات با موفقیت انجام شد");
        }
    }
}
