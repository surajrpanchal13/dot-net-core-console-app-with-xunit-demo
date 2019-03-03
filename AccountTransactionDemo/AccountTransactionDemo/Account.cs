using System.Collections.Generic;
using System.Linq;

namespace AccountTransactionDemo
{
    public class Account
    {
        public string AccountNo { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName => FirstName + " " + LastName;

        public double Balance => AccountTransactions != null ? AccountTransactions.Sum(x => x.TransactionAmount) : 0;

        public List<AccountTransaction> AccountTransactions { get; set; }
    }
}
