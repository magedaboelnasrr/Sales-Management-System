using AutoMapper;
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
    public class PurchaseRep : IPurchaseRep
    {
        private readonly DbContainer db;
        private readonly IMapper mapper;
        public PurchaseRep(DbContainer db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }
        public IEnumerable<PurchasesVM> GetAllPurchaseData()
        {
            var data = db.Purchases.Select(a => new PurchasesVM { Id = a.Id, PurchaseName = a.PurchaseName, PurchaseDetails = a.PurchaseDetails, PurchaseQuantity = a.PurchaseQuantity, PurchasesTotalPrice = a.PurchasesTotalPrice, PurchasingPrice = a.PurchasingPrice, SalesTotalPrice = a.SalesTotalPrice, SellingPrice = a.SellingPrice, TotalProfit = a.TotalProfit, CategoryId = a.CategoryId,CategoryName =a.Category.CategoryName, SupplierId = a.SupplierId , SupplierName = a.Supplier.SupplierName });
            return data;
        }
        public void AddPurchasesData(PurchasesVM pur)
        {
            var data = mapper.Map<Purchases>(pur);

            data.SalesTotalPrice = data.SellingPrice * data.PurchaseQuantity;

            data.PurchasesTotalPrice = data.PurchasingPrice * data.PurchaseQuantity;

            data.TotalProfit = (data.SellingPrice * data.PurchaseQuantity) - (data.PurchasingPrice * data.PurchaseQuantity);


            db.Purchases.Add(data);
            db.SaveChanges();
        }

        public PurchasesVM GetPurchaseDataById(int id)
        {
            var data = db.Purchases.Where(a => a.Id == id).Select(a => new PurchasesVM { Id = a.Id, PurchaseName = a.PurchaseName, PurchaseDetails = a.PurchaseDetails, PurchaseQuantity = a.PurchaseQuantity, PurchasesTotalPrice = a.PurchasesTotalPrice, PurchasingPrice = a.PurchasingPrice, SalesTotalPrice = a.SalesTotalPrice, SellingPrice = a.SellingPrice, TotalProfit = a.TotalProfit, CategoryId = a.CategoryId, CategoryName = a.Category.CategoryName, SupplierId = a.SupplierId, SupplierName = a.Supplier.SupplierName }).FirstOrDefault();
            return data;
        }

        public void EditPurchaseData(PurchasesVM pur)
        {
            var data = mapper.Map<Purchases>(pur);

            data.SalesTotalPrice = data.SellingPrice * data.PurchaseQuantity;

            data.PurchasesTotalPrice = data.PurchasingPrice * data.PurchaseQuantity;

            data.TotalProfit = (data.SellingPrice * data.PurchaseQuantity) - (data.PurchasingPrice * data.PurchaseQuantity);

            db.Entry(data).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
        }

        public void DeletePurchaseData(int id)
        {
            var data = db.Purchases.Find(id);
            db.Purchases.Remove(data);
            db.SaveChanges();
        }

        public IEnumerable<PurchasesVM> PurchaseDetails(int id)
        {
            var data = db.Purchases.Where(a => a.Id == id).Select(a => new PurchasesVM { Id = a.Id, PurchaseName = a.PurchaseName, PurchaseDetails = a.PurchaseDetails, PurchaseQuantity = a.PurchaseQuantity, PurchasesTotalPrice = a.PurchasesTotalPrice, PurchasingPrice = a.PurchasingPrice, SalesTotalPrice = a.SalesTotalPrice, SellingPrice = a.SellingPrice, TotalProfit = a.TotalProfit, CategoryId = a.CategoryId, CategoryName = a.Category.CategoryName, SupplierId = a.SupplierId, SupplierName = a.Supplier.SupplierName });
            return data;
        }
    }
}
