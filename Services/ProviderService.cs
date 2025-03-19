using AcquisitionManagementAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AcquisitionManagementAPI.Services
{
    public class ProviderService : IProviderService
    {
        private readonly AcquisitiondbContext _context;

        public ProviderService(AcquisitiondbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Provider>> GetProviders()
        {
            return await _context.Providers.ToListAsync();
        }
        public async Task<Provider?> GetProviderByID(int id)
        {
            return await _context.Providers.FindAsync(id);
        }

    }
}
