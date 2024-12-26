using MediatR;
using Microsoft.AspNetCore.Mvc;
using Warehousing.ApplicationService.Features.Inventory.Commands.Create;
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
        public async Task<IActionResult> GetProductStock(GetCustomerListQuery request, CancellationToken cancellationToken)
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

        #endregion Command
    }
}
