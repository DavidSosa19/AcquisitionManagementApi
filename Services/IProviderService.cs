using AcquisitionManagementAPI.Models;

namespace AcquisitionManagementAPI.Services
{
    public interface IProviderService
    {
        Task<IEnumerable<Provider>> GetProviders();
        Task<Provider?> GetProviderByID(int id);
    }
}
