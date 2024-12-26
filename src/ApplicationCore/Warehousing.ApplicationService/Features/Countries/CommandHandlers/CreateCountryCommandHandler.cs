using Warehousing.ApplicationService.Features.Countries.Commands.Create;
using Warehousing.Common;
using Warehousing.Domain.Entities;
using Warehousing.Domain.Repository;
using Warehousing.Domain.Repository.Base;

namespace Warehousing.ApplicationService.Features.Countries.CommandHandlers
{
    public class CreateCountryCommandHandler : MediatR.IRequestHandler<CreateCountryCommand, ApiResponse>
    {
        #region Constructor
        private readonly ICountryRepository _countryRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CreateCountryCommandHandler(ICountryRepository countryRepository,
                                           IUnitOfWork unitOfWork)
        {
            _countryRepository = countryRepository;
            _unitOfWork = unitOfWork;
        }
        #endregion
        public async Task<ApiResponse> Handle(CreateCountryCommand request, CancellationToken cancellationToken)
        {
            if (await _countryRepository.IsExistCountryName(request.CountryName, cancellationToken))
                throw new AppException("عنوان نمی تواند تکراری باشد");

            var country = new Country
            {
                CountryName = request.CountryName
            };

            await _countryRepository.AddAsync(country, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new ApiResponse(true, ApiResponseStatusCode.Success, "عملیات با موفقیت انجام شد.");
        }
    }
}
