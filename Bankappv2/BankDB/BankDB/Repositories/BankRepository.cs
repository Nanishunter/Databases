using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using BankDB.Models;
using System.Linq;

namespace BankDB.Repositories
{
    class BankRepository : IBankRepository
    {
        private readonly BankdbContext _context = new BankdbContext();

        //Tulosta Pankit
        public List<Bank> GetTransactionsFromBankCustomersAccounts()
        {
            List<Bank> banks = _context.Bank
                .Include(b => b.Customer)
                .Include(b => b.Account)
                .Include(b => b.Account).ThenInclude(a => a.Transaction)
                .ToListAsync().Result;
            return banks;
        }

        //Etsi tietty pankki
        public Bank GetBankById(long id)
        {
            var bank = _context.Bank.FirstOrDefault(b => b.Id == id);
            return bank;
        }

        //Add Bank
        public void Create(Bank bank)
        {
            _context.Bank.Add(bank);
            _context.SaveChanges();
        }

        //Update Bank
        public void Update(Bank bank)
        {
            var updateBank = GetBankById(bank.Id);
            if (updateBank != null)
            {
                updateBank.Name = bank.Name;
                updateBank.Bic = bank.Bic;
                _context.Bank.Update(bank);
            }
            _context.SaveChanges();
        }

        //Delete Bank
        public void Delete(int id)
        {
            var delBank = _context.Bank.FirstOrDefault(b => b.Id == id);
            if (delBank != null)
                _context.Bank.Remove(delBank);
            _context.SaveChanges();
        }
    }
}