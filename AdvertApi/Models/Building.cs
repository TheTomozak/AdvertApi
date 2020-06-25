using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvertApi.Models
{
    public class Building
    {
        public int IdBuilding { get; set; }
        public string Street { get; set; }
        public int StreetNumber { get; set; }
        public string City { get; set; }
        public decimal Height { get; set; }


        public ICollection<Campaign> CampaignsFromIdBuilding { get; set; }
        public ICollection<Campaign> CampaignsToIdBuilding { get; set; }



    }
}
