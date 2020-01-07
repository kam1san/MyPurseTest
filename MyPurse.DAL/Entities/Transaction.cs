using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPurse.DAL.Entities
{
    public class Transaction
    {
        public int ID { get; set; }

        public int AccountID { get; set; }

        public double Amount { get; set; }

        public string TransactionType { get; set; }

        public int? AccountTransferTo { get; set; }

        public string Description { get; set; }

        public DateTime Date { get; set; }
    }
}
