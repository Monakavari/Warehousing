using Warehousing.ApplicationService.Services.Contracts;
using Warehousing.Common;
using Warehousing.Domain.Repository.Base;
using Warehousing.Domain.Repository;
using Warehousing.ApplicationService.Features.Invoices.Commands.Delete;

namespace Warehousing.ApplicationService.Features.Invoices.CommandHandlers
{
    public class DeleteTemporaryInvoiceCommandHandler : MediatR.IRequestHandler<DeleteTemporaryInvoiceCommand, ApiResponse>
    {
        #region Constructor
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IInvoiceItemRepository _invoiceItemRepository;
        private readonly IUnitOfWork _unitOfWork;
        public DeleteTemporaryInvoiceCommandHandler(IInvoiceRepository invoiceRepository,
                                                    IUnitOfWork unitOfWork,
                                                    IInvoiceItemRepository invoiceItemRepository)
        {
            _invoiceRepository = invoiceRepository;
            _unitOfWork = unitOfWork;
            _invoiceItemRepository = invoiceItemRepository;
        }
        #endregion Constructor
        public async Task<ApiResponse> Handle(DeleteTemporaryInvoiceCommand request, CancellationToken cancellationToken)
        {
            if (request.InvoiceId == 0)
                throw new AppException("اینویس مورد نظر را انتخاب کنید.");

            await _unitOfWork.BeginTransactionAsync(cancellationToken);

            //Remove InvoiceItem Rows
            var invoiceItemIds = await _invoiceItemRepository.GetInvoiceItemIds(request.InvoiceId, cancellationToken);
            _invoiceItemRepository.DeleteRange(invoiceItemIds);

            //Remove Invoice
            _invoiceRepository.DeleteById(request.InvoiceId);

            await _unitOfWork.SaveChangesAsync(cancellationToken);
            await _unitOfWork.TransactionCommit(cancellationToken);

            return new ApiResponse(true, ApiResponseStatusCode.Success, "عملیات با موفقیت انجام شد.");
        }
    }
}
