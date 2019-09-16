using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BMS.Models.ViewModels
{
    public class StockVm
    {

        public long Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Catagory { get; set; }
        public double ReorderLevel { get; set; }
        public DateTime dateTime { get; set; }
        public double OpeningBalance { get; set; }
        public double In { get; set; }
        public double Out { get; set; }
        public double ClosingBalance { get; set; }

    }

}