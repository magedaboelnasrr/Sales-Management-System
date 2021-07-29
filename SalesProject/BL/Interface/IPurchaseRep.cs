using SalesProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesProject.BL.Interface
{
    public interface IPurchaseRep
    {
        IEnumerable<PurchasesVM> GetAllPurchaseData();
        void AddPurchasesData(PurchasesVM pur);
        PurchasesVM GetPurchaseDataById(int id);
        void EditPurchaseData(PurchasesVM pur);
        void DeletePurchaseData(int id);
        IEnumerable<PurchasesVM> PurchaseDetails(int id);

    }
}
