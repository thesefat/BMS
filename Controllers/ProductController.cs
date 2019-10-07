
using BMS.Models.BaseModels;
using BMS.Models.ViewModels;
using BMS.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
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
            var model = new Product()
            {
                CatagoryLookUp = CatagoryListLookUp(),
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Setup(Product model)
        {
            ViewBag.Message = "";
      
            var isName = IsNameAdded(model.Name);
            var isCode = IsCodeAdded(model.Code);

            if (isCode || isName || (model.ImageData==null))
            {
                model.CatagoryLookUp = CatagoryListLookUp();
                return View(model);
            }

            if (ModelState.IsValid)
            {             
                    model.Photo = new byte[model.ImageData.ContentLength];
                    model.ImageData.InputStream.Read(model.Photo, 0, model.ImageData.ContentLength);

                    if (model.Id != 0 && model.Id > 0)
                    {
                        _db.Products.AddOrUpdate(model);
                        _db.SaveChanges();
                    }
                    else
                    { 
                        _db.Products.Add(model);
                        _db.SaveChanges();
                      
                    }
                    ViewBag.Message = "Product Sccessfully Added !";
            }

            model.CatagoryLookUp = CatagoryListLookUp();
            return View(model);
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
            var jsoData = datalist.Select(c => new { c.Id, c.Name,c.Code, c.UnitPrice, c.CostPrice, c.Description, c.ReorderLevel, PhotoStr = ConvertByteToBase64String(c.Photo), c.ImageData});
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

        public JsonResult Delete(int id)
        {
            try
            {
                Product data = _db.Products.Where(c => c.Id == id).FirstOrDefault();
                _db.Products.Remove(data);
                _db.SaveChanges();
                var datalist = _db.Products.ToList();
                var jsonData = datalist.Select(c => new { c.Id, c.Name, c.UnitPrice, c.CostPrice, c.Description, c.ReorderLevel, PhotoStr = ConvertByteToBase64String(c.Photo) });
                return Json(jsonData, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<SelectListItem> CatagoryListLookUp()
        {
            var dataList = _db.Catagories.ToList();
            var selectedList = new List<SelectListItem>();
            selectedList.AddRange(GetDefaultProductSelectedList());
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
