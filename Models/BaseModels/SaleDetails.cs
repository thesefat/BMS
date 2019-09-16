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
        public long ProductId { get; set; }
        public string Name { get; set; }
        public double Quantiy { get; set; }
        public double UnitPrice { get; set; }
        public double LineTotal { get; set; }
        public virtual Product Product { get; set; }

       


    }
}