using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SalesProject.BL.Interface;
using SalesProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesProject.Controllers
{
    public class PurchaseController : Controller
    {
        private readonly IPurchaseRep purchase;
        private readonly ICategoryRep category;
        private readonly ISupplierRep supplier;

        public PurchaseController(IPurchaseRep purchase, ICategoryRep category, ISupplierRep supplier)
        {
            this.purchase = purchase;
            this.category = category;
            this.supplier = supplier;
        }
        public IActionResult Index()
        {
            var data = purchase.GetAllPurchaseData();
            return View(data);
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            var data = purchase.PurchaseDetails(id);
            return View(data);
        }
        [HttpGet]
        public IActionResult AddPurchasesData()
        {


            var CategoryData = category.GetAllCategoryData();
            var SupplierData = supplier.GetAllSupplierData();
            ViewBag.CategoryId = new SelectList(CategoryData, "Id", "CategoryName");
            ViewBag.SupplierId = new SelectList(SupplierData, "Id", "SupplierName");

            return View();
        }
        [HttpPost]
        public IActionResult AddPurchasesData(PurchasesVM pur)
        {
            if (ModelState.IsValid)
            {
                //pur.SalesTotalPrice = pur.SellingPrice * pur.PurchaseQuantity;
                //ViewBag.tsell = pur.SalesTotalPrice;
                //pur.PurchasesTotalPrice = pur.PurchasingPrice * pur.PurchaseQuantity;
                //ViewBag.tbuy = pur.PurchasesTotalPrice;
                //pur.TotalProfit = (pur.SellingPrice * pur.PurchaseQuantity) - (pur.PurchasingPrice * pur.PurchaseQuantity);
                //ViewBag.profit = pur.TotalProfit;

                purchase.AddPurchasesData(pur);
                return RedirectToAction("Index", "Purchase");
            }
            else
            {
                var CategoryData = category.GetAllCategoryData();
                var SupplierData = supplier.GetAllSupplierData();
                ViewBag.CategoryId = new SelectList(CategoryData, "Id", "CategoryName");
                ViewBag.SupplierId = new SelectList(SupplierData, "Id", "SupplierName");
                return View(pur);
            }

        }
        [HttpGet]
        public IActionResult EditPurchaseData(int id)
        {
            var data = purchase.GetPurchaseDataById(id);
            var CategoryData = category.GetAllCategoryData();
            var SupplierData = supplier.GetAllSupplierData();
            ViewBag.CategoryId = new SelectList(CategoryData, "Id", "CategoryName", data.CategoryId);
            ViewBag.SupplierId = new SelectList(SupplierData, "Id", "SupplierName", data.SupplierId);
            return View(data);
        }
        [HttpPost]
        public IActionResult EditPurchaseData(PurchasesVM pur)
        {
            if (ModelState.IsValid)
            {
                purchase.EditPurchaseData(pur);
                return RedirectToAction("Index", "Purchase");
            }
            else
            {
                var CategoryData = category.GetAllCategoryData();
                var SupplierData = supplier.GetAllSupplierData();
                ViewBag.CategoryId = new SelectList(CategoryData, "Id", "CategoryName", pur.CategoryId).ToList();
                ViewBag.SupplierId = new SelectList(SupplierData, "Id", "SupplierName", pur.SupplierId).ToList();
                return View(pur);
            }


        }
        [HttpGet]
        public IActionResult DeletePurchaseData(int id)
        {
            var CategoryData = category.GetAllCategoryData();
            var SupplierData = supplier.GetAllSupplierData();
            var data = purchase.GetPurchaseDataById(id);
            ViewBag.CategoryId = new SelectList(CategoryData, "Id", "CategoryName", data.CategoryId);
            ViewBag.SupplierId = new SelectList(SupplierData, "Id", "SupplierName", data.SupplierId);
            return View(data);
        }
        [HttpPost]
        [ActionName("DeletePurchaseData")]
        public IActionResult ConfirmDeletePurchaseData(int id)
        {
            purchase.DeletePurchaseData(id);
            return RedirectToAction("Index", "Purchase");
        }
    }
}
