using MediatR;
using Microsoft.AspNetCore.Mvc;
using Warehousing.ApplicationService.Features.Customers.Commands.Delete;
using Warehousing.ApplicationService.Features.Customers.Commands.Update;
using Warehousing.ApplicationService.Features.Customers.Queries;
using Warehousing.ApplicationService.Features.FiscalYear.Commands.Create;
using Warehousing.ApplicationService.Features.FiscalYear.Commands.Delete;
using Warehousing.ApplicationService.Features.FiscalYear.Commands.Update;
using Warehousing.ApplicationService.Features.FiscalYear.Queries;
using Warehousing.ApplicationService.Features.FiscalYears.Queries;
using Warehousing.ApplicationService.Features.Inventory.Commands.Create;
using Warehousing.ApplicationService.Features.Inventory.Queries;
using Warehousing.WebApi.Infrastructure;

namespace Warehousing.WebApi.Controllers
{
    public class CustomerController : BaseController
    {
        #region Constructor
        public CustomerController(IMediator mediator) : base(mediator)
        {
        }
        #endregion Constructor

        #region Queries
        [HttpGet("id")]
        public async Task<IActionResult> GetCustomerById(int id, CancellationToken cancellationToken)
        {
            var command = new GetCustomerDetailQuery { Id = id };
            var result = await Mediator.Send(command, cancellationToken);
            return Ok(result);
        }

        [HttpGet("userId")]
        public async Task<IActionResult> GetAllCustomers(string userId, CancellationToken cancellationToken)
        {
            var command = new GetCustomerListQuery { UserId = userId };
            var result = await Mediator.Send(command, cancellationToken);
            return Ok(result);
        }
        #endregion Queries

        #region Command
        [HttpPost]
        public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(request, cancellationToken);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCustomer([FromBody] UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(request, cancellationToken);
            return Ok(result);
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteCustomer(int id, CancellationToken cancellationToken)
        {
            var command = new DeleteCustomerCommand { Id = id };
            var result = await Mediator.Send(command, cancellationToken);
            return Ok(result);
        }
        #endregion Command
    }
}
