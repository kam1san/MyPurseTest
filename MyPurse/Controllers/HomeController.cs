using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyPurse.BLL.Interfaces;
using MyPurse.BLL.Business;
using AutoMapper;
using MyPurse.Models;
using MyPurse.Domain;
using MyPurse.Repository;
using System.Dynamic;

namespace MyPurse.Controllers
{
    public class HomeController : Controller
    {
        IAccountBusiness accs;
        ITransactionBusiness ts;
        ITypeBusiness t;
        public HomeController(IAccountBusiness b_acc, ITransactionBusiness b_ts, ITypeBusiness b_t)
        {
            accs = b_acc; ts = b_ts; t = b_t;
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Accounts()
        {
            List<AccountDomainModel> accs_listDomain = accs.GetAccounts();
            List<AccountViewModel> VM_accs_list = new List<AccountViewModel>();
            var mapper_accs = new MapperConfiguration(cfg => cfg.CreateMap<AccountDomainModel, AccountViewModel>()).CreateMapper();
            var accounts = mapper_accs.Map<IEnumerable<AccountDomainModel>, List<AccountViewModel>>(accs_listDomain);
            return View(accounts);
        }
        public ActionResult Transactions()
        {
            List<TransactionDomainModel> ts_listDomain = ts.GetTransactions();
            List<TransactionsViewModel> VM_ts_list = new List<TransactionsViewModel>();
            var mapper_ts = new MapperConfiguration(cfg => cfg.CreateMap<TransactionDomainModel, TransactionsViewModel>()).CreateMapper();
            var transactions = mapper_ts.Map<IEnumerable<TransactionDomainModel>, List<TransactionsViewModel>>(ts_listDomain);
            return View(transactions);
        }
        public ActionResult TS_types()
        {
            List<TypeDomainModel> t_listDomain = t.GetTypes();
            List<TypeViewModel> VM_t_list = new List<TypeViewModel>();
            var mapper_t = new MapperConfiguration(cfg => cfg.CreateMap<TypeDomainModel, TypeViewModel>()).CreateMapper();
            var types = mapper_t.Map<IEnumerable<TypeDomainModel>, List<TypeViewModel>>(t_listDomain);
            return View(types);
        }

        public void DeleteType(int ID)
        {
            t.Delete(ID);
        }

        public void DeleteAccount(int ID)
        {
            accs.Delete(ID);
        }

        public void DeleteTransaction(int ID)
        {
            ts.Delete(ID);
        }
        
        public ActionResult EditAccount(int ID)
        {
            account acc = accs.GetAccount(ID);
            AccountViewModel acc_vm = new AccountViewModel();
            var mapper_accs = new MapperConfiguration(cfg => cfg.CreateMap<account, AccountViewModel>()).CreateMapper();
            var account = mapper_accs.Map<account, AccountViewModel>(acc);
            
            return View(account);
        }

        public ActionResult AddAccount()
        {
            return View();
        }

        public ActionResult AddIncome()
        {
            List<AccountDomainModel> accs_listDomain = accs.GetAccounts();
            List<AccountViewModel> VM_accs_list = new List<AccountViewModel>();
            var mapper_accs = new MapperConfiguration(cfg => cfg.CreateMap<AccountDomainModel, AccountViewModel>()).CreateMapper();
            var accounts = mapper_accs.Map<IEnumerable<AccountDomainModel>, List<AccountViewModel>>(accs_listDomain);

            List<TypeDomainModel> t_listDomain = t.GetTypesBy("in");
            List<TypeViewModel> VM_t_list = new List<TypeViewModel>();
            var mapper_t = new MapperConfiguration(cfg => cfg.CreateMap<TypeDomainModel, TypeViewModel>()).CreateMapper();
            var types = mapper_t.Map<IEnumerable<TypeDomainModel>, List<TypeViewModel>>(t_listDomain);
            List<TransactionDomainModel> ts_listDomain = ts.GetTransactions();

            ViewBag.Accounts = new SelectList(accounts, "ID","Name");
            ViewBag.Types = new SelectList(types, "ID","Description");
            return View();
        }

        public ActionResult AddOutcome()
        {
            List<AccountDomainModel> accs_listDomain = accs.GetAccounts();
            List<AccountViewModel> VM_accs_list = new List<AccountViewModel>();
            var mapper_accs = new MapperConfiguration(cfg => cfg.CreateMap<AccountDomainModel, AccountViewModel>()).CreateMapper();
            var accounts = mapper_accs.Map<IEnumerable<AccountDomainModel>, List<AccountViewModel>>(accs_listDomain);

            List<TypeDomainModel> t_listDomain = t.GetTypesBy("out");
            List<TypeViewModel> VM_t_list = new List<TypeViewModel>();
            var mapper_t = new MapperConfiguration(cfg => cfg.CreateMap<TypeDomainModel, TypeViewModel>()).CreateMapper();
            var types = mapper_t.Map<IEnumerable<TypeDomainModel>, List<TypeViewModel>>(t_listDomain);
            List<TransactionDomainModel> ts_listDomain = ts.GetTransactions();

            ViewBag.Accounts = new SelectList(accounts, "ID", "Name");
            ViewBag.Types = new SelectList(types, "ID", "Description");
            return View();
        }

        public ActionResult AddTransfer()
        {
            List<AccountDomainModel> accs_listDomain = accs.GetAccounts();
            List<AccountViewModel> VM_accs_list = new List<AccountViewModel>();
            var mapper_accs = new MapperConfiguration(cfg => cfg.CreateMap<AccountDomainModel, AccountViewModel>()).CreateMapper();
            var accounts = mapper_accs.Map<IEnumerable<AccountDomainModel>, List<AccountViewModel>>(accs_listDomain);

            List<TypeDomainModel> t_listDomain = t.GetTypesBy("transfer");
            List<TypeViewModel> VM_t_list = new List<TypeViewModel>();
            var mapper_t = new MapperConfiguration(cfg => cfg.CreateMap<TypeDomainModel, TypeViewModel>()).CreateMapper();
            var types = mapper_t.Map<IEnumerable<TypeDomainModel>, List<TypeViewModel>>(t_listDomain);
            List<TransactionDomainModel> ts_listDomain = ts.GetTransactions();

            ViewBag.Accounts = new SelectList(accounts, "ID", "Name");
            ViewBag.Types = new SelectList(types, "ID", "Description");
            return View();
        }

        public ActionResult AddType()
        {
            List<string> list = new List<string>();
            list.Add("transfer");
            list.Add("outcome");
            list.Add("income");
            ViewBag.Types = new SelectList(list);
            return View();
        }

        public ActionResult EditTransaction(int ID)
        {
            transaction trans = ts.GetTransaction(ID);
            TransactionsViewModel acc_vm = new TransactionsViewModel();
            var mapper_trans = new MapperConfiguration(cfg => cfg.CreateMap<transaction, TransactionsViewModel>()).CreateMapper();
            var trs = mapper_trans.Map<transaction, TransactionsViewModel>(trans);

            List<AccountDomainModel> accs_listDomain = accs.GetAccounts();
            List<AccountViewModel> VM_accs_list = new List<AccountViewModel>();
            var mapper_accs = new MapperConfiguration(cfg => cfg.CreateMap<AccountDomainModel, AccountViewModel>()).CreateMapper();
            var accounts = mapper_accs.Map<IEnumerable<AccountDomainModel>, List<AccountViewModel>>(accs_listDomain);

            List<TypeDomainModel> t_listDomain = t.GetTypes();
            List<TypeViewModel> VM_t_list = new List<TypeViewModel>();
            var mapper_t = new MapperConfiguration(cfg => cfg.CreateMap<TypeDomainModel, TypeViewModel>()).CreateMapper();
            var types = mapper_t.Map<IEnumerable<TypeDomainModel>, List<TypeViewModel>>(t_listDomain);
            List<TransactionDomainModel> ts_listDomain = ts.GetTransactions();

            ViewBag.Accounts = new SelectList(accounts, "ID", "Name");
            ViewBag.Types = new SelectList(types, "ID", "Description");

            return View(trs);
        }

        public ActionResult EditType(int ID)
        {
            trans_type trans = t.GetType(ID);
            TypeViewModel trans_vm = new TypeViewModel();
            var mapper_trans = new MapperConfiguration(cfg => cfg.CreateMap<trans_type, TypeViewModel>()).CreateMapper();
            var type = mapper_trans.Map<trans_type, TypeViewModel>(trans);
            List<string> list = new List<string>();
            list.Add("transfer");
            list.Add("outcome");
            list.Add("income");
            ViewBag.Types = new SelectList(list);
            return View(type);
        }

        public ActionResult CategorySort()
        {
            List<TypeDomainModel> t_listDomain = t.GetTypes();
            List<TypeViewModel> VM_t_list = new List<TypeViewModel>();
            var mapper_t = new MapperConfiguration(cfg => cfg.CreateMap<TypeDomainModel, TypeViewModel>()).CreateMapper();
            var types = mapper_t.Map<IEnumerable<TypeDomainModel>, List<TypeViewModel>>(t_listDomain);
            ViewBag.Types = new SelectList(types, "ID", "Description");
            return View();
        }

        [HttpPost]
        public ActionResult ConfirmCategorySort(TransactionsViewModel vm)
        {
            TransactionDomainModel ts_dm = new TransactionDomainModel();
            var mapper_accs = new MapperConfiguration(cfg => cfg.CreateMap<TransactionsViewModel, TransactionDomainModel>()).CreateMapper();
            var trans = mapper_accs.Map<TransactionsViewModel, TransactionDomainModel>(vm);
            List<TransactionDomainModel> ts_listDomain = ts.CategorySort(trans);
            List<TransactionsViewModel> VM_ts_list = new List<TransactionsViewModel>();
            var mapper_ts = new MapperConfiguration(cfg => cfg.CreateMap<TransactionDomainModel, TransactionsViewModel>()).CreateMapper();
            var transactions = mapper_ts.Map<IEnumerable<TransactionDomainModel>, List<TransactionsViewModel>>(ts_listDomain);
            return View(transactions);
        }

        [HttpPost]
        public string ConfirmEditAccount(AccountViewModel vm)
        {
            AccountDomainModel acc_dm = new AccountDomainModel();
            var mapper_accs = new MapperConfiguration(cfg => cfg.CreateMap<AccountViewModel, AccountDomainModel>()).CreateMapper();
            var account = mapper_accs.Map<AccountViewModel, AccountDomainModel>(vm);
            string response = accs.Edit(account);
            return response;
        }

        [HttpPost]
        public string ConfirmEditTransaction(TransactionsViewModel vm)
        {
            TransactionDomainModel acc_dm = new TransactionDomainModel();
            var mapper_accs = new MapperConfiguration(cfg => cfg.CreateMap<TransactionsViewModel, TransactionDomainModel>()).CreateMapper();
            var transaction = mapper_accs.Map<TransactionsViewModel, TransactionDomainModel>(vm);
            string response=ts.Edit(transaction);
            return response;
        }

        [HttpPost]
        public string ConfirmAddAccount(AccountViewModel vm)
        {
            AccountDomainModel acc_dm = new AccountDomainModel();
            var mapper_accs = new MapperConfiguration(cfg => cfg.CreateMap<AccountViewModel, AccountDomainModel>()).CreateMapper();
            var account = mapper_accs.Map<AccountViewModel, AccountDomainModel>(vm);
            string response = accs.Add(account);
            return response;
        }

        [HttpPost]
        public string ConfirmAddInTransaction(TransactionsViewModel vm)
        {
            TransactionDomainModel ts_dm = new TransactionDomainModel();
            var mapper_accs = new MapperConfiguration(cfg => cfg.CreateMap<TransactionsViewModel, TransactionDomainModel>()).CreateMapper();
            var trans = mapper_accs.Map<TransactionsViewModel, TransactionDomainModel>(vm);
            string response=ts.AddIn(trans);
            return response;
        }

        [HttpPost]
        public string ConfirmAddOutTransaction(TransactionsViewModel vm)
        {
            TransactionDomainModel ts_dm = new TransactionDomainModel();
            var mapper_accs = new MapperConfiguration(cfg => cfg.CreateMap<TransactionsViewModel, TransactionDomainModel>()).CreateMapper();
            var trans = mapper_accs.Map<TransactionsViewModel, TransactionDomainModel>(vm);
            string response = ts.AddOut(trans);
            return response;
        }

        [HttpPost]
        public string ConfirmAddTransferTransaction(TransactionsViewModel vm)
        {
            TransactionDomainModel ts_dm = new TransactionDomainModel();
            var mapper_accs = new MapperConfiguration(cfg => cfg.CreateMap<TransactionsViewModel, TransactionDomainModel>()).CreateMapper();
            var trans = mapper_accs.Map<TransactionsViewModel, TransactionDomainModel>(vm);
            string response = ts.AddTransfer(trans);
            return response;
        }

        [HttpPost]
        public string ConfirmAddType(TypeViewModel vm)
        {
            TypeDomainModel t_dm = new TypeDomainModel();
            var mapper_accs = new MapperConfiguration(cfg => cfg.CreateMap<TypeViewModel, TypeDomainModel>()).CreateMapper();
            var trans = mapper_accs.Map<TypeViewModel, TypeDomainModel>(vm);
            string response = t.AddType(trans);
            return response;
        }

        [HttpPost]
        public string ConfirmEditType(TypeViewModel vm)
        {
            TypeDomainModel t_dm = new TypeDomainModel();
            var mapper_accs = new MapperConfiguration(cfg => cfg.CreateMap<TypeViewModel, TypeDomainModel>()).CreateMapper();
            var trans = mapper_accs.Map<TypeViewModel, TypeDomainModel>(vm);
            string response = t.EditType(trans);
            return response;
        }

    }
}