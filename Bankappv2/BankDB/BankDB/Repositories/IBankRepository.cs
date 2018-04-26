using System;
using System.Collections.Generic;
using System.Text;
using BankDB.Models;

namespace BankDB.Repositories
{
    interface IBankRepository
    {
        List<Bank> GetTransactionsFromBankCustomersAccounts();
        Bank GetBankById(long id);
        void Create(Bank bank);
        void Update(Bank bank);
        void Delete(int id);
    }
}
