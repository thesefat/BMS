using BMS.Models.BaseModels;
using BMS.Models.ViewModels;
using BMS.Repository;
using System;
using System.Linq;
using System.Web.Mvc;

namespace BMS.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        readonly private ProjectDbContext _db = new ProjectDbContext();

        #region Registration of Customer

        [HttpGet]
        public ActionResult Registration()
        {
            var model = new Customer()
            {
                
                Name ="",
                Email = "",
                Code = "",
                Photo = null,
                LoyaltyPoint = 0.0,
                Address = ""

            };
           
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registration(Customer model)
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
                    ViewBag.Message = "Image Data is Illigal";
                    return View(model);
                }

                var isName = IsNameAdded(model.Name);
                var isCode = IsCodeAdded(model.Code);
                var isEmail = IsEmailAdded(model.Email);
                var isNumber = IsPhoneNumberAdded(model.ContactNo);

                if (isName || isCode|| isEmail || isNumber)
                {
                    return View(model);
                }
                else
                {

                    #region Save in Database
                    _db.Customers.Add(model);
                    _db.SaveChanges();
                    #endregion


                    ViewBag.Message = "Product Sccessfully Added !";
                }




            }

            model = new Customer();

            return View(model);
          
        }


        public bool IsNameAdded(string name)
        {
            var datalist = _db.Customers.ToList();

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
            var datalist = _db.Customers.ToList();

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
        public bool IsEmailAdded(string email)
        {
            var datalist = _db.Customers.ToList();

            bool isAdded = false;

            foreach (var item in datalist)
            {
                if (item.Email == email)
                {
                    isAdded = true;
                    return isAdded;
                }

            }

            return isAdded;
        }
        public bool IsPhoneNumberAdded(string number)
        {
            var datalist = _db.Customers.ToList();

            bool isAdded = false;

            foreach (var item in datalist)
            {
                if (item.ContactNo == number)
                {
                    isAdded = true;
                    return isAdded;
                }

            }

            return isAdded;
        }

        public JsonResult IsCustomerNameUnique(string name)
        {
            var dataList = _db.Customers.ToList();
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

        public JsonResult IsCustomerCodeUnique(string code)
        {
            var dataList = _db.Customers.ToList();
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

        public JsonResult IsCustomerEmailUnique(string email)
        {
            var dataList = _db.Customers.ToList();
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

        public JsonResult IsCustomerContactNoUnique(string number)
        {
            var dataList = _db.Customers.ToList();
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

        #endregion

        #region CustomerView
        public ActionResult CustomerList()
        {
            return View();
        }




        public JsonResult GetCustomers()
        {


            var datalist = _db.Customers.ToList();
            var jsoData = datalist.Select(c => new { c.Id, c.Name, c.ContactNo, c.Email, c.LoyaltyPoint, PhotoStr = ConvertByteToBase64String(c.Photo) });
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
        #endregion
    }
}