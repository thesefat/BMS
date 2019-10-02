
using BMS.Models.BaseModels;
using BMS.Models.ViewModels;
using BMS.Repository;
using System;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web.Mvc;

namespace BMS.Controllers
{
    public class CatagoryController : Controller
    {

        private readonly ProjectDbContext _db = new ProjectDbContext();

        public ActionResult Index()
        {
            return View();
        }
        #region Catagory Setup
        [HttpGet]
        public ActionResult Setup()
        {
            var model = new CatagoryVm();
            return View(model);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Setup(Catagory model)
        {

            ViewBag.Message = "";
            // bool IsAdded = false;
            var mode = new CatagoryVm()
            {
                Name = "",
                Code = ""
            };

            if (ModelState.IsValid)
            {
                if (model.Id != 0 && model.Id > 0)
                {
                    _db.Catagories.AddOrUpdate(model);
                    _db.SaveChanges();
                }
                else
                {
                    var isName = IsNameAdded(model.Name);
                    var isCode = IsCodeAdded(mode.Code);

                    if (isName || isCode)
                    {
                        return View(mode);

                    }
                    _db.Catagories.Add(model);
                    _db.SaveChanges();
                    ViewBag.Message = "Added Successfully";
                }
            }

            return View(mode);
        }
        #endregion


        #region View All Catagory

        [HttpGet]
        public ActionResult AllCatagoryView()
        {
            return View();
        }
        #endregion

        public bool IsNameAdded(string name)
        {
            var datalist = _db.Catagories.ToList();

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
            var datalist = _db.Catagories.ToList();

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
        public JsonResult IsCatagoryNameUnique(string name)
        {
            var dataList = _db.Catagories.ToList();
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
            var dataList = _db.Catagories.ToList();
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

        public JsonResult GetCatagory(int? id)
        {
            var datalist = _db.Catagories.ToList();

            if (id != 0 && id > 0)
            {
                var jsonData = datalist.Where(c => c.Id == id).ToList().Select(e => new { e.Id, e.Name, e.Code });
                return Json(jsonData, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var jsonData = datalist.Select(c => new { c.Id, c.Code, c.Name });
                return Json(jsonData, JsonRequestBehavior.AllowGet);
            }



        }

        public JsonResult Delete(int id)
        {
            try
            {
                Catagory data = _db.Catagories.Where(c => c.Id == id).FirstOrDefault();
                _db.Catagories.Remove(data);
                _db.SaveChanges();
                var datalist = _db.Catagories.ToList();
                var jsonData = datalist.Select(c => new { c.Id, c.Code, c.Name });
                return Json(jsonData, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}