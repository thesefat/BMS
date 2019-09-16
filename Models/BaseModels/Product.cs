using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;
using System.Web.Mvc;

namespace BMS.Models.BaseModels
{
    public class Product
    {

        public Product()
        {
            CreatedOn = DateTime.Now;
        }
        public long Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public double ReorderLevel { get; set; }
        public string Description { get; set; }
        public byte[] Photo { get; set; }
        public double UnitPrice { get; set; }
        public double CostPrice { get; set; }
        public long CatagoryId { get; set; }
        public long? CreatedById { get; set; }
        public DateTime CreatedOn { get; set; }
        public long? LastModifideById { get; set; }
        public DateTime? LastModifiedOn { get; set; }
        public virtual Catagory Catagory { get; set; }

        [NotMapped]
        public IEnumerable<SelectListItem> CatagoryLookUp { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageData { get; set; }
    }
}