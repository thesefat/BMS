using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebSockets;

namespace BMS.Models.BaseModels
{
    public class Purchase
    {

        public long Id { get; set; }

        public DateTime PurchaseDate { get; set; }
        public long SupplierId { get; set; }
        public long ProductId { get; set; }
        public virtual ICollection<PurchaseDetails> PurchaseDetails { get; set; }
        public virtual Suplier Supplier { get; set; }
        public IEnumerable<SelectListItem> SupplierLookUp { get; set; }
        public IEnumerable<SelectListItem> ProductLookUp { get; set; }

        public List<Stock> GetStockModel()
        {
            var modelList= new List<Stock>();

            if (PurchaseDetails!=null && PurchaseDetails.Any())
            {
                modelList.AddRange(PurchaseDetails.Select(detail => new Stock {ProductId = detail.ProductId, Qty = detail.Qty}));
            }

            return modelList;
        }
    }
}