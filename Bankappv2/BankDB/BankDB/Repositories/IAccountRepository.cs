using System;
using System.Collections.Generic;
using System.Text;
using BankDB.Models;

namespace BankDB.Repositories
{
    interface IAccountRepository
    {
        List<Account> Read();
        Account GetAccountById(string iban);
        void CreateAccount(Account account);
        void DeleteAccount(string iban);
        void CreateTransaction(Transaction transaction);
    }
}