using MyPurse.Repository.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPurse.Repository.Infrastructure
{
    public class TypeRepository:BaseRepository<trans_type>
    {
        public TypeRepository(IUnitOfWork unitOfWork) : base(unitOfWork) { }
    }
}
