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
    public class CustomerRep : ICustomerRep
    {
        private readonly DbContainer db;
        private readonly IMapper mapper;

        public CustomerRep(DbContainer db , IMapper mapper )
        {
            this.db = db;
            this.mapper = mapper;
        }
        public IQueryable<CustomersVM> GetAllCustomerData()
        {
            var data = db.Customers.Select(a => new CustomersVM { Id = a.Id, CustomerName = a.CustomerName, PhoneNumber = a.PhoneNumber, Email = a.Email });
            return data;
        }
        public void AddCustomerData(CustomersVM cus)
        {
            var data = mapper.Map<Customers>(cus);
            db.Customers.Add(data);
            db.SaveChanges();
        }

        public CustomersVM GetCustomerDataById(int id)
        {
            var data = db.Customers.Where(a => id == a.Id).Select(a => new CustomersVM { Id = a.Id, CustomerName = a.CustomerName, PhoneNumber = a.PhoneNumber, Email = a.Email }).FirstOrDefault();
            return data;
        }

        public void EditCustomerData(CustomersVM cus)
        {
            var data = mapper.Map<Customers>(cus);
            db.Entry(data).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
        }

        public void DeleteCustomerData(int id)
        {
            var data = db.Customers.Find(id);
            db.Customers.Remove(data);
            db.SaveChanges();
        }
    }
}
