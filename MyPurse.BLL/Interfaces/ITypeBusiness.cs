using MyPurse.Domain;
using MyPurse.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPurse.BLL.Interfaces
{
    public interface ITypeBusiness
    {
        List<TypeDomainModel> GetTypes();
        List<TypeDomainModel> GetTypesBy(string operation);
        trans_type GetType(int ID);
        string EditType(TypeDomainModel DM);
        string AddType(TypeDomainModel DM);
        void Delete(int ID);
    }
}
