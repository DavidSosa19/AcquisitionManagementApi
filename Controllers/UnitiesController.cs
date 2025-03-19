using AcquisitionManagementAPI.Models;
using AcquisitionManagementAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AcquisitionManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnitiesController : ControllerBase
    {
        private readonly IUnityService _unityService;
        public UnitiesController(IUnityService providerService)
        {
            _unityService = providerService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Unit>>> GetProviders()
        {
            var acquisitions = await _unityService.GetUnities();
            return Ok(acquisitions);
        }

        [HttpGet("view/{id}")]
        public async Task<ActionResult<Unit>> GetAcquisitionByID(int id)
        {
            var acquisition = await _unityService.GetUnitByID(id);
            if (acquisition == null)
            {
                return NotFound();
            }
            return Ok(acquisition);
        }
    }
}
