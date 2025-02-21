using MediatR;
using Microsoft.AspNetCore.Mvc;
using Warehousing.ApplicationService.Features.Inventories.Commands.Create;
using Warehousing.ApplicationService.Features.Inventories.Queries;
using Warehousing.ApplicationService.Features.Inventory.Commands.Create;
using Warehousing.ApplicationService.Features.Inventory.Commands.CreateExit;
using Warehousing.ApplicationService.Features.Inventory.Queries;
using Warehousing.ApplicationService.Features.Invoices.CommandHandlers;
using Warehousing.ApplicationService.Features.Invoices.Commands.Create;
using Warehousing.ApplicationService.Features.Invoices.Queries;
using Warehousing.ApplicationService.Features.Invoices.QueryHandler;
using Warehousing.Domain.Entities;
using Warehousing.WebApi.Infrastructure;

namespace Warehousing.WebApi.Controllers
{
    public class InvoiceController : BaseController
    {
        #region Constructor
        public InvoiceController(IMediator mediator) : base(mediator)
        {
        }
        #endregion Constructor

        #region Queries

        [HttpGet]
        public async Task<IActionResult> GetAllInvoicedProduct(GetAllInvoicedProductQuery request, CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(request, cancellationToken);
            return Ok(result);
        }

        [HttpGet("invoiceId")]
        public async Task<IActionResult> GetInvoiceItemListInfo(int invoiceId, CancellationToken cancellationToken)
        {
            var command = new GetInvoiceItemListInfoQuery { InvoiceId = invoiceId };
            var result = await Mediator.Send(command, cancellationToken);
            return Ok(result);
        }

        [HttpGet("invoiceId")]
        public async Task<IActionResult> GetInvoiceItemsForPrint(int invoiceId, CancellationToken cancellationToken)
        {
            var command = new GetInvoiceItemsForPrintQuery { InvoiceId = invoiceId };
            var result = await Mediator.Send(command, cancellationToken);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetItemReportOfAnyInvoiceList(GetItemReportOfAnyInvoiceListQuery request, CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(request, cancellationToken);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetProductItemInfoDetail(GetProductItemInfoDetailQuery request, CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(request, cancellationToken);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetSoldAndReturnedInvoiceListForAnyWarehouse(GetInvoiceFullInfoListQuery request, CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(request, cancellationToken);
            return Ok(result);
        }
        #endregion Queries

        #region Command

        [HttpPost]
        public async Task<IActionResult> CreateInvoiceCommandHandler([FromBody] CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(request, cancellationToken);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateReturnedInvoiceCommandHandler([FromBody] CreateReturnedInvoiceCommand request, CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(request, cancellationToken);
            return Ok(result);
        }

        [HttpDelete("invoiceId")]
        public async Task<IActionResult> DeleteTemporaryInvoice(int invoiceId, CancellationToken cancellationToken)
        {
            var command = new DeleteTemporaryInvoiceCommand { InvoiceId = invoiceId };
            var result = await Mediator.Send(command, cancellationToken);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> SetInvoiceToClose([FromBody] SetInvoiceToCloseCommand request, CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(request, cancellationToken);
            return Ok(result);
        }

        #endregion Command
    }
}
