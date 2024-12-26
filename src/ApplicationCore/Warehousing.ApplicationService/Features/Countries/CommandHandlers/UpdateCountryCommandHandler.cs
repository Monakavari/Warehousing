using Warehousing.ApplicationService.Features.Countries.Commands.Update;
using Warehousing.ApplicationService.VariableProfiles;
using Warehousing.Common;
using Warehousing.Domain.Repository;
using Warehousing.Domain.Repository.Base;

namespace Warehousing.ApplicationService.Features.Countries.CommandHandlers
{
    public class UpdateCountryCommandHandler : MediatR.IRequestHandler<UpdateCountryCommand, ApiResponse>
    {
        #region Constructor
        private readonly ICountryRepository _countryRepository;
        private readonly IUnitOfWork _unitOfWork;
        public UpdateCountryCommandHandler(ICountryRepository countryRepository,
                                           IUnitOfWork unitOfWork)
        {
            _countryRepository = countryRepository;
            _unitOfWork = unitOfWork;
        }
        #endregion
        public async Task<ApiResponse> Handle(UpdateCountryCommand request, CancellationToken cancellationToken)
        {
            var data = await _countryRepository.GetByIdAsync(request.Id, cancellationToken);

            if (data is null)
                throw new AppException("محصول یافت نشد");

            if (await _countryRepository.IsExistCountryName(request.CountryName, cancellationToken))
                throw new AppException("عنوان نمی تواند تکراری باشد");

            CountryProfile.Map(data);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new ApiResponse(true, ApiResponseStatusCode.Success, "عملیات با موفقیت انجام شد.");
        }
    }
}
