using System;

namespace CleanPlanetApp.Models
{
    public class PartnerService
    {
        public int PartnerServiceId { get; set; }
        public int PartnerId { get; set; }
        public int ServiceId { get; set; }
        public string ServiceName { get; set; }
        public int Quantity { get; set; }
        public DateTime ExecutionDate { get; set; }
        public string PartnerName { get; set; }
    }
}