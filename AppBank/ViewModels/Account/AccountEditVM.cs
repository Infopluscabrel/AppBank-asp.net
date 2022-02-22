using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppBank.ViewModels.Account
{
    public class AccountEditVM
    {
        public int AccountID { get; set; }
        public string AccountNumber { get; set; }
        public double AccountBalance { get; set; }
    }
}
