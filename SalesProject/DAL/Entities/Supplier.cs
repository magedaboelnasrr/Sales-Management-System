using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SalesProject.DAL.Entities
{
    [Table("Supplier")]
    public class Supplier
    {
        [Key]
        public int Id { get; set; }
        public string SupplierName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public virtual ICollection<Purchases> Purchases { get; set; }

    }
}
