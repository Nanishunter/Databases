using System;
using System.Collections.Generic;
using System.Text;
using BankDB.Models;

namespace BankDB.Repositories
{
    interface ITransactionRepository
    {
        List<Transaction> Read();
        //Transaction GetTransactionById(string iban);

    }
}