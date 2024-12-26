using MediatR;
using Microsoft.AspNetCore.Mvc;
using Warehousing.ApplicationService.Features.Product.Commands.Create;
using Warehousing.ApplicationService.Features.Product.Commands.Delete;
using Warehousing.ApplicationService.Features.Product.Commands.Update;
using Warehousing.ApplicationService.Features.Product.Queries;
using Warehousing.WebApi.Infrastructure;

namespace Warehousing.WebApi.Controllers
{
    public class ProductController : BaseController
    {
        #region Constructor
        public ProductController(IMediator mediator) : base(mediator)
        {
        }
        #endregion Constructor

        #region Queries
        [HttpGet("id")]
        public async Task<IActionResult> GetProductById(int id, CancellationToken cancellationToken)
        {
            var command = new GetProductDetailQuery { Id = id };
            var result = await Mediator.Send(command, cancellationToken);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts(CancellationToken cancellationToken)
        {
            var command = new GetProductListQuery();
            var result = await Mediator.Send(command, cancellationToken);
            return Ok(result);
        }
        #endregion Queries

        #region Command
        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductCommand request, CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(request, cancellationToken);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(request, cancellationToken);
            return Ok(result);
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteProduct(int id, CancellationToken cancellationToken)
        {
            var command = new DeleteProductCommand { Id = id };
            var result = await Mediator.Send(command, cancellationToken);
            return Ok(result);
        }
        #endregion Command
    }
}
