using Microsoft.AspNetCore.Mvc;
using SalesProject.BL.Interface;
using SalesProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesProject.Controllers
{
    public class SupplierController : Controller
    {
        private readonly ISupplierRep supplier;

        public SupplierController(ISupplierRep supplier)
        {
            this.supplier = supplier;
        }
        public IActionResult Index()
        {
            var data = supplier.GetAllSupplierData();
            return View(data);
        }
        [HttpGet]
        public IActionResult AddSupplierData()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddSupplierData(SupplierVM sup)
        {
            if (ModelState.IsValid)
            {
                supplier.AddSupplierData(sup);
                return RedirectToAction("Index", "Supplier");
            }
            return View(sup);
        }
        [HttpGet]
        public IActionResult EditSupplierData(int id)
        {
            var data = supplier.GetSupplierDataById(id);
            return View(data);
        }
        [HttpPost]
        public IActionResult EditSupplierData(SupplierVM sup)
        {
            if (ModelState.IsValid)
            {
                supplier.EditSupplierData(sup);
                return RedirectToAction("Index", "Supplier");
            }
            return View(sup);
        }
        [HttpGet]
        public IActionResult DeleteSupplierData(int id)
        {
            var data = supplier.GetSupplierDataById(id);
            return View(data);
        }
        [HttpPost]
        [ActionName("DeleteSupplierData")]
        public IActionResult ConfirmDeleteSupplierData(int id)
        {
            supplier.DeleteSupplierData(id);
            return RedirectToAction("Index", "Supplier");
        }
    }
}
