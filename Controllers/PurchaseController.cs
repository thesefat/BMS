using BMS.Models.BaseModels;
using BMS.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BMS.Controllers
{
    public class PurchaseController : Controller
    {
        // GET: Purchase

        private readonly ProjectDbContext _db = new ProjectDbContext();
        public ActionResult Index()
        {
            return View();
        }


        #region Purchase Item from Supplier
        [HttpGet]
        public ActionResult PurchaseItems()
        {

            var model = new Purchase()
            {
                ProductLookUp = GetDefaulSelectedList(),
                SuplierLookUp = GetDefaulSelectedList(),
            };
            return View(model);
        }
        #endregion


        public List<SelectListItem> GetDefaulSelectedList()
        {
            var selectList = new List<SelectListItem>
            {
                new SelectListItem()
                {
                    Text="-----Select-----",Value=""
                }
            };
            return selectList;
        }

        public JsonResult GetProducts()
        {
            var datalist = _db.Products.ToList();
            return Json(datalist, JsonRequestBehavior.AllowGet);
        }
    }
}