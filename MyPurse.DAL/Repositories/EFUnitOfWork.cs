using System;
using MyPurse.DAL.EF;
using MyPurse.DAL.Interfaces;
using MyPurse.DAL.Entities;
using MyPurse.DAL.Repositories;

namespace MyPurse.DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private PurseContext db;
        private AccountRepository accRepository;
        private TransactionRepository tsRepository;

        public EFUnitOfWork(string connectionString)
        {
            db = new PurseContext(connectionString);
        }
        public IRepository<Account> Accounts
        {
            get
            {
                if (accRepository == null)
                    accRepository = new AccountRepository(db);
                return accRepository;
            }
        }

        public IRepository<Transaction> Transactions
        {
            get
            {
                if (tsRepository == null)
                    tsRepository = new TransactionRepository(db);
                return tsRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}