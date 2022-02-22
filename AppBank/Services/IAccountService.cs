using AppBank.Models;
using AppBank.ViewModels.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppBank.Services
{
    public interface IAccountService
    {
        public List<Account> accountsList();
        public List<Account> accountsList(bool state);
        public Account CreateAccount(Account account);
        public void DeleteAccount(int id);
        public Account DetailAccount(int id);
        public Account EditAccount(int id, AccountEditVM accountEditVM);
    }

}
