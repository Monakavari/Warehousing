using MediatR;
using Microsoft.AspNetCore.Mvc;
using Warehousing.ApplicationService.Features.Countries.Commands.Create;
using Warehousing.ApplicationService.Features.Countries.Commands.Delete;
using Warehousing.ApplicationService.Features.Countries.Commands.Update;
using Warehousing.ApplicationService.Features.Countries.Queries;
using Warehousing.WebApi.Infrastructure;

namespace Warehousing.WebApi.Controllers
{
    public class CountryController : BaseController
    {
        #region Constructor
        public CountryController(IMediator mediator) : base(mediator)
        {
        }
        #endregion Constructor

        #region Queries

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCountryById(int id, CancellationToken cancellationToken)
        {
            var command = new GetCountryDetailQuery { Id = id };
            var result = await Mediator.Send(command, cancellationToken);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetCountries(GetCountryListQuery request, CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(request, cancellationToken);
            return Ok(result);
        }
        #endregion Queries

        #region Command

        [HttpPost]
        public async Task<IActionResult> CreateCountry([FromBody] CreateCountryCommand request, CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(request, cancellationToken);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCountry(int id, CancellationToken cancellationToken)
        {
            var command = new DeleteCountryCommand { Id = id };
            var result = await Mediator.Send(command, cancellationToken);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCountry(UpdateCountryCommand request, CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(request, cancellationToken);
            return Ok(result);
        }

        #endregion Command
    }
}
