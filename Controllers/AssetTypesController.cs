using AcquisitionManagementAPI.Models;
using AcquisitionManagementAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AcquisitionManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetTypesController : ControllerBase
    {
        private readonly IAssetTypeService _assetTypeService;
        public AssetTypesController(IAssetTypeService assetTypeService)
        {
            _assetTypeService = assetTypeService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AssetServiceType>>> GetAssetsTypes()
        {
            var acquisitions = await _assetTypeService.GetAssetsTypes();
            return Ok(acquisitions);
        }

        [HttpGet("view/{id}")]
        public async Task<ActionResult<AssetServiceType>> GetAssetTypeByID(int id)
        {
            var acquisition = await _assetTypeService.GetAssetTypeByID(id);
            if (acquisition == null)
            {
                return NotFound();
            }
            return Ok(acquisition);
        }
    }
}
