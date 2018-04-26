using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BankDB.Models;
using Microsoft.EntityFrameworkCore;

namespace BankDB.Repositories
{
    class AccountRepository : IAccountRepository
    {
        private readonly BankdbContext _context = new BankdbContext();

        //Print Accounts
        public List<Account> Read()
        {
            List<Account> accounts = _context.Account.ToListAsync().Result;
            return accounts;
        }

        //Find account by id
        public Account GetAccountById(string iban)
        {
            var account = _context.Account.FirstOrDefault(a => a.Iban == iban);
            return account;
        }

        //Create new Account
        public void CreateAccount(Account account)
        {
            _context.Account.Add(account);
            _context.SaveChanges();
        }

        //Delete an account
        public void DeleteAccount(string iban)
        {
            var delAccount = _context.Account.FirstOrDefault(a => a.Iban == iban);
            if (delAccount != null)
                _context.Account.Remove(delAccount);
            _context.SaveChanges();
        }

        //Creating transactions
        public void CreateTransaction(Transaction transaction)
        {
            try
            {
                //Lisätään tapahtumiin rivi
                _context.Transaction.Add(transaction);
                //Etsitään oikea tili jota päivitetään
                var account = GetAccountById(transaction.Iban);
                //Lasketaan uusi saldo
                account.Balance += transaction.Amount;

                //update Account table
                _context.Account.Update(account);
                //tallennettaan muutokset tietokantaan
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}