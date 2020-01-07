using MyPurse.BLL.Business;
using MyPurse.BLL.Interfaces;
using MyPurse.Repository.Infrastructure;
using MyPurse.Repository.Infrastructure.Interfaces;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace MyPurse
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IAccountBusiness, AccountBusiness>();
            container.RegisterType<ITransactionBusiness, TransactionBusiness>();
            container.RegisterType<ITypeBusiness, TypeBusiness>();
            container.RegisterType<IUnitOfWork, UnitOfWork>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}