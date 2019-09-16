using BMS.Models.BaseModels;
using BMS.Models.ViewModels;
using BMS.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BMS.Controllers
{
    public class SaleController : Controller
    {
        // GET: Sale
        readonly private ProjectDbContext _db = new ProjectDbContext();
        public ActionResult Index()
        {
            return View();
        }

        #region Sale Entry

        [HttpGet]
        public ActionResult ProductSale()
        {
            var model = new Sale()
            {
                CustomerLookUp = GetDefaulSelectedList(),
                ProductLookUp = ProductListLookUp(),
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

        //public JsonResult GetProducts()
        //{
        //    var datalist = _db.Products.ToList();
        //    return Json(datalist, JsonRequestBehavior.AllowGet);
        //}

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

    }
}