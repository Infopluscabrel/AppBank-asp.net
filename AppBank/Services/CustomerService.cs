using AppBank.Models;
using AppBank.Models.Bank;
using AppBank.ViewModels.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppBank.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly DataContext _context;
        public CustomerService(DataContext context)
        {
            _context = context;
        }
        public Customer CustomerCreate(Customer customer)
        {
            customer.CustomerCreationDate = DateTime.Now;
            customer.CustomerUpdatedDate = customer.CustomerCreationDate;
            _context.Customers.Add(customer);
            customer.CustomerState = true;
            _context.SaveChanges();
            return customer;
        }

        public void CustomerDelete(int id)
        {
            var customer = CustomerDetail(id);
            customer.CustomerDeletedDate = DateTime.Now;
            _context.Customers.Update(customer);
            customer.CustomerState = false;
            _context.SaveChanges();
        }

        public Customer CustomerDetail(int id)
        {
            return _context.Customers.Single(c => c.CustomerID == id);
        }

        public Customer CustomerEdit(int id, CustomerEditVM customerEditVM)
        {
            var customer = CustomerDetail(id);
            customer.CustomerFirstName = customerEditVM.CustomerFirstName;
            customer.CustomerLastName = customerEditVM.CustomerLastName;
            customer.CustomerPhoneNumber = customerEditVM.CustomerPhoneNumber;
            customer.CustomerEmail = customerEditVM.CustomerEmail;
            customer.CustomerUpdatedDate = DateTime.Now;
            _context.Customers.Update(customer);
           
            _context.SaveChanges();
            return customer;
        }

        public List<Customer> CustomersList()
        {
            return _context.Customers.ToList();
        }

        public List<Customer> CustomersList(bool state)
        {
            List <Customer> list= _context.Customers.Where(c => c.CustomerState == state).ToList();
            return list;
        }
    }
}
