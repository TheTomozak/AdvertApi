using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvertApi.Models
{
    public class Banner
    {
        public int IdAdvertisement { get; set; }
        public int Name { get; set; }
        public decimal Price { get; set; }
        public int IdCampaing { get; set; }
        public decimal Area { get; set; }

        public Campaign IdCampaignBanner { get; set; }



    }
}
