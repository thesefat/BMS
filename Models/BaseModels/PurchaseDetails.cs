using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BMS.Models.BaseModels
{
    public class PurchaseDetails
    {


        public long Id { get; set; }
        public long PurchaseId { get; set; }
        public long ProductId { get; set; }
        //public DateTime ManufectureDate { get; set; }
        //public DateTime ExpireDate { get; set; }
        public double Qty { get; set; }
        public double UnitPrice { get; set; }
        public double TotalPrice => Qty * UnitPrice;
        public double MrP { get; set; }
        public virtual Product Product { get; set; }
        public virtual Purchase Purchase { get; set; }

    }
}