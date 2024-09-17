using Microsoft.EntityFrameworkCore;
using TaxCalculator.Domain;
using TaxCalculator.Persistence.Data;

namespace TaxCalculator.Persistence.Repositories
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public VehicleRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Vehicle> GetVehicleByIdAsync(int id)
        {
            return await _dbContext.Vehicles.FindAsync(id);
        }

        public async Task<List<Pass>> GetPassesByVehicleIdAsync(int vehicleId)
        {
            return await _dbContext.Passes
                                   .Include(p => p.Vehicle)
                                   .Where(p => p.VehicleId == vehicleId)
                                   .ToListAsync();
        }
    }
}
