using System;
using System.Diagnostics;
using System.Collections.Generic;

namespace AccountTransactionDemo
{
    public class AccountService
    {
        public void AddBalance(Account account,AccountTransaction accountTransaction)
        {
            if(account.AccountTransactions == null)
            {
                account.AccountTransactions = new List<AccountTransaction>();
            }
            account.AccountTransactions.Add(accountTransaction);
            Console.WriteLine("Account tranasction has created");
        }

        public void DeductBalance(Account account, AccountTransaction accountTransaction)
        {
            if (account.AccountTransactions == null)
            {
                account.AccountTransactions = new List<AccountTransaction>();
            }
            account.AccountTransactions.Add(accountTransaction);
            Console.WriteLine("Account tranasction has created");
        }

        public void TransferBalance(Account sourceAccount, Account destinationAccount, AccountTransaction accountTransaction)
        {
            DeductBalance(sourceAccount, accountTransaction);
            AddBalance(destinationAccount, accountTransaction);
        }
    }
}
