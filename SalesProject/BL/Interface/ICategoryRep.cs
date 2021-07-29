using SalesProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesProject.BL.Interface
{
    public interface ICategoryRep
    {
        IEnumerable<CategoryVM> GetAllCategoryData();
        void AddCategoryData(CategoryVM cat);
        CategoryVM GetCategoryDataById(int id);
        void EditCategoryData(CategoryVM cat);
        void DeleteCategoryData(int id);
        //IEnumerable<CategoryVM> SearchCategoryData(string name);

    }
}
