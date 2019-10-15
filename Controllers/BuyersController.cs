using BMS.Models.BaseModels;
using BMS.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BMS.Controllers
{
    public class BuyersController : Controller
    {
        // GET: Buyers

        private readonly ProjectDbContext _db = new ProjectDbContext();
        public ActionResult Index()
        {
            return View();
        }

        #region Registration of Supplier

        [HttpGet]
        public ActionResult Create()
        {
            var model = new Supplier();
            return View(model);
           
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Supplier model)
        {
            

            ViewBag.Message = "";

            var isName = IsNameAdded(model.Name);
            var isCode = IsCodeAdded(model.Code);

            if (isCode || isName || (model.ImageData == null))
            {
               
                return View(model);
            }

            if (ModelState.IsValid)
            {
                model.Photo = new byte[model.ImageData.ContentLength];
                model.ImageData.InputStream.Read(model.Photo, 0, model.ImageData.ContentLength);

                if (model.Id != 0 && model.Id > 0)
                {
                    _db.Supliers.AddOrUpdate(model);
                    _db.SaveChanges();
                }
                else
                {
                    _db.Supliers.Add(model);
                    _db.SaveChanges();

                }
                ViewBag.Message = "Product Sccessfully Added !";
            }

            model = new Supplier();
            return View(model);
          

        }

        #endregion

        #region Supplier View
        public ActionResult SuplierList()
        {
            return View();
        }



        public JsonResult GetAllSuplier()
        {
            var datalist = _db.Supliers.ToList();
            var jsondata = datalist.Select(c => new { c.Id,c.Name, c.Address, c.ContactNo, c.Email, c.Code, c.ContactPerson, PhotoStr = ConvertByteToBase64String(c.Photo) });
            return Json(jsondata, JsonRequestBehavior.AllowGet);

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
        #endregion
        public bool IsNameAdded(string name)
        {
            var datalist = _db.Supliers.ToList();

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
            var datalist = _db.Supliers.ToList();

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


        public JsonResult IsSuplierContactUnique(string number)
        {
            var dataList = _db.Supliers.ToList();
            var isFound = false;
            foreach (var item in dataList)
            {
                if (item.ContactNo == number)
                {
                    isFound = true;
                    return Json(isFound, JsonRequestBehavior.AllowGet);
                }

            }

            return Json(isFound, JsonRequestBehavior.AllowGet);
        }
        public JsonResult IsSuplierCodeUnique(string code)
        {
            var dataList = _db.Supliers.ToList();
            var isFound = false;
            foreach (var item in dataList)
            {
                if (item.Name == code)
                {
                    isFound = true;
                    return Json(isFound, JsonRequestBehavior.AllowGet);
                }

            }

            return Json(isFound, JsonRequestBehavior.AllowGet);

        }
        public JsonResult IsSuplierEmailUnique(string email)
        {
            var dataList = _db.Supliers.ToList();
            var isFound = false;
            foreach (var item in dataList)
            {
                if (item.Email == email)
                {
                    isFound = true;
                    return Json(isFound, JsonRequestBehavior.AllowGet);
                }

            }

            return Json(isFound, JsonRequestBehavior.AllowGet);
        }
        

        public JsonResult Delete(int id)
        {
            try
            {
                Supplier data = _db.Supliers.Where(c => c.Id == id).FirstOrDefault();
                _db.Supliers.Remove(data);
                _db.SaveChanges();
                var datalist = _db.Supliers.ToList();
                var jsondata = datalist.Select(c => new { c.Id,c.Name, c.Address, c.ContactNo, c.Email, c.Code, c.ContactPerson, PhotoStr = ConvertByteToBase64String(c.Photo) });
                return Json(jsondata, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}