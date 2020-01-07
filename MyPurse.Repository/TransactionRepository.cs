using MyPurse.Repository.Infrastructure;
using MyPurse.Repository.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPurse.Repository
{
    public class TransactionRepository : BaseRepository<transaction>
    {
        public TransactionRepository(IUnitOfWork unitOfWork) : base(unitOfWork) { }
    }
}
