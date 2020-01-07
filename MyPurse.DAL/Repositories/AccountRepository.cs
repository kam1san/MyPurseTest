using System;
using System.Collections.Generic;
using System.Linq;
using MyPurse.DAL.Entities;
using MyPurse.DAL.EF;
using MyPurse.DAL.Interfaces;
using System.Data.Entity;

namespace MyPurse.DAL.Repositories
{
    public class AccountRepository : IRepository<Account>
    {
        private PurseContext db;

        public AccountRepository(PurseContext context)
        {
            this.db = context;
        }

        public IEnumerable<Account> GetAll()
        {
            return db.Accounts;
        }

        public Account Get(int ID)
        {
            return db.Accounts.Find(ID);
        }

        public void Create(Account acc)
        {
            db.Accounts.Add(acc);
        }

        public void Update(Account acc)
        {
            db.Entry(acc).State = EntityState.Modified;
        }

        public IEnumerable<Account> Find(Func<Account, Boolean> predicate)
        {
            return db.Accounts.Where(predicate).ToList();
        }

        public void Delete(int ID)
        {
            Account acc = db.Accounts.Find(ID);
            if (acc != null)
                db.Accounts.Remove(acc);
        }
    }
}