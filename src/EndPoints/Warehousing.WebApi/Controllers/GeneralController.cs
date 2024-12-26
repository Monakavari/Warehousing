using MediatR;
using Microsoft.AspNetCore.Mvc;
using Warehousing.ApplicationService.Services.Contracts;
using Warehousing.Domain.Dtos;
using Warehousing.WebApi.Infrastructure;

namespace Warehousing.WebApi.Controllers
{
    public class GeneralController : BaseController
    {
        private readonly IGeneralService _generalService;
        public GeneralController(IMediator mediator,
                                 IGeneralService generalService) : base(mediator)
        {
            _generalService = generalService;
        }

        [HttpGet]
        public async Task<IActionResult> GetFiscalYearListDropDown(CancellationToken cancellationToken)
        {
            var result = await _generalService.FiscalYearListDropDown(cancellationToken);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetCountryListDropDown(CancellationToken cancellationToken)
        {
            var result = await _generalService.CountryListDropDown(cancellationToken);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetSupplierListDropDown(CancellationToken cancellationToken)
        {
            var result = await _generalService.SupplierListDropDown(cancellationToken);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetProductExpireDateForDropDown(GetProductExpireDateRequestForDropDown request,CancellationToken cancellationToken)
        {
            var result = await _generalService.ProductExpireDateListDropDown(request,cancellationToken);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetProductLocationListDropDown(int warehouseId,CancellationToken cancellationToken)
        {
            var result = await _generalService.ProductLocationListDropDown(warehouseId,cancellationToken);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> WarehouseUserOrientedListDropDown(string UserIdInWarehouse, CancellationToken cancellationToken)
        {
            var result = await _generalService.WarehouseUserOrientedListDropDown(UserIdInWarehouse, cancellationToken);
            return Ok(result);
        }
    }
}
