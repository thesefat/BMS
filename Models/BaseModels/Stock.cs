using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BMS.Models.BaseModels
{
    public class Stock
    {
        public long Id { get; set; }
        public long ProductId { get; set; }
        public double Qty { get; set; }
        public virtual Product Product { get; set; }

    }
}