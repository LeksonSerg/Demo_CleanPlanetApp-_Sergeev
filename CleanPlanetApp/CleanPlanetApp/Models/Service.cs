namespace CleanPlanetApp.Models
{
    public class Service
    {
        public int ServiceId { get; set; }
        public int ServiceTypeId { get; set; }
        public string ServiceName { get; set; }
        public string ServiceCode { get; set; }
        public decimal MinimalCost { get; set; }
        public string ServiceTypeName { get; set; }
        public double ComplexityCoefficient { get; set; }
        public decimal CalculatedCost { get; set; }
    }
}