using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SalesProject.DAL.Entities
{
    [Table("Purchases")]
    public class Purchases
    {
        [Key]
        public int Id { get; set; }
        public string PurchaseName { get; set; }
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
        public int SupplierId { get; set; }
        [ForeignKey("SupplierId")]
        public Supplier Supplier { get; set; }
        public string PurchaseDetails { get; set; }
        public float PurchasingPrice { get; set; }
        public float SellingPrice { get; set; }
        public float PurchaseQuantity { get; set; }
        public float PurchasesTotalPrice { get; set; }
        public float SalesTotalPrice { get; set; }
        public float TotalProfit { get; set; }

    }
}
