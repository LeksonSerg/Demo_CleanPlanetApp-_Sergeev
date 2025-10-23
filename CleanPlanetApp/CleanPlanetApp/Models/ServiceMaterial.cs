namespace CleanPlanetApp.Models
{
    public class ServiceMaterial
    {
        public int ServiceMaterialId { get; set; }
        public int ServiceId { get; set; }
        public int MaterialId { get; set; }
        public double ConsumptionRate { get; set; }
        public string MaterialType { get; set; }
        public string ServiceName { get; set; }
    }
}