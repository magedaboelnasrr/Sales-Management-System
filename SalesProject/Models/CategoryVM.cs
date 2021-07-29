using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using SalesProject.DAL.Entities;

namespace SalesProject.Models
{
    public class CategoryVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Category Name Required")]
        public string CategoryName { get; set; }
        public IFormFile PhotoUrl { get; set; }
        public string PhotoName { get; set; }
        
    }
}
