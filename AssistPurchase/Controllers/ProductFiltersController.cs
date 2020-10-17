using AssistPurchase.Repositories.Abstractions;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AssistPurchase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductFiltersController : ControllerBase
    {
        private readonly IFiltersRepository _filtersRepository;

        public ProductFiltersController(IFiltersRepository repo)
        {
            _filtersRepository = repo;
        }

        [HttpGet("filters")]
        public IActionResult Get()
        {
            return Ok(_filtersRepository.GetAll());
        }

        [HttpGet("filters/{productId}")]
        public IActionResult Get(string productId)
        {
            try
            {
                return Ok(_filtersRepository.GetProduct(productId));
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("filters/compact/{filterValue}")]
        public IActionResult GetByCompactFilter(bool filterValue )
        {
            return Ok(_filtersRepository.GetByCompactFilter(filterValue));

        }

        [HttpGet("filters/price/{amount}/{belowOrAbove}")]
        public IActionResult Get(string amount, string belowOrAbove)
        {
            return Ok(_filtersRepository.GetByPriceFilter(amount, belowOrAbove));
        }

        [HttpGet("filters/ProductSpecificTraining/{filterValue}")]
        public IActionResult GetByProductTrainingFilter(bool filterValue)
        {
            return Ok(_filtersRepository.GetByProductSpecificTrainingFilter(filterValue));
        }

        [HttpGet("filters/SoftwareUpdateSupport/{filterValue}")]
        public IActionResult GetByUpdateSupportFilter(bool filterValue)
        {
            return Ok(_filtersRepository.GetBySoftwareUpdateSupportFilter(filterValue));
        }

        [HttpGet("filters/Portability/{filterValue}")]
        public IActionResult GetByPortabilityFilter(bool filterValue)
        {
            return Ok(_filtersRepository.GetByPortabilityFilter(filterValue));
        }

        [HttpGet("filters/BatterySupport/{filterValue}")]
        public IActionResult GetByBatterySupportFilter(bool filterValue)
        {
            return Ok(_filtersRepository.GetByBatterySupportFilter(filterValue));
        }

        [HttpGet("filters/ThirdPartyDeviceSupport/{filterValue}")]
        public IActionResult GetByThirdPartyDeviceFilter(bool filterValue)
        {
            return Ok(_filtersRepository.GetByThirdPartyDeviceSupportFilter(filterValue));
        }

        [HttpGet("filters/SafeToFly/{filterValue}")]
        public IActionResult GetBySafeToFlyFilter(bool filterValue)
        {
            return Ok(_filtersRepository.GetBySafeToFlyCertificationFilter(filterValue));
        }

        [HttpGet("filters/TouchScreen/{filterValue}")]
        public IActionResult GetByTouchScreenFilter(bool filterValue)
        {
            return Ok(_filtersRepository.GetByTouchScreenSupportFilter(filterValue));
        }

        [HttpGet("filters/MultiPatientSupport/{filterValue}")]
        public IActionResult GetByMultiPatientSupportFilter(bool filterValue)
        {
            return Ok(_filtersRepository.GetByMultiPatientSupportFilter(filterValue));
        }

        [HttpGet("filters/CyberSecurity/{filterValue}")]
        public IActionResult GetByCyberSecurityFilter(bool filterValue)
        {
            return Ok(_filtersRepository.GetByCyberSecurityFilter(filterValue));
        }
    }
}
