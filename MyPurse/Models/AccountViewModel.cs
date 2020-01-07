using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyPurse.Models
{
    public class AccountViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public double? Amount { get; set; }
    }
}