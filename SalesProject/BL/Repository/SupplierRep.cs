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
    public class SupplierRep : ISupplierRep
    {
        private readonly DbContainer db;
        private readonly IMapper mapper;

        public SupplierRep(DbContainer db , IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public IEnumerable<SupplierVM> GetAllSupplierData()
        {
            var data = db.Supplier.Select(a => new SupplierVM { Id = a.Id, SupplierName = a.SupplierName, PhoneNumber = a.PhoneNumber, Email = a.Email });
            return data;
        }
        public void AddSupplierData(SupplierVM sup)
        {
            var data = mapper.Map<Supplier>(sup);
            db.Supplier.Add(data);
            db.SaveChanges();
        }

        public SupplierVM GetSupplierDataById(int id)
        {
            var data = db.Supplier.Where(a => a.Id == id).Select(a => new SupplierVM { Id = a.Id, SupplierName = a.SupplierName, PhoneNumber = a.PhoneNumber, Email = a.Email }).FirstOrDefault();
            return data;
        }

        public void EditSupplierData(SupplierVM sup)
        {
            var data = mapper.Map<Supplier>(sup);
            db.Entry(data).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
        }

        public void DeleteSupplierData(int id)
        {
            var data = db.Supplier.Find(id);
            db.Supplier.Remove(data);
            db.SaveChanges();
        }
    }
}
