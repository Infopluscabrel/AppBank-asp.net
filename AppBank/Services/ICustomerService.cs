using AppBank.Models;
using AppBank.ViewModels.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppBank.Services
{
    public interface ICustomerService
    {
        public List<Customer> CustomersList();

        public List<Customer> CustomersList(bool state);
        public Customer CustomerCreate(Customer customer);
        public void CustomerDelete(int id);
        public Customer CustomerDetail(int id);
        public Customer CustomerEdit(int id, CustomerEditVM customerEditVM);
    }
}
