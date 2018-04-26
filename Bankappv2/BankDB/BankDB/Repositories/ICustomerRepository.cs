using System;
using System.Collections.Generic;
using System.Text;
using BankDB.Models;

namespace BankDB.Repositories
{
    interface ICustomerRepository
    {
        List<Customer> Read();
        Customer GetCustomerById(int id);
        void CreateCustomer(Customer customer);
        void UpdateCustomer(Customer customer, int id);
        void DeleteCustomer(int id);

    }
}