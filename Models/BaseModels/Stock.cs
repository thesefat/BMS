using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BMS.Models.BaseModels
{
    public class Stock
    {
        public long Id { get; set; }
        public string CatagoryName { get; set; }
        public string ProductName { get; set; }
        public long ProductId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndDate { get; set; }
        public virtual Product Product { get; set; }
    }
}