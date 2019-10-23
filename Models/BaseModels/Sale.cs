using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BMS.Models.BaseModels
{
    public class Sale
    {
        public long Id { get; set; }
        public DateTime PurchaseDate { get; set; }
        public long CustomerId { get; set; }
        public long ProductId { get; set; }
        public virtual Customer Customer { get; set; }
     

        public virtual ICollection<SaleDetails> SaleDetails { get; set; }

        [NotMapped]
        public ICollection<SelectListItem> CustomerLookUp { get; set; }

        [NotMapped]
        public ICollection<SelectListItem> ProductLookUp { get; set; }




        public List<Stock> GetStockModel()
        {
            var modelList = new List<Stock>();

            if (SaleDetails != null && SaleDetails.Any())
            {
                modelList.AddRange(SaleDetails.Select(detail => new Stock { ProductId = detail.ProductId, Qty = detail.Qty }));
            }

            return modelList;
        }
    }
}