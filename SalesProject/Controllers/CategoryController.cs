using Microsoft.AspNetCore.Mvc;
using SalesProject.BL.Interface;
using SalesProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesProject.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRep category;

        public CategoryController(ICategoryRep category)
        {
            this.category = category;
        }
        public IActionResult Index()
        {
            //v/*ar search = category.SearchCategoryData(name);*/

            var data = category.GetAllCategoryData();
            return View(data);
        }
        //[HttpGet]
        //public IActionResult search (string name)
        //{
            
            
        //    return View(search);
        //}
        [HttpGet]
        public IActionResult AddCategoryData()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddCategoryData(CategoryVM cat)
        {
            if (ModelState.IsValid)
            {
                category.AddCategoryData(cat);
                return RedirectToAction("Index", "Category");
            }
            return View(cat);
        }
        [HttpGet]
        public IActionResult EditCategoryData(int id)
        {
            var data = category.GetCategoryDataById(id);
            return View(data);
        }
        [HttpPost]
        public IActionResult EditCategoryData(CategoryVM cat)
        {
            if (ModelState.IsValid)
            {
                category.EditCategoryData(cat);
                return View("Index", "Category");
            }
            return View(cat);
        }
        [HttpGet]
        public IActionResult DeleteCategoryData(int id)
        {
            var data = category.GetCategoryDataById(id);
            return View(data);
        }
        [HttpPost]
        [ActionName("DeleteCategoryData")]
        public IActionResult ConfirmDeleteCategoryData(int id)
        {
            category.DeleteCategoryData(id);
            return RedirectToAction("Index", "Category");
        }
    }
}
