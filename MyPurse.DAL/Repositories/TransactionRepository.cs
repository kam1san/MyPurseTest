using System;
using System.Collections.Generic;
using System.Linq;
using MyPurse.DAL.Entities;
using MyPurse.DAL.EF;
using MyPurse.DAL.Interfaces;
using System.Data.Entity;

namespace MyPurse.DAL.Repositories
{
    public class TransactionRepository : IRepository<Transaction>
    {
        private PurseContext db;

        public TransactionRepository(PurseContext context)
        {
            this.db = context;
        }

        public IEnumerable<Transaction> GetAll()
        {
            return db.Transactions;
        }

        public Transaction Get(int ID)
        {
            return db.Transactions.Find(ID);
        }

        public void Create(Transaction ts)
        {
            db.Transactions.Add(ts);
        }

        public void Update(Transaction ts)
        {
            db.Entry(ts).State = EntityState.Modified;
        }

        public IEnumerable<Transaction> Find(Func<Transaction, Boolean> predicate)
        {
            return db.Transactions.Where(predicate).ToList();
        }

        public void Delete(int ID)
        {
            Transaction ts = db.Transactions.Find(ID);
            if (ts != null)
                db.Transactions.Remove(ts);
        }
    }
}