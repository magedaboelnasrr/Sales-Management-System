using SalesProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesProject.BL.Interface
{
    public interface ISupplierRep
    {
        IEnumerable<SupplierVM> GetAllSupplierData();
        void AddSupplierData(SupplierVM sup);
        SupplierVM GetSupplierDataById(int id);
        void EditSupplierData(SupplierVM sup);
        void DeleteSupplierData(int id);
    }
}
