using AcquisitionManagementAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AcquisitionManagementAPI.Services
{
    public class UnityService : IUnityService
    {
        private readonly AcquisitiondbContext _context;

        public UnityService(AcquisitiondbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Unit>> GetUnities()
        {
            return await _context.Unities.ToListAsync();
        }
        public async Task<Unit?> GetUnitByID(int id)
        {
            return await _context.Unities.FindAsync(id);
        }

    }
}
