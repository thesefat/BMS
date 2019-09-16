using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BMS.Models.BaseModels
{
    public class Purchase
    {

        public long Id { get; set; }
        public DateTime PurchaseDate { get; set; }
        public long SuplierId { get; set; }
        public virtual ICollection<PurchaseDetails> PurchaseDetails { get; set; }

        [NotMapped]
        public ICollection<SelectListItem> ProductLookUp { get; set; }
        [NotMapped]
        public ICollection<SelectListItem> SuplierLookUp { get; set; }

    }
}