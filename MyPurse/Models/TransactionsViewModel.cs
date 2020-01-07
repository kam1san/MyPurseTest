using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyPurse.Models
{
    public class TransactionsViewModel
    {
        public int ID { get; set; }
        
        public int AccountID { get; set; }

        public double Amount { get; set; }

        public string TransactionType { get; set; }

        public int? AccountTransferTo { get; set; }
        
        public DateTime Date { get; set; }
    }
}