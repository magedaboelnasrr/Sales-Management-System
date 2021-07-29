using AutoMapper;
using SalesProject.BL.Helper;
using SalesProject.BL.Interface;
using SalesProject.DAL.Database;
using SalesProject.DAL.Entities;
using SalesProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesProject.BL.Repository
{
    public class CategoryRep : ICategoryRep
    {
        private readonly DbContainer db;
        private readonly IMapper mapper;

        public CategoryRep(DbContainer db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }
        public IEnumerable<CategoryVM> GetAllCategoryData()
        {
            var data = db.Category.Select(a => new CategoryVM { Id = a.Id, CategoryName = a.CategoryName, PhotoName = a.PhotoName });
            return data;
        }
        public void AddCategoryData(CategoryVM cat)
        {
            var data = mapper.Map<Category>(cat);
            data.PhotoName = UploadFileHelper.SaveFile(cat.PhotoUrl, "Photos");
            db.Category.Add(data);
            db.SaveChanges();
        }

        public CategoryVM GetCategoryDataById(int id)
        {
            var data = db.Category.Where(a => a.Id == id).Select(a => new CategoryVM { Id = a.Id, CategoryName = a.CategoryName, PhotoName = a.PhotoName }).FirstOrDefault();
            return data;
        }

        public void EditCategoryData(CategoryVM cat)
        {
            var data = mapper.Map<Category>(cat);
            data.PhotoName = UploadFileHelper.SaveFile(cat.PhotoUrl, "Photos");
            db.Entry(data).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
        }

        public void DeleteCategoryData(int id)
        {
            var data = db.Category.Find(id);
            UploadFileHelper.RemoveFile("Photos", data.PhotoName);
            db.Category.Remove(data);
            db.SaveChanges();
        }

        //public  CategoryVM SearchCategoryData(string name)
        //{
        //    //var data = db.Category.Where(a => a.CategoryName.Contains(name)).Select(a => new CategoryVM { CategoryName = a.CategoryName, PhotoName = a.PhotoName }).FirstOrDefault();

        //    var data = db.Category.Where(a => a.CategoryName.Contains(name) || name == null).ToList().Select(a => new CategoryVM { CategoryName = a.CategoryName, PhotoName = a.PhotoName }).FirstOrDefault();
        //    return data;
    }
}

