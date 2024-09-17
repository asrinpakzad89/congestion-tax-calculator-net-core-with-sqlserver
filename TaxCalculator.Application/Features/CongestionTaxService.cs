using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxCalculator.Application.Common.Interfaces;
using TaxCalculator.Persistence.Repositories;

namespace TaxCalculator.Application.Features;

public class CongestionTaxService
{
    private readonly ITaxRule _taxRule;
    private readonly IVehicleRepository _vehicleRepository;

    public CongestionTaxService(ITaxRule taxRule, IVehicleRepository vehicleRepository)
    {
        _taxRule = taxRule;
        _vehicleRepository = vehicleRepository;
    }

    public int CalculateTaxForDay(int vehicleId, DateTime[] passDates)
    {
        var vehicle = _vehicleRepository.GetVehicleByIdAsync(vehicleId).Result;

        if (vehicle.IsExempt)
            return 0;

        DateTime intervalStart = passDates[0];
        int totalFee = 0;

        foreach (var date in passDates)
        {
            int nextFee = _taxRule.GetTollFee(date);
            int tempFee = _taxRule.GetTollFee(intervalStart);

            if ((date - intervalStart).TotalMinutes <= 60)
            {
                if (nextFee > tempFee)
                    tempFee = nextFee;
                totalFee = Math.Min(totalFee + tempFee, 60);
            }
            else
            {
                totalFee += nextFee;
                intervalStart = date;
            }
        }

        return Math.Min(totalFee, 60);
    }
}
