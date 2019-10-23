using BMS.Models.BaseModels;
using BMS.Models.ViewModels;
using BMS.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Transactions;
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
        public ActionResult Create()
        {
            var model = new Sale()
            {
                CustomerLookUp = CustomersListLookUp(),
                ProductLookUp = ProductListLookUp(),
            };
            return View(model);
        }

        [HttpGet]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Sale sale)
        {
            sale.CustomerLookUp = CustomersListLookUp();
            sale.ProductLookUp = ProductListLookUp();

            if (ModelState.IsValid)
            {
                _db.Sales.Add(sale);
                var isAdded = _db.SaveChanges() > 0;
                if (isAdded)
                {
                    var stockModel= StockAddOrUpdate(sale.GetStockModel());
                }
            }

            return View(sale);
        }


        public bool StockAddOrUpdate(List<Stock> stocks)
        {
            var isAddOrUpdated = false;

            if (stocks != null && stocks.Any())
            {

                // Find ProductId List
                var productIds = stocks.Select(c => c.ProductId).Distinct().ToList();

                // Get Those Product from Db With a Single Query
                var updateableStocks = _db.Stocks.Where(c => productIds.Contains(c.ProductId)).ToList();

                //Update Old Stock Qty
                foreach (var oldStock in updateableStocks)
                {
                    oldStock.Qty += stocks.Where(c => c.ProductId == oldStock.ProductId)?.Sum(c => c.Qty) ?? 0;
                }


                //Find New Stock Products
                var oldProductIds = updateableStocks.Select(c => c.ProductId).Distinct().ToList();
                var newProductIds = productIds.Where(c => !oldProductIds.Contains(c));

                //find New Addable Items
                var addableStock = new List<Stock>();
                foreach (var productId in newProductIds)
                {
                    var stock = new Stock
                    {
                        Qty = stocks.Where(c => c.ProductId == productId)?.Sum(c => c.Qty) ?? 0,
                        ProductId = productId
                    };
                    addableStock.Add(stock);
                }



                //Use Transaction Scope For Holding Database
                using (var ts = new TransactionScope())
                {

                    _db.Stocks.AddRange(addableStock);

                    foreach (var updateableStock in updateableStocks)
                    {
                        _db.Stocks.AddOrUpdate(updateableStock);
                    }

                    isAddOrUpdated = _db.SaveChanges() > 0;

                    if (isAddOrUpdated)
                    {
                        ts.Complete();
                    }

                }



                //foreach (var stock in stocks)
                //{
                //    var olf = _db.Stocks.FirstOrDefault(c => c.ProductId == stock.ProductId);
                //}

            }

            return isAddOrUpdated;
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
        public List<SelectListItem> CustomersListLookUp()
        {
            var dataList = _db.Customers.ToList();
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
        public JsonResult CallProductProperty(string id)
        {
            long pId = Convert.ToInt64(id);
            var datalist = _db.Products.ToList();

            var jsonData = datalist.Where(c => c.Id == pId).ToList().Select(e => new { e.ReorderLevel, e.CostPrice });
               
            return Json(jsonData, JsonRequestBehavior.AllowGet);

        }
        public JsonResult CallCustomerLoyalityPoint(string id)
        {
            long pId = Convert.ToInt64(id);
            var datalist = _db.Customers.ToList();

            var jsonData = datalist.Where(c => c.Id == pId).ToList().Select(e => new { e.LoyaltyPoint });

            return Json(jsonData, JsonRequestBehavior.AllowGet);

        }





    }
}