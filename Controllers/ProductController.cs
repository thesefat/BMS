
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
    public class ProductController : Controller
    {
        // GET: Product

        private readonly ProjectDbContext _db = new ProjectDbContext();
      
        public ActionResult Index()
        {
            return View();
        }

        #region Product Setup
        [HttpGet]
        public ActionResult Setup()
        {
            var model = new ProductVm()
            {
                CatagoryLookUp = GetDefaultProductSelectedList(),
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Setup(Product model)
        {
            ViewBag.Message = "";
            var mode = new ProductVm()
            {
                CatagoryLookUp = GetDefaultProductSelectedList(),

            };

            if (ModelState.IsValid)
            {

                if (model.ImageData != null)
                {
                    model.Photo = new byte[model.ImageData.ContentLength];
                    model.ImageData.InputStream.Read(model.Photo, 0, model.ImageData.ContentLength);

                }
                else
                {
                    return View(mode);
                }

                var isName = IsNameAdded(model.Name);
                var isCode = IsCodeAdded(model.Code);

                if (isName || isCode)
                {
                    return View(model);
                }
                else
                {

                    #region Save in Database
                    _db.Products.Add(model);
                    _db.SaveChanges();
                    #endregion


                    ViewBag.Message = "Product Sccessfully Added !";
                }




            }

          
            return View(mode);
        }
        #endregion

        public List<SelectListItem> GetDefaultProductSelectedList()
        {
            var selectedList = new List<SelectListItem> { new SelectListItem() { Text = "------Select------", Value = "" } };
            return selectedList;
        }

        public bool IsNameAdded(string name)
        {
            var datalist = _db.Products.ToList();

            bool isAdded = false;

            foreach (var item in datalist)
            {
                if (item.Name == name)
                {
                    isAdded = true;
                    return isAdded;
                }

            }

            return isAdded;
        }
        public bool IsCodeAdded(string code)
        {
            var datalist = _db.Products.ToList();

            bool isAdded = false;

            foreach (var item in datalist)
            {
                if (item.Code == code)
                {
                    isAdded = true;
                    return isAdded;
                }

            }

            return isAdded;
        }


        #region View All Products

        [HttpGet]
        public ActionResult ProductsView()
        {
            return View();
        }
        #endregion
        public JsonResult IsCatagoryNameUnique(string name)
        {
            var dataList = _db.Products.ToList();
            var isFound = false;
            foreach (var item in dataList)
            {
                if (item.Name == name)
                {
                    isFound = true;
                    return Json(isFound, JsonRequestBehavior.AllowGet);
                }

            }

            return Json(isFound, JsonRequestBehavior.AllowGet);

        }
        public JsonResult IsCatagoryCodeUnique(string code)
        {
            var dataList = _db.Products.ToList();
            var isFound = false;
            foreach (var item in dataList)
            {
                if (item.Code == code)
                {
                    isFound = true;
                    return Json(isFound, JsonRequestBehavior.AllowGet);
                }

            }
            return Json(isFound, JsonRequestBehavior.AllowGet);

        }
        public JsonResult GetCatagories()
        {
            var datalist = _db.Catagories.ToList();
            var jsonData = datalist.Select(c => new { c.Id, c.Name });
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }


        public JsonResult GetProducts()
        {

          
            var datalist = _db.Products.ToList();
            var jsoData = datalist.Select(c => new { c.Id, c.Name,c.UnitPrice, c.CostPrice, c.Description, c.ReorderLevel, PhotoStr = ConvertByteToBase64String(c.Photo) });
            return Json(jsoData, JsonRequestBehavior.AllowGet);

           
        }

        //Photo convert from Json object to base64string
        public static string ConvertByteToBase64String(byte[] file)
        {
            if (file.Length > 1)
            {
                var base64 = Convert.ToBase64String(file);
                var result = $"data:image/gif;base64,{base64}";
                return result;
            }
            return null;
        }
    }
}
