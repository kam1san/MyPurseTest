using MyPurse.BLL.Interfaces;
using MyPurse.Domain;
using MyPurse.Repository;
using MyPurse.Repository.Infrastructure;
using MyPurse.Repository.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPurse.BLL.Business
{
    public class TypeBusiness : ITypeBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly TypeRepository tRep;

        public TypeBusiness(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            tRep = new TypeRepository(unitOfWork);
        }

        public List<TypeDomainModel> GetTypes()
        {
            List<TypeDomainModel> list = tRep.GetAll().Select(m => new TypeDomainModel { ID = m.ID, Description=m.Description, Type=m.Type }).ToList();
            return list;
        }

        public void Delete(int ID)
        {
            tRep.Delete(x => x.ID == ID);
        }

        public List<TypeDomainModel> GetTypesBy(string operation)
        {
            List<TypeDomainModel> list = tRep.GetAll(x=>x.Type==operation).Select(m => new TypeDomainModel { ID = m.ID, Description = m.Description, Type = m.Type }).ToList();
            return list;
        }

        public string AddType(TypeDomainModel DM)
        {
            if ((DM.Description == null) || (DM.Type==null))
            {
                return "One or more fields are empty";
            }
            else
            {
                trans_type t = new trans_type();
                t.Description = DM.Description;
                t.Type = DM.Type;
                tRep.Insert(t);
                return "";
            }
        }

        public string EditType(TypeDomainModel DM)
        {
            if ((DM.Description == null) || (DM.Type == null))
            {
                return "One or more fields are empty";
            }
            else
            {
                trans_type t = tRep.SingleOrDefault(x => x.ID == DM.ID);
                t.Description = DM.Description;
                t.Type = DM.Type;
                tRep.Update(t);
                return "";
            }
        }

        public trans_type GetType(int ID)
        {
            trans_type trans = tRep.SingleOrDefault(x => x.ID == ID);
            return trans;
        }
    }
}
