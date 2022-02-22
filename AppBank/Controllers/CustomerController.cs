using AppBank.Models;
using AppBank.Models.Bank;
using AppBank.Services;
using AppBank.ViewModels.Customer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppBank.Controllers
{
    public class CustomerController : Controller
    {
        private readonly DataContext _context;
        private readonly ICustomerService _customerService;

        public CustomerController(DataContext context, ICustomerService customerService)
        {
            _context = context;
            _customerService = customerService;
        }
        // GET: CustomerController
        public ActionResult Index()
        {
            var customer = _customerService.CustomersList(true);
            return View(customer);
        }

        // GET: CustomerController/Details/5
        public ActionResult Details(int id)
        {
            var customer = _customerService.CustomerDetail(id);
            return View(customer);
        }

        // GET: CustomerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer customer)
        {
            try
            {
                _customerService.CustomerCreate(customer);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerController/Edit/5
        public ActionResult Edit(int id)
        {
            var customer = _customerService.CustomerDetail(id);
            return View(customer);
        }

        // POST: CustomerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CustomerEditVM customer)
        {
            try
            {
                _customerService.CustomerEdit(id, customer);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerController/Delete/5
        public ActionResult Delete(int id)
        {
           var customer = _customerService.CustomerDetail(id);
            return View(customer);
        }

        // POST: CustomerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                _customerService.CustomerDelete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
