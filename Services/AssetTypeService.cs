using AcquisitionManagementAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AcquisitionManagementAPI.Services
{
    public class AssetTypeService: IAssetTypeService
    {
        private readonly AcquisitiondbContext _context;

        public AssetTypeService(AcquisitiondbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<AssetServiceType>> GetAssetsTypes()
        {
            return await _context.AssetServiceTypes.ToListAsync();
        }
        public async Task<AssetServiceType?> GetAssetTypeByID(int id)
        {
            return await _context.AssetServiceTypes.FindAsync(id);
        }
    }
}
