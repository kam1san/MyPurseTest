using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPurse.Domain
{
    public class TransactionDomainModel
    {
        public int ID { get; set; }

        public int AccountID { get; set; }

        public double Amount { get; set; }

        public int TransactionType { get; set; }

        public int? AccountTransferTo { get; set; }

        public DateTime? Date { get; set; }
    }
}
