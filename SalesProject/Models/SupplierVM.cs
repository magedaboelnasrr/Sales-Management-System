using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using SalesProject.DAL.Entities;

namespace SalesProject.Models
{
    public class SupplierVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Name Required")]
        [MinLength(3,ErrorMessage ="Minimum 3 Char")]
        [StringLength(10,ErrorMessage ="Maximum 10 Char")]
        public string SupplierName { get; set; }
        [Required(ErrorMessage ="Phone Required")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage ="Email Required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        
    }
}
