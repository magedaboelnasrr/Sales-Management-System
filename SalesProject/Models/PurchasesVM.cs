using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using SalesProject.DAL.Entities;

namespace SalesProject.Models
{
    public class PurchasesVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Purchased Name Required")]
        public string PurchaseName { get; set; }
        [Required(ErrorMessage = "Category Name Required")]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        [Required(ErrorMessage = "Supplier Name Required")]
        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
        [Required(ErrorMessage = "Details Required")]
        public string PurchaseDetails { get; set; }
        [Required(ErrorMessage = "Purchasing Price Required")]
        public float PurchasingPrice { get; set; }
        [Required(ErrorMessage = "Selling Price Required")]
        public float SellingPrice { get; set; }
        [Required(ErrorMessage = "Quantity Required")]
        public float PurchaseQuantity { get; set; }
        public float PurchasesTotalPrice { get; set; }
        public float SalesTotalPrice { get; set; }
        public float TotalProfit { get; set; }
    }
}
