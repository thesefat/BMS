using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BMS.Models.BaseModels
{
    public class Buyer
    {
        public long Id { get; set; }
        public int BuyerTypeId { get; set; }
        public string Name { get; set; }
        public string ContactNo { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public double LoyaltyPoint { get; set; }
        public string ContactPerson { get; set; }
        public byte[] Photo { get; set; }
    }
}