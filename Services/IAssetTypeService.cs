using AcquisitionManagementAPI.Models;

namespace AcquisitionManagementAPI.Services
{
    public interface IAssetTypeService
    {
        Task<IEnumerable<AssetServiceType>> GetAssetsTypes();
        Task<AssetServiceType?> GetAssetTypeByID(int id);
    }
}
