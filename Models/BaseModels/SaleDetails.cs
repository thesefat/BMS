using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BMS.Models.BaseModels
{
    public class SaleDetails
    {
        public long Id { get; set; }
        public long SaleId { get; set; }
        public long ProductId { get; set; }
        public double Qty { get; set; }
        public double UnitPrice { get; set; }
        public double TotalPrice => Qty * UnitPrice;
        public virtual Product Product { get; set; }
        public virtual Sale Sale { get; set; }

       


    }
}