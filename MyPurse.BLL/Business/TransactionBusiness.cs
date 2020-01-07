using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using MyPurse.BLL.Interfaces;
using MyPurse.Domain;
using MyPurse.Repository;
using MyPurse.Repository.Infrastructure;
using MyPurse.Repository.Infrastructure.Interfaces;

namespace MyPurse.BLL.Business
{
    public class TransactionBusiness:ITransactionBusiness
    {

        private readonly IUnitOfWork unitOfWork;
        private readonly TransactionRepository tsRep;
        private readonly AccountRepository accRep;
        private readonly TypeRepository tRep;

        public TransactionBusiness(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            tsRep = new TransactionRepository(unitOfWork);
            accRep = new AccountRepository(unitOfWork);
            tRep = new TypeRepository(unitOfWork);
        }

        public List<TransactionDomainModel> GetTransactions()
        {
            List<TransactionDomainModel> list = tsRep.GetAll().Select(m => new TransactionDomainModel { ID = m.ID, AccountID = m.AccountID, Amount = m.Amount, TransactionType=m.TransactionType, AccountTransferTo=m.AccountTransferTo, Date = m.Date }).ToList();
            return list;
        }

        public void Delete(int ID)
        {
            tsRep.Delete(x => x.ID == ID);
        }

        public string AddIn(TransactionDomainModel ts)
        {
            if ((Convert.ToInt32(ts.AccountID) == 0) || (Convert.ToInt32(ts.Amount) == 0) || (Convert.ToInt32(ts.TransactionType) == 0) || (ts.Date == Convert.ToDateTime("01-01-0001")))
            {
                return "One or more fields are empty";
            }
            else
            {
                account acc = accRep.SingleOrDefault(x=>x.ID==ts.AccountID);
                transaction trans = new transaction();
                trans.AccountID = ts.AccountID;
                trans.Amount = Convert.ToDouble(ts.Amount);
                acc.Amount += trans.Amount;
                trans.TransactionType = ts.TransactionType;
                trans.AccountTransferTo = ts.AccountTransferTo;
                trans.Date = ts.Date;
                accRep.Update(acc);
                tsRep.Insert(trans);
                return "";
            }
        }

        public string AddOut(TransactionDomainModel ts)
        {
            if ((Convert.ToInt32(ts.AccountID) == 0) || (Convert.ToInt32(ts.Amount) == 0) || (Convert.ToInt32(ts.TransactionType) == 0) || (ts.Date == Convert.ToDateTime("01-01-0001")))
            {
                return "One or more fields are empty";
            }
            else
            {
                account acc = accRep.SingleOrDefault(x => x.ID == ts.AccountID);
                transaction trans = new transaction();
                if (acc.Amount < ts.Amount)
                {
                    return "Insufficient funds";
                }
                else
                {
                    trans.AccountID = ts.AccountID;
                    trans.Amount = Convert.ToDouble(ts.Amount);
                    acc.Amount -= trans.Amount;
                    trans.TransactionType = ts.TransactionType;
                    trans.AccountTransferTo = ts.AccountTransferTo;
                    trans.Date = ts.Date;
                    accRep.Update(acc);
                    tsRep.Insert(trans);
                    return "";
                }
            }
        }

        public string AddTransfer(TransactionDomainModel ts)
        {
            if ((Convert.ToInt32(ts.AccountID) == 0) || (Convert.ToInt32(ts.Amount) == 0) || (Convert.ToInt32(ts.TransactionType) == 0) || (Convert.ToInt32(ts.AccountTransferTo) == 0) || (ts.Date == Convert.ToDateTime("01-01-0001")))
            {
                return "One or more fields are empty";
            }
            else
            {
                if (ts.AccountID == ts.AccountTransferTo)
                {
                    return "You cant transfer from and to one account";
                }
                else
                {
                    account acc = accRep.SingleOrDefault(x => x.ID == ts.AccountID);
                    account acc_to = accRep.SingleOrDefault(x => x.ID == ts.AccountTransferTo);
                    transaction trans = new transaction();
                    if (acc.Amount < ts.Amount)
                    {
                        return "Insufficient funds";
                    }
                    else
                    {
                        trans.AccountID = ts.AccountID;
                        trans.Amount = Convert.ToDouble(ts.Amount);
                        acc.Amount -= trans.Amount;
                        acc_to.Amount += trans.Amount;
                        trans.TransactionType = ts.TransactionType;
                        trans.AccountTransferTo = ts.AccountTransferTo;
                        trans.Date = ts.Date;
                        accRep.Update(acc);
                        accRep.Update(acc_to);
                        tsRep.Insert(trans);
                        return "";
                    }
                }
            }
            
        }

        public transaction GetTransaction(int ID)
        {
            transaction ts = tsRep.SingleOrDefault(x => x.ID == ID);
            return ts;
        }

        public string Edit(TransactionDomainModel ts)
        {
            if ((Convert.ToInt32(ts.AccountID) == 0) || (Convert.ToInt32(ts.Amount) == 0) || (Convert.ToInt32(ts.TransactionType) == 0) || (ts.Date == Convert.ToDateTime("01-01-0001")))
            {
                return "One or more fields are empty";
            }
            else
            {
                trans_type t_type = tRep.SingleOrDefault(x => x.ID == ts.TransactionType);
                transaction trans = tsRep.SingleOrDefault(x => x.ID == ts.ID);
                if (ts.AccountID == ts.AccountTransferTo)
                {
                    return "You cant transfer from and to one account";
                }
                    if (t_type.Description != "Transfer" && ts.AccountTransferTo != null) 
                    {
                        return "Speciefied operation is not transfer, so it can't have 'transfer to' field";
                    }
                        trans.AccountID = ts.AccountID;
                        trans.Amount = Convert.ToDouble(ts.Amount);
                        trans.TransactionType = ts.TransactionType;
                    if (t_type.Description == "Transfer"&& ts.AccountTransferTo == null)
                            return "No destination account of the transfer was specified";
                    trans.AccountTransferTo = ts.AccountTransferTo;
                    trans.Date = ts.Date;
                        tsRep.Update(trans);
                        return "";
            }
        }

        public List<TransactionDomainModel> CategorySort(TransactionDomainModel DM)
        {
            List<TransactionDomainModel> list = tsRep.GetAll(x=>x.TransactionType==DM.TransactionType).Select(m => new TransactionDomainModel { ID = m.ID, AccountID = m.AccountID, Amount = m.Amount, TransactionType = DM.TransactionType, AccountTransferTo = m.AccountTransferTo, Date = m.Date }).ToList();
            return list;
        }
    }
}
