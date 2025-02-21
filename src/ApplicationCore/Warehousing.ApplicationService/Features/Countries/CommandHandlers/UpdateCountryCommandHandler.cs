using Microsoft.AspNetCore.Http;
using Warehousing.ApplicationService.Features.Countries.Commands.Update;
using Warehousing.ApplicationService.VariableProfiles;
using Warehousing.Common;
using Warehousing.Domain.Entities;
using Warehousing.Domain.Freamwork.Extensions;
using Warehousing.Domain.Repository;
using Warehousing.Domain.Repository.Base;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Warehousing.ApplicationService.Features.Countries.CommandHandlers
{
    public class UpdateCountryCommandHandler : MediatR.IRequestHandler<UpdateCountryCommand, ApiResponse>
    {
        #region Constructor
        private readonly ICountryRepository _countryRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private static string _userId = "0";
        public UpdateCountryCommandHandler(ICountryRepository countryRepository,
                                           IUnitOfWork unitOfWork)
        {
            _countryRepository = countryRepository;
            _userId = _httpContextAccessor.GetUserId();
            _unitOfWork = unitOfWork;
        }
        #endregion
        public async Task<ApiResponse> Handle(UpdateCountryCommand request, CancellationToken cancellationToken)
        {
            var data = await _countryRepository.GetByIdAsync(request.Id, cancellationToken);

            if (data is null)
                throw new AppException("محصول یافت نشد");

            data.CountryName = request.CountryName;
            data.ModifierUserId = _userId;
            data.UpdateDate = DateTime.Now;

            if (data.CountryName != request.CountryName )
            {
                if (await _countryRepository.IsExistCountryName(request.CountryName, cancellationToken))
                    throw new AppException("عنوان نمی تواند تکراری باشد");
            }
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new ApiResponse(true, ApiResponseStatusCode.Success, "عملیات با موفقیت انجام شد.");
        }
    }
}
