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

        #region Purchase Item from Supplier
        [HttpGet]
        public ActionResult PurchaseItems()
        {

            var model = new Purchase()
            {
                ProductLookUp = ProductListLookUp(),
                SuplierLookUp = SuplierListLookUp(),
            };
            return View(model);
        }


        public List<SelectListItem> ProductListLookUp()
        {
            var dataList = _db.Products.ToList();
            var selectedList = new List<SelectListItem>();
            selectedList.AddRange(GetDefaulSelectedList());
            foreach (var item in dataList)
            {
                var data = new SelectListItem()
                {
                    Value = item.Id.ToString(),
                    Text = item.Name
                };
                selectedList.Add(data);
            }
            return selectedList;
        }

        public List<SelectListItem> SuplierListLookUp()
        {
            var dataList = _db.Supliers.ToList();
            var selectedList = new List<SelectListItem>();
            selectedList.AddRange(GetDefaulSelectedList());
            foreach (var item in dataList)
            {
                var data = new SelectListItem()
                {
                    Value = item.Id.ToString(),
                    Text = item.Name
                };
                selectedList.Add(data);
            }
            return selectedList;
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

        //public JsonResult GetProducts()
        //{
        //    var datalist = _db.Products.ToList();
        //    var jsonData = datalist.Select(c => new {c.Id, c.Name, c.UnitPrice, c.CostPrice});
        //    return Json(jsonData, JsonRequestBehavior.AllowGet);
        //}









    }
}