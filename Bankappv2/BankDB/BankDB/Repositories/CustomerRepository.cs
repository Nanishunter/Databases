using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using BankDB.Models;
using System.Linq;

namespace BankDB.Repositories
{
    class CustomerRepository : ICustomerRepository
    {
        private readonly BankdbContext _context = new BankdbContext();

        //Print Customers
        public List<Customer> Read()
        {
            List<Customer> customers = _context.Customer.ToListAsync().Result;
            return customers;
        }

        //Etsi tietty asiakas
        public Customer GetCustomerById(int id)
        {
            var customer = _context.Customer.FirstOrDefault(c => c.Id == id);
            return customer;
        }

        //Create a new customer
        public void CreateCustomer(Customer customer)
        {
            _context.Customer.Add(customer);
            _context.SaveChanges();
        }

        //Update customer info
        public void UpdateCustomer(Customer customer, int id)
        {
            var updateCustomer = GetCustomerById(id);
            if (updateCustomer != null)
            {
                updateCustomer.Lastname = customer.Firstname;
                updateCustomer.Lastname = customer.Lastname;
                _context.Customer.Update(customer);
            }
            _context.SaveChanges();
        }

        //Delete customer
        public void DeleteCustomer(int id)
        {
            var delCustomer = _context.Customer.FirstOrDefault(c => c.Id == id);
            if (delCustomer != null)
                _context.Customer.Remove(delCustomer);
            _context.SaveChanges();
        }
    }
}