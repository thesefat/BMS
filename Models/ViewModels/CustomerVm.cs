using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BMS.Models.ViewModels
{
    public class CustomerVm
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string ContactNo { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public double LoyaltyPoint { get; set; }
        public string Code { get; set; }
        public byte[] Photo { get; set; }
        public HttpPostedFileBase ImageData { get; set; }
    }
}