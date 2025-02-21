using MediatR;
using Microsoft.AspNetCore.Mvc;
using Warehousing.ApplicationService.Features.Customers.Queries;
using Warehousing.ApplicationService.Features.Inventories.CommandHandlers;
using Warehousing.ApplicationService.Features.Inventories.Commands.Create;
using Warehousing.ApplicationService.Features.Inventories.Queries;
using Warehousing.ApplicationService.Features.Inventory.CommandHandlers;
using Warehousing.ApplicationService.Features.Inventory.Commands.Create;
using Warehousing.ApplicationService.Features.Inventory.Commands.CreateExit;
using Warehousing.ApplicationService.Features.Inventory.Queries;
using Warehousing.WebApi.Infrastructure;

namespace Warehousing.WebApi.Controllers
{
    public class InventoryController : BaseController
    {
        #region Constructor
        public InventoryController(IMediator mediator) : base(mediator)
        {
        }
        #endregion Constructor

        #region Queries

        [HttpGet]
        public async Task<IActionResult> GetProductStock(GetProductStockListQuery request, CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(request, cancellationToken);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetProductListExpireOriented(ProductListExpireOrientedQuery request, CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(request, cancellationToken);
            return Ok(result);
        }
        #endregion Queries

        #region Command

        [HttpPost]
        public async Task<IActionResult> AddProductStock([FromBody] CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(request, cancellationToken);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddWastageProductStock([FromBody] AddWastageProductStockCommand request, CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(request, cancellationToken);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateExitProductFromInventory([FromBody] CreateExitProductFromInventoryCommand request, CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(request, cancellationToken);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateReturnWastageProduct([FromBody] CreateReturnedWastageProductCommand request, CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(request, cancellationToken);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTransferItemsToNewFiscalYear([FromBody] TransferItemsToNewFiscalYearRequestCommand request, CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(request, cancellationToken);
            return Ok(result);
        }

        #endregion Command
    }
}
