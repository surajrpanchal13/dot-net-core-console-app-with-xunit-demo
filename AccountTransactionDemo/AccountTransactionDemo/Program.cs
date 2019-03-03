using DataGenerator;
using DataGenerator.Sources;
using System;
using System.Diagnostics;

namespace AccountTransactionDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            ConfigureClassToGenerateRandomData();

            var user1 = Generator.Default.Single<Account>();
            var user2 = Generator.Default.Single<Account>();

            AccountService accountService = new AccountService();
            accountService.AddBalance(user1, Generator.Default.Single<AccountTransaction>());
            accountService.AddBalance(user2, Generator.Default.Single<AccountTransaction>());

            accountService.DeductBalance(user1, Generator.Default.Single<AccountTransaction>());

            accountService.TransferBalance(user2, user1, Generator.Default.Single<AccountTransaction>());

            Console.ReadKey();
        }

        static void ConfigureClassToGenerateRandomData()
        {
            Generator.Default.Configure(c => c.Entity<Account>(acc =>
            {
                acc.Property(p => p.AccountNo).DataSource<IdentifierSource>();
                acc.Property(p => p.FirstName).DataSource<FirstNameSource>();
                acc.Property(p => p.LastName).DataSource<LastNameSource>();
                acc.Property(p => p.AccountTransactions).List<AccountTransaction>(2);
            }).Entity<AccountTransaction>(at =>
            {
                at.Property(p => p.Subject).DataSource<LoremIpsumSource>();
                at.Property(p => p.TransactionDateTime).DataSource<DateTimeSource>();
                at.Property(p => p.TransactionAmount).DataSource<MoneySource>();
            }));
        }
    }
}
