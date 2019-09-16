using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BMS.Models.BaseModels
{
    public class PurchaseDetails
    {

     
        public long Id { get; set; }
        public long ProductId { get; set; }
        public DateTime ManufectureDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public double PurchaseQuantity { get; set; }
        public double UnitPrice { get; set; }
        public double TotalPrice { get; set; }
        public double PreviousCostPrice { get; set; }
        public double PreviousMRP { get; set; }
        public double NewCostPrice { get; set; }
        public double NewMRP { get; set; }
        public virtual Product Product { get; set; }
    }
}