using System;
using BankDB.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using BankDB.Repositories;
using System.Collections.Generic;

namespace BankDB
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Print();

            Console.WriteLine("\nPress any key to quit");
            Console.ReadLine();
        }
        static void CreateCustomer()
        {
            CustomerRepository customerRepository = new CustomerRepository();
            Customer c1 = new Customer("Musta", "Otso");
            Customer c2 = new Customer("Antti", "Karjalainen");
            customerRepository.CreateCustomer(c1);
            customerRepository.CreateCustomer(c2);
        }
        static void UpdateCustomer()
        {
            CustomerRepository customerRepository = new CustomerRepository();
            Customer updateCustomer = customerRepository.GetCustomerById(3);
            updateCustomer.Firstname = "George";
            updateCustomer.Lastname = "Flintstone";
            customerRepository.UpdateCustomer(updateCustomer, 3);
        }
        static void DeleteCustomer()
        {
            CustomerRepository customerRepository = new CustomerRepository();
            customerRepository.DeleteCustomer(5);
        }
        static void CreateBank()
        {
            BankRepository bankRepository = new BankRepository();
            Bank b = new Bank("Saastopankki", "KDAFIHH");
            Bank b2 = new Bank("Sammonlahden pankki", "SDAFIHH");
            Bank b3 = new Bank("Danske Bank", "DANSKFI");
            bankRepository.Create(b2);
            bankRepository.Create(b);
            bankRepository.Create(b3);
        }
        static void UpdateBank()
        {
            BankRepository bankRepository = new BankRepository();
            Bank updateBank = bankRepository.GetBankById(2);
            updateBank.Name = "Roope Ankan Pankki";
            updateBank.Bic = "RAPFI";
            bankRepository.Update(updateBank);
        }
        static void DeleteBank()
        {
            BankRepository bankRepository = new BankRepository();
            bankRepository.Delete(4);
        }
        static void CreateTransaction()
        {
            AccountRepository accountRepository = new AccountRepository();

            TransactionRepository transactionRepository = new TransactionRepository();
            Transaction transaction = new Transaction
            {
                Iban = "FI49123456789",
                Amount = -3000,
                TimeStamp = DateTime.Today
            };
            accountRepository.CreateTransaction(transaction);
        }
        static void Print()
        {
            BankRepository bankRepository = new BankRepository();

            var bankCustomers = bankRepository.GetTransactionsFromBankCustomersAccounts();

            foreach (var bC in bankCustomers)
            {
                Console.WriteLine(bC.ToString());
                foreach (var c in bC.Customer)
                {
                    Console.WriteLine(c.ToString());
                    foreach (var cAccount in c.Account)
                    {
                        Console.WriteLine($"\t{cAccount.ToString()}");
                        foreach (var trn in cAccount.Transaction)
                        {
                            Console.WriteLine($"\t{trn.ToString()}");
                        }
                    }
                }
            }
        }
    }
}