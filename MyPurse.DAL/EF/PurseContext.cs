using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using MyPurse.DAL.Entities;

namespace MyPurse.DAL.EF
{
    public class PurseContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        
        public PurseContext(string connectionString)
            : base(connectionString)
        {
        }
    }
}