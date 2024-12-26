using MediatR;
using Warehousing.ApplicationService.Features.Countries.Queries;
using Warehousing.ApplicationService.VariableProfiles;
using Warehousing.ApplicationService.ViewModels;
using Warehousing.Common;
using Warehousing.Domain.Repository;

namespace Warehousing.ApplicationService.Features.Countries.QueryHandlers
{
    public class GetCountryDetailQueryHandler : IRequestHandler<GetCountryDetailQuery, ApiResponse<GetCountryResponseVM>>
    {
        #region Constructor
        private readonly ICountryRepository _countryRepository;
        public GetCountryDetailQueryHandler(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }
        #endregion Constructor

        public async Task<ApiResponse<GetCountryResponseVM>> Handle(GetCountryDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = await _countryRepository.GetByIdAsync(request.Id, cancellationToken);
            var mapper = CountryProfile.Map(entity);

            return new ApiResponse<GetCountryResponseVM>(true, ApiResponseStatusCode.Success, mapper, "عملیات با موفقیت انجام شد");
        }
    }
}
