using AutoMapper;
using SalesProject.DAL.Entities;
using SalesProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesProject.BL.Mapper
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<Category, CategoryVM>();
            CreateMap<CategoryVM, Category>();

            CreateMap<Supplier, SupplierVM>();
            CreateMap<SupplierVM, Supplier>();

            CreateMap<Purchases, PurchasesVM>();
            CreateMap<PurchasesVM, Purchases>();

            CreateMap<Customers, CustomersVM>();
            CreateMap<CustomersVM, Customers>();
        }
    }
}
