using AppBank.Models;
using AppBank.Models.Bank;
using AppBank.ViewModels.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppBank.Services
{
    public class AccountService : IAccountService
    {
        private readonly DataContext _context;
        public AccountService(DataContext context)
        {
            _context = context;
        }
        public List<Account> accountsList()
        {
            return _context.Accounts.ToList();
        }

        public List<Account> accountsList(bool state)
        {
            return _context.Accounts.Where(c => c.AccountState == state).ToList();
        }

        public Account CreateAccount(Account account)
        {
            account.AccountCreationDate = DateTime.Now;
            account.AccountUpdatedDate = account.AccountCreationDate;
            _context.Accounts.Add(account);
            account.AccountState = true;
            _context.SaveChanges();
            return account;
        }

        public void DeleteAccount(int id)
        {
            var account = DetailAccount(id);
            account.AccountDeletedDate = DateTime.Now;
            account.AccountUpdatedDate = account.AccountDeletedDate;
            _context.Accounts.Update(account);
            _context.SaveChanges();
            
        }

        public Account DetailAccount(int id)
        {
            return _context.Accounts.Single(c => c.AccountID == id);
        }

        public Account EditAccount(int id, AccountEditVM accountEditVM)
        {
            var account = DetailAccount(id);
            account.AccountNumber = accountEditVM.AccountNumber;
            account.AccountBalance = accountEditVM.AccountBalance;
            account.AccountUpdatedDate = DateTime.Now;
            _context.Accounts.Update(account);
            _context.SaveChanges();
            return account;
        }
    }
}
