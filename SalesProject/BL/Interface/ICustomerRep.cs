using SalesProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesProject.BL.Interface
{
    public interface ICustomerRep
    {
        IQueryable<CustomersVM> GetAllCustomerData();
        void AddCustomerData(CustomersVM cus);
        CustomersVM GetCustomerDataById(int id);
        void EditCustomerData(CustomersVM cus);
        void DeleteCustomerData(int id);
    }
}
