using MyPurse.BLL.Interfaces;
using MyPurse.Domain;
using MyPurse.Repository;
using MyPurse.Repository.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MyPurse.BLL.Business
{
    public class AccountBusiness : IAccountBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly AccountRepository accRep;

        public AccountBusiness(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            accRep = new AccountRepository(unitOfWork);
        }

        public List<AccountDomainModel> GetAccounts()
        {
            List<AccountDomainModel> list = accRep.GetAll().Select(m => new AccountDomainModel { ID = m.ID, Name = m.Name, Amount = m.Amount }).ToList();
            return list;
        }

        public void Delete(int ID)
        {
            accRep.Delete(x => x.ID == ID);
        }

        public string Edit(AccountDomainModel DM)
        {
            if ((DM.Name == null) || (Convert.ToDouble(DM.Amount) < 0))
            {
                return "One or more fields are empty";
            }
            else
            {
                account acc = accRep.SingleOrDefault(x => x.ID == DM.ID);
                acc.Name = DM.Name;
                acc.Amount = Convert.ToDouble(DM.Amount);
                accRep.Update(acc);
                return "";
            }
        }

        public account GetAccount(int accID)
        {
            account acc = accRep.SingleOrDefault(x=>x.ID == accID);
            return acc;
        }

        public string Add(AccountDomainModel DM)
        {
            if ((DM.Name == null) || (Convert.ToDouble(DM.Amount) < 0))
            {
                return "One or more fields are empty";
            }
            else
            {
                account acc = new account();
                acc.Name = DM.Name;
                acc.Amount = Convert.ToDouble(DM.Amount);
                accRep.Insert(acc);
                return "";
            }
        }
    }
}
