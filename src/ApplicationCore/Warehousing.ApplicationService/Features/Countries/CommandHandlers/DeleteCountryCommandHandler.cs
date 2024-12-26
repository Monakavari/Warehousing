using Warehousing.ApplicationService.Features.Countries.Commands.Delete;
using Warehousing.Common;
using Warehousing.Domain.Repository;
using Warehousing.Domain.Repository.Base;

namespace Warehousing.ApplicationService.Features.Countries.CommandHandlers
{
    public class DeleteCountryCommandHandler : MediatR.IRequestHandler<DeleteCountryCommand, ApiResponse>
    {
        #region Constructor
        private readonly ICountryRepository _countryRepository;
        private readonly IUnitOfWork _unitOfWork;
        public DeleteCountryCommandHandler(ICountryRepository countryRepository,
                                           IUnitOfWork unitOfWork)
        {
            _countryRepository = countryRepository;
            _unitOfWork = unitOfWork;
        }
        #endregion
        public async Task<ApiResponse> Handle(DeleteCountryCommand request, CancellationToken cancellationToken)
        {
            _countryRepository.DeleteById(request.Id);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new ApiResponse(true, ApiResponseStatusCode.Success, "عملیات با موفقیت انجام شد.");
        }

    }
}
