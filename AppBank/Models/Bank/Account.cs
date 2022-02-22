using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppBank.Models
{
    public class Account
    {
        public int AccountID { get; set; }
        public string AccountNumber { get; set; }
        public double AccountBalance { get; set; }
        public DateTime AccountCreationDate { get; set; }
        public DateTime AccountUpdatedDate { get; set; }
        public DateTime AccountDeletedDate { get; set; }
        public bool AccountState { get; set; }
        public int CustomerID { get; set; }

        //Permet au framework de faire la relation
        public Customer CustomerAccount { get; set; }
    }
}
