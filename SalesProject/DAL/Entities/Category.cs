using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SalesProject.DAL.Entities
{
    [Table("Category")]
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string PhotoName { get; set; }
        public virtual ICollection<Purchases> Purchases { get; set; }
    }
}
