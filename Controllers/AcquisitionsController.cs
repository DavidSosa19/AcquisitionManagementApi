using AcquisitionManagementAPI.Models;
using AcquisitionManagementAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AcquisitionManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AcquisitionsController : ControllerBase
    {
        private readonly IAcquisitionService _acquisitionService;
        public AcquisitionsController(IAcquisitionService acquisitionService)
        {
            _acquisitionService = acquisitionService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Acquisition>>> GetAcquisitions(
            [FromQuery] int? providerId,
            [FromQuery] int? unitId,
            [FromQuery] int? assetServiceTypeId)
        {
            var acquisitions = await _acquisitionService.GetAcquisitions(providerId, unitId, assetServiceTypeId);
            return Ok(acquisitions);
        }

        [HttpGet("view/{id}")]
        public async Task<ActionResult<Acquisition>> GetAcquisitionByID(int id)
        {
            var acquisition = await _acquisitionService.GetAcquisitionByID(id);
            if (acquisition == null)
            {
                return NotFound();
            }
            return Ok(acquisition);
        }

        [HttpPost("add")]
        public async Task<ActionResult<Acquisition>> AddAcquisition(Acquisition acquisition)
        {
            await _acquisitionService.AddAcquisition(acquisition);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut("edit/{id}")]
        public async Task<ActionResult<Acquisition>> UpdateAcquisition(int id, Acquisition acquisition)
        {
            bool updated = await _acquisitionService.UpdateAcquisition(id, acquisition);
            if(!updated)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> DeleteAcquisition(int id)
        {
            bool deleted = await _acquisitionService.DeleteAcquisition(id);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
