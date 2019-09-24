using BMS.Models.BaseModels;
using BMS.Repository;
using System;
using System.Collections.Generic;
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
        public ActionResult Registration()
        {
            var model = new Supplier()
            {
                Name = "",
                Code = "",
                Photo = null,
                Email = "",
                Address = "",
                ContactNo = "",
                ContactPerson = ""

            };
            return View(model);
           
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registration(Supplier model)
        {
            ViewBag.Message = "";
           

            if (ModelState.IsValid)
            {

                if (model.ImageData != null)
                {
                    model.Photo = new byte[model.ImageData.ContentLength];
                    model.ImageData.InputStream.Read(model.Photo, 0, model.ImageData.ContentLength);

                }
                else
                {
                    return View(model);
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
                    _db.Supliers.Add(model);
                    _db.SaveChanges();
                    #endregion


                    ViewBag.Message = "Supplier Sccessfully Added !";
                }

            }

            
            return View();
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
            var jsondata= datalist.Select(c=> new {c.Name,c.Address,c.ContactNo,c.Email,c.Code,c.ContactPerson,PhotoStr=ConvertByteToBase64String(c.Photo)});
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
        
        public JsonResult GetSupliers()
        {
            var datalist = _db.Supliers.ToList();
            return Json(datalist, JsonRequestBehavior.AllowGet);
        }

    }
}