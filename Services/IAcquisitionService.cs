namespace AcquisitionManagementAPI.Services;
using AcquisitionManagementAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IAcquisitionService
{
    Task<IEnumerable<Acquisition>> GetAcquisitions(int? providerId = null, int? unitId = null, int? assetTypeServiceId = null);
    Task<Acquisition?> GetAcquisitionByID(int id);
    Task<Acquisition> AddAcquisition(Acquisition acquisition);
    Task<bool> UpdateAcquisition(int id, Acquisition acquisition);
    Task<bool> DeleteAcquisition(int id);
}