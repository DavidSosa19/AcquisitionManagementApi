using AcquisitionManagementAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace AcquisitionManagementAPI.Services
{
    public class AcquisitionService : IAcquisitionService
    {
        private readonly AcquisitiondbContext _context;

        public AcquisitionService(AcquisitiondbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Acquisition>> GetAcquisitions(int? providerId = null, int? unitId = null, int? assetTypeServiceId = null)
        {
            var query = _context.Acquisitions.AsQueryable();

            if (providerId.HasValue)
            {
                query = query.Where(a => a.Proveedor == providerId.Value);
            }

            if (unitId.HasValue)
            {
                query = query.Where(a => a.Unidad == unitId.Value);
            }

            if (assetTypeServiceId.HasValue)
            {
                query = query.Where(a => a.TipoBienServicio == assetTypeServiceId.Value);
            }

            return await query.ToListAsync(); 
        }
        public async Task<Acquisition?> GetAcquisitionByID(int id)
        {
            return await _context.Acquisitions.FindAsync(id);
        }

        public async Task<Acquisition> AddAcquisition(Acquisition acquisition)
        {
            acquisition.CreatedAt = DateTime.UtcNow;
            _context.Acquisitions.Add(acquisition);
            await _context.SaveChangesAsync();
            return acquisition;
        }
        public async Task<bool> UpdateAcquisition(int id, Acquisition acquisition)
        {
            var updatedAcquisition = await _context.Acquisitions.FindAsync(id);
            if (updatedAcquisition == null)
            {
                return false;
            }

            updatedAcquisition.UpdatedAt = DateTime.UtcNow;
            updatedAcquisition.TipoBienServicio = acquisition.TipoBienServicio;
            updatedAcquisition.Documentacion = acquisition.Documentacion;
            updatedAcquisition.Cantidad = acquisition.Cantidad;
            updatedAcquisition.ValorUnitario = acquisition.ValorUnitario;
            updatedAcquisition.Unidad = acquisition.Unidad;
            updatedAcquisition.Presupuesto = acquisition.Presupuesto;
            updatedAcquisition.Cantidad = acquisition.Cantidad;
            updatedAcquisition.ValorTotal = acquisition.ValorTotal;
            updatedAcquisition.FechaAdquisicion = acquisition.FechaAdquisicion;
            updatedAcquisition.Proveedor = acquisition.Proveedor;

            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteAcquisition(int id)
        {
            var acquisition = await _context.Acquisitions.FindAsync(id);
            if (acquisition == null)
            {
                return false;
            }
            _context.Acquisitions.Remove(acquisition);
            await _context.SaveChangesAsync();
            return true;
        }

       
    }
}
