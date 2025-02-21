using MediatR;
using Microsoft.AspNetCore.Mvc;
using Warehousing.ApplicationService.Features.Product.Commands.Create;
using Warehousing.ApplicationService.Features.Product.Commands.Delete;
using Warehousing.ApplicationService.Features.Product.Commands.Update;
using Warehousing.ApplicationService.Features.Product.Queries;
using Warehousing.ApplicationService.Features.ProductLocation.Commands.Create;
using Warehousing.ApplicationService.Features.ProductLocation.Commands.Delete;
using Warehousing.ApplicationService.Features.ProductLocation.Commands.Update;
using Warehousing.ApplicationService.Features.ProductLocation.Queries;
using Warehousing.WebApi.Infrastructure;

namespace Warehousing.WebApi.Controllers
{
    public class ProductLocationController : BaseController
    {
        #region Constructor
        public ProductLocationController(IMediator mediator) : base(mediator)
        {
        }
        #endregion Constructor

        #region Queries

        [HttpGet("warehouseId")]
        public async Task<IActionResult> GetProductLocationById(int warehouseId, CancellationToken cancellationToken)
        {
            var command = new GetProductLocationListQuery { WarehouseId = warehouseId };
            var result = await Mediator.Send(command, cancellationToken);
            return Ok(result);
        }

        [HttpGet("warehouseId")]
        public async Task<IActionResult> GetProductLocationList(int warehouseId, CancellationToken cancellationToken)
        {
            var command = new GetProductLocationListQuery { WarehouseId = warehouseId };
            var result = await Mediator.Send(command, cancellationToken);
            return Ok(result);
        }

        #endregion Queries

        #region Command
        [HttpPost]
        public async Task<IActionResult> CreateProductLocation([FromBody] CreateProductLocationCommand request, CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(request, cancellationToken);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProductLocation([FromBody] UpdateProductLocationCommand request, CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(request, cancellationToken);
            return Ok(result);
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteProductLocation(int id, CancellationToken cancellationToken)
        {
            var command = new DeleteProductLocationCommand { Id = id };
            var result = await Mediator.Send(command, cancellationToken);
            return Ok(result);
        }
        #endregion Command
    }
}
