using System;

namespace CleanPlanetApp.Models
{
    public class MaterialPrice
    {
        public int MaterialPriceId { get; set; }
        public int MaterialId { get; set; }
        public decimal Price { get; set; }
        public DateTime EffectiveDate { get; set; }
        public string MaterialType { get; set; }
    }
}