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
        public virtual ICollection<SaleDetails> SaleDetails { get; set; }
        public virtual Customer Customer { get; set; }

        [NotMapped]
        public double LoyalityPoint { get; set; }
        [NotMapped]
        public ICollection<SelectListItem> CustomerLookUp { get; set; }

        [NotMapped]
        public ICollection<SelectListItem> ProductLookUp { get; set; }
    }
}