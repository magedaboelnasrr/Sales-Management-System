using Microsoft.AspNetCore.Mvc;
using SalesProject.BL.Interface;
using SalesProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesProject.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerRep customer;

        public CustomerController(ICustomerRep customer)
        {
            this.customer = customer;
        }
        public IActionResult Index()
        {
            var data = customer.GetAllCustomerData();
            return View(data);
        }
        [HttpGet]
        public IActionResult AddCustomerData()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddCustomerData(CustomersVM cus)
        {
            if (ModelState.IsValid)
            {
                customer.AddCustomerData(cus);
                return RedirectToAction("Index", "Customer");
            }
            return View(cus);
        }
        [HttpGet]
        public IActionResult EditCustomerData (int id)
        {
            var data = customer.GetCustomerDataById(id);
            return View(data);
        }
        [HttpPost]
        public IActionResult EditCustomerData (CustomersVM cus)
        {
            if (ModelState.IsValid)
            {
                customer.EditCustomerData(cus);
                return RedirectToAction("Index", "Customer");
            }
            return View(cus);
        }
        [HttpGet]
        public IActionResult DeleteCustomerData (int id)
        {
            var data = customer.GetCustomerDataById(id);
            return View(data);
        }
        [HttpPost]
        [ActionName("DeleteCustomerData")]
        public IActionResult ConfirmDeleteCustomerData(int id)
        {
            customer.DeleteCustomerData(id);
            return RedirectToAction("Index", "Customer");
        }
    }
}
