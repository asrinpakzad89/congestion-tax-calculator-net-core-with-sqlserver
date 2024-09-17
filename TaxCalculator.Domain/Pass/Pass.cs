namespace TaxCalculator.Domain;

public class Pass
{
    public int Id { get; set; }
    public DateTime PassTime { get; set; }
    public int VehicleId { get; set; }
    public Vehicle Vehicle { get; set; }
}
