using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BMS.Models.ViewModels
{
    public class PurchaseVm
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string ReorderLevel { get; set; }
        public string Description { get; set; }
        public byte[] Photo { get; set; }
    }
}