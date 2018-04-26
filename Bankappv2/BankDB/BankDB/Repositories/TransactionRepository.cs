using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using BankDB.Models;
using BankDB.Repositories;

namespace BankDB.Repositories
{
    class TransactionRepository : ITransactionRepository
    {
        private readonly BankdbContext _context = new BankdbContext();

        //Print Transactions
        public List<Transaction> Read()
        {
            List<Transaction> transactions = _context.Transaction.ToListAsync().Result;
            return transactions;
        }


        ////Find specific transaction
        public Transaction GetTransactionById(int id)
        {
            var transaction = _context.Transaction.FirstOrDefault(t => t.Id == id);
            return transaction;
        }
    }
}