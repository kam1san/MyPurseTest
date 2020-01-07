using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPurse.DAL.Entities
{
    public class Account
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public double? Amount { get; set; }
    }
}
