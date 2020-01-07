using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyPurse.Domain;
using MyPurse.Repository;

namespace MyPurse.BLL.Interfaces
{
    public interface ITransactionBusiness
    {
        List<TransactionDomainModel> GetTransactions();
        transaction GetTransaction(int ID);
        void Delete(int ID);
        string AddIn(TransactionDomainModel DM);
        string AddOut(TransactionDomainModel DM);
        string AddTransfer(TransactionDomainModel DM);
        string Edit(TransactionDomainModel DM);
        List<TransactionDomainModel> CategorySort(TransactionDomainModel DM);
    }
}
