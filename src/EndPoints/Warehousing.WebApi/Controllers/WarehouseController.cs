using MediatR;
using Microsoft.AspNetCore.Mvc;
using Warehousing.ApplicationService.Features.Warehouse.Commands.Create;
using Warehousing.ApplicationService.Features.Warehouse.Commands.Delete;
using Warehousing.ApplicationService.Features.Warehouse.Commands.Update;
using Warehousing.ApplicationService.Features.Warehouse.Queries;
using Warehousing.ApplicationService.Features.Warehouses.Queries;
using Warehousing.ApplicationService.Features.Warehouses.QueryHandlers;
using Warehousing.WebApi.Infrastructure;

namespace Warehousing.WebApi.Controllers
{
    public class WarehouseController : BaseController
    {
        #region Constructor
        public WarehouseController(IMediator mediator) : base(mediator)
        {
        }
        #endregion Constructor

        #region Queries

        [HttpGet]
        public async Task<IActionResult> GetProductFlow(GetProductFlowListQuery request,CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(request, cancellationToken);
            return Ok(result);
        }
        [HttpGet("id")]
        public async Task<IActionResult> GetWarehouseById(int id, CancellationToken cancellationToken)
        {
            var command = new GetWarehouseDetailQuery { Id = id };
            var result = await Mediator.Send(command, cancellationToken);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllWarehouses(CancellationToken cancellationToken)
        {
            var command = new GetWarehouseListQuery();
            var result = await Mediator.Send(command, cancellationToken);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetMainRialiStock(GetMainRialyStockOfEachWarhouseListQuery request, CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(request, cancellationToken);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetWastageRialiStock(GetWastageRialyStockOfEachWarhouseListQuery request, CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(request, cancellationToken);
            return Ok(result);
        }
        #endregion Queries

        #region Command
        [HttpPost]
        public async Task<IActionResult> CreateWarehouse([FromBody] CreateWarehouseCommand request, CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(request, cancellationToken);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateWarehouse([FromBody] UpdateWarehouseCommand request, CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(request, cancellationToken);
            return Ok(result);
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteWarehouse(int id, CancellationToken cancellationToken)
        {
            var command = new DeleteWarehouseCommand { Id = id };
            var result = await Mediator.Send(command, cancellationToken);
            return Ok(result);
        }
        #endregion Command
    }
}
