using BMS.Models.BaseModels;
using BMS.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Transactions;
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
        public ActionResult Create()
        {

            var model = new Purchase()
            {
                ProductLookUp = ProductListLookUp(),
                SupplierLookUp = SupplierListLookUp(),
            };
            return View(model);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        // public ActionResult Create(PurchaseDetails asd, Purchase purchase )
        public ActionResult Create(Purchase purchase)
        {

            if (ModelState.IsValid)
            {
                //_db.PurchaseDetails.Add(purchaseDetails);
                _db.Purchases.Add(purchase);
                var isAdded = _db.SaveChanges() > 0;
                if (isAdded)
                {
                    var stockModel = StockAddOrUpdate(purchase.GetStockModel());
                }

            }

            purchase.ProductLookUp = ProductListLookUp();
            purchase.SupplierLookUp = SupplierListLookUp();
            return View(purchase);


        }


        //Move this Method to StockManager
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




        public List<SelectListItem> ProductListLookUp()
        {
            var dataList = _db.Products.ToList();
            var selectedList = new List<SelectListItem>();
            selectedList.AddRange(GetDefaultSelectedList());
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

        public List<SelectListItem> SupplierListLookUp()
        {
            var dataList = _db.Supliers.ToList();
            var selectedList = new List<SelectListItem>();
            selectedList.AddRange(GetDefaultSelectedList());
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


        public List<SelectListItem> GetDefaultSelectedList()
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