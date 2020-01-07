using MyPurse.Repository.Infrastructure;
using MyPurse.Repository.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPurse.Repository
{
    public class AccountRepository:BaseRepository<account>
    {
        public AccountRepository(IUnitOfWork unitOfWork) : base(unitOfWork) { }
    }
}
