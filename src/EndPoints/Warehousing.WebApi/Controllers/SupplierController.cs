using MediatR;
using Microsoft.AspNetCore.Mvc;
using Warehousing.ApplicationService.Features.Suppliers.Commands.Create;
using Warehousing.ApplicationService.Features.Suppliers.Commands.Delete;
using Warehousing.ApplicationService.Features.Suppliers.Commands.Update;
using Warehousing.ApplicationService.Features.Suppliers.Queries;
using Warehousing.WebApi.Infrastructure;

namespace Warehousing.WebApi.Controllers
{
    public class SupplierController : BaseController
    {
        #region Constructor
        public SupplierController(IMediator mediator) : base(mediator)
        {
        }
        #endregion Constructor

        #region Queries
        [HttpGet("id")]
        public async Task<IActionResult> GetSupplierById(int id, CancellationToken cancellationToken)
        {
            var command = new GetSupplierDetailQuery { Id = id };
            var result = await Mediator.Send(command, cancellationToken);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSuppliers(CancellationToken cancellationToken)
        {
            var command = new GetsupplierListQuery();
            var result = await Mediator.Send(command, cancellationToken);
            return Ok(result);
        }
        #endregion Queries

        #region Command
        [HttpPost]
        public async Task<IActionResult> CreateSupplier([FromBody] CreateSupplierCommand request, CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(request, cancellationToken);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSupplier([FromBody] UpdateSupplierCommand request, CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(request, cancellationToken);
            return Ok(result);
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteSupplier(int id, CancellationToken cancellationToken)
        {
            var command = new DeleteSupplierCommand { Id = id };
            var result = await Mediator.Send(command, cancellationToken);
            return Ok(result);
        }
        #endregion Command
    }
}
