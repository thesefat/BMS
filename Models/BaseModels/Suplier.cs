using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BMS.Models.BaseModels
{
    public class Suplier
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string ContactNo { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Code { get; set; }
        public string ContactPerson { get; set; }
        public byte[] Photo { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageData { get; set; }
    }
}