using AppBank.Models;
using AppBank.Models.Bank;
using AppBank.Services;
using AppBank.ViewModels.Account;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppBank.Controllers
{
    public class AccountController : Controller
    {
        private readonly DataContext _context;
        private readonly IAccountService _accountService;
        public AccountController(DataContext context, IAccountService accountService)
        {
            _context = context;
            _accountService = accountService;
        }
        // GET: AccountController
        public ActionResult Index()
        {
            var account = _accountService.accountsList(true);
            return View(account);
        }

        // GET: AccountController/Details/5
        public ActionResult Details(int id)
        {
            var account = _accountService.DetailAccount(id);
            return View(account);
        }

        // GET: AccountController/Create
        public ActionResult Create()
        {
            IEnumerable<SelectListItem> items = _context.Customers.Select(c => new SelectListItem
            {
                Value = c.CustomerID.ToString(),
                Text=c.CustomerFirstName + " " + c.CustomerLastName
            }) ;
            ViewBag.CustomerName = items;
            return View();
        }

        // POST: AccountController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Account account)
        {
            try
            {
                _accountService.CreateAccount(account);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AccountController/Edit/5
        public ActionResult Edit(int id)
        {
            var account = _accountService.DetailAccount(id);
            return View(account);
        }

        // POST: AccountController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, AccountEditVM account)
        {
            try
            {
                _accountService.EditAccount(id, account);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AccountController/Delete/5
        public ActionResult Delete(int id)
        {
            var account = _accountService.DetailAccount(id);
            return View(account);
        }

        // POST: AccountController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                _accountService.DeleteAccount(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
