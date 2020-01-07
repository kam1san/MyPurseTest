using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyPurse.Domain;
using MyPurse.Repository;

namespace MyPurse.BLL.Interfaces
{
    public interface IAccountBusiness
    {
        List<AccountDomainModel> GetAccounts();
        void Delete(int ID);
        string Edit(AccountDomainModel DM);
        string Add(AccountDomainModel DM);
        account GetAccount(int ID);
    }
}
