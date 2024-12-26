using MediatR;
using Microsoft.AspNetCore.Mvc;
using Warehousing.ApplicationService.Features.Product.Commands.Create;
using Warehousing.ApplicationService.Features.Product.Commands.Delete;
using Warehousing.ApplicationService.Features.Product.Commands.Update;
using Warehousing.ApplicationService.Features.Product.Queries;
using Warehousing.ApplicationService.Features.ProductPrice.Commands;
using Warehousing.ApplicationService.Features.ProductPrice.Commands.Delete;
using Warehousing.ApplicationService.Features.ProductPrice.Queries;
using Warehousing.WebApi.Infrastructure;

namespace Warehousing.WebApi.Controllers
{
    public class ProductPriceController : BaseController
    {
        #region Constructor
        public ProductPriceController(IMediator mediator) : base(mediator)
        {
        }
        #endregion Constructor

        #region Queries
        [HttpGet("id")]
        public async Task<IActionResult> GetProductPriceDetail(int Id, CancellationToken cancellationToken)
        {
            var command = new GetProductPriceDetailQuery { Id = Id };
            var result = await Mediator.Send(command, cancellationToken);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetProductPriceList(CancellationToken cancellationToken)
        {
            var command = new GetProductPriceListQuery();
            var result = await Mediator.Send(command, cancellationToken);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetProductPriceHistory(int ProductId,CancellationToken cancellationToken)
        {
            var command = new GetProductPriceHistoryQuery { ProductId = ProductId }; ;
            var result = await Mediator.Send(command, cancellationToken);
            return Ok(result);
        }
        #endregion Queries

        #region Command
        [HttpPost]
        public async Task<IActionResult> CreateProductPrice([FromBody] CreateProductPriceCommand request, CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(request, cancellationToken);
            return Ok(result);
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteProduct(int id, CancellationToken cancellationToken)
        {
            var command = new DeleteProductPriceCommand { Id = id };
            var result = await Mediator.Send(command, cancellationToken);
            return Ok(result);
        }
        #endregion Command
    }
}
