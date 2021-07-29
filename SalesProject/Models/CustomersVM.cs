using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SalesProject.Models
{
    public class CustomersVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Name is Required")]
        public string CustomerName { get; set; }
        [Required(ErrorMessage ="Phone is Required")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage ="Email is Required")]
        public string Email { get; set; }
    }
}
