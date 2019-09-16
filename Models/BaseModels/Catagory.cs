using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BMS.Models.BaseModels
{
    public class Catagory
    {
        public Catagory()
        {
            CreatedOn = DateTime.Now;
        }
        public long Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }

        public long? CreatedById { get; set; }
        public DateTime CreatedOn { get; set; }
        public long? LastModifideById { get; set; }
        public DateTime? LastModifiedOn { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}