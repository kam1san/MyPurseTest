using MyPurse.Repository.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPurse.Repository.Infrastructure
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly MyPurseEntitiesContainer _dbContext;

        public UnitOfWork()
        {
            _dbContext = new MyPurseEntitiesContainer();
        }

        public DbContext Db
        {
            get { return _dbContext; }
        }

        public void Dispose()
        {
        }
    }
}
