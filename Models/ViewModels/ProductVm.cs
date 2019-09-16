using BMS.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BMS.Models.ViewModels
{
    public class ProductVm
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public long CatagoryId { get; set; }
        public string ReorderLevel { get; set; }
        public string Description { get; set; }
        public byte[] Photo { get; set; }
        public double UnitPrice { get; set; }
        public double CostPrice { get; set; }
        public IEnumerable<SelectListItem> CatagoryLookUp { get; set; }
        public virtual Catagory Catagory { get; set; }
        public HttpPostedFileBase ImageData { get; set; }
    }
}