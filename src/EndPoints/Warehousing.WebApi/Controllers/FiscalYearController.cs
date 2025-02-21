using MediatR;
using Microsoft.AspNetCore.Mvc;
using Warehousing.ApplicationService.Features.FiscalYear.Commands.Create;
using Warehousing.ApplicationService.Features.FiscalYear.Commands.Delete;
using Warehousing.ApplicationService.Features.FiscalYear.Commands.Update;
using Warehousing.ApplicationService.Features.FiscalYear.Queries;
using Warehousing.ApplicationService.Features.FiscalYears.Queries;
using Warehousing.Domain.Entities;
using Warehousing.WebApi.Infrastructure;

namespace Warehousing.WebApi.Controllers
{
    public class FiscalYearController : BaseController
    {
        #region Constructor
        public FiscalYearController(IMediator mediator) : base(mediator)
        {
        }
        #endregion Constructor

        #region Queries
        [HttpGet("id")]
        public async Task<IActionResult> GetFiscalYearById(int id, CancellationToken cancellationToken)
        {
            var command = new GetFiscalYearDetailQuery { Id = id };
            var result = await Mediator.Send(command, cancellationToken);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllFiscalYears(CancellationToken cancellationToken)
        {
            var command = new GetFiscalYearListQuery();
            var result = await Mediator.Send(command, cancellationToken);
            return Ok(result);
        }

        [HttpGet("fiscalYearId")]
        public async Task<IActionResult> GetNewFiscalYear(int fiscalYearId, CancellationToken cancellationToken)
        {
            var command = new GetNewFiscalYearQuery { FiscalYearId = fiscalYearId };
            var result = await Mediator.Send(command, cancellationToken);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetCurrentFiscalYear(CancellationToken cancellationToken)
        {
            var command = new GetCurrentFiscalYearQuery ();
            var result = await Mediator.Send(command, cancellationToken);
            return Ok(result);
        }
        #endregion Queries

        #region Command
        [HttpPost]
        public async Task<IActionResult> CreateFiscalYear([FromBody] CreateFiscalYearCommand request, CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(request, cancellationToken);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateFiscalYear([FromBody] UpdateFiscalYearCommand request, CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(request, cancellationToken);
            return Ok(result);
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteFiscalYear(int id, CancellationToken cancellationToken)
        {
            var command = new DeleteFiscalYearCommand { Id = id };
            var result = await Mediator.Send(command, cancellationToken);
            return Ok(result);
        }
        #endregion Command
    }
}
