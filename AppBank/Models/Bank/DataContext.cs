using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppBank.Models.Bank
{
    public class DataContext : DbContext
    {
        public readonly IConfiguration _configuration;
        //permet d'acceder au fichier json de configuration

        public DataContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder option)
        {
            option.UseMySql(_configuration.GetConnectionString("dataAccess"));
        }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
    }
}
