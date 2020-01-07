using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyPurse.DAL.Entities;

namespace MyPurse.DAL.Interfaces
{
    public interface IUnitOfWork:IDisposable
    {
        IRepository<Account> Accounts { get; }
        IRepository<Transaction> Transactions { get; }
        void Save();
    }
}
