using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxCalculator.Domain;

namespace TaxCalculator.Persistence.Repositories
{
    public interface IVehicleRepository
    {
        Task<Vehicle> GetVehicleByIdAsync(int id);
        Task<List<Pass>> GetPassesByVehicleIdAsync(int vehicleId);
    }
}
