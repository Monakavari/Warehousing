using Warehousing.ApplicationService.Features.FiscalYear.Commands.Delete;
using Warehousing.Common;
using Warehousing.Domain.Repository.Base;
using Warehousing.Domain.Repository;

namespace Warehousing.ApplicationService.Features.FiscalYear.CommandHandler
{
    public class DeleteFiscalYearCommandHandler : MediatR.IRequestHandler<DeleteFiscalYearCommand, ApiResponse>
    {
        #region Constructor
        private readonly IFiscalYearRepository _fiscalYearRepository;
        private readonly IUnitOfWork _unitOfWork;
        public DeleteFiscalYearCommandHandler(IFiscalYearRepository fiscalYearRepository,
                                              IUnitOfWork unitOfWork)
        {
            _fiscalYearRepository = fiscalYearRepository;
            _unitOfWork = unitOfWork;
        }
        #endregion
        public async Task<ApiResponse> Handle(DeleteFiscalYearCommand request, CancellationToken cancellationToken)
        {
            _fiscalYearRepository.DeleteById(request.Id);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new ApiResponse(true, ApiResponseStatusCode.Success, "عملیات با موفقیت انجام شد.");
        }
    }
}
