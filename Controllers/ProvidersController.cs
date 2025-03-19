using AcquisitionManagementAPI.Models;
using AcquisitionManagementAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AcquisitionManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProvidersController : ControllerBase
    {
        private readonly IProviderService _providerService;
        public ProvidersController(IProviderService providerService)
        {
            _providerService = providerService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Provider>>> GetProviders()
        {
            var acquisitions = await _providerService.GetProviders();
            return Ok(acquisitions);
        }

        [HttpGet("view/{id}")]
        public async Task<ActionResult<Provider>> GetAcquisitionByID(int id)
        {
            var acquisition = await _providerService.GetProviderByID(id);
            if (acquisition == null)
            {
                return NotFound();
            }
            return Ok(acquisition);
        }
    }
}
