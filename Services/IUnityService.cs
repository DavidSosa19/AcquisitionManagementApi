using AcquisitionManagementAPI.Models;

namespace AcquisitionManagementAPI.Services
{
    public interface IUnityService
    {
        Task<IEnumerable<Unit>> GetUnities();
        Task<Unit?> GetUnitByID(int id);
    }
}
