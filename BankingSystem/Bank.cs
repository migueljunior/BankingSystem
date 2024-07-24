namespace BankingSystem
{
    // Bank class
    public class Bank
    {
        public List<Customer> Customers { get; private set; }
        public List<Account> Accounts { get; private set; }
        public List<Transaction> Transactions { get; private set; }

        public Bank()
        {
            Customers = new List<Customer>();
            Accounts = new List<Account>();
            Transactions = new List<Transaction>();
        }

        public void AddCustomer(Customer customer)
        {
            Customers.Add(customer);
        }

        public void RemoveCustomer(int customerId)
        {
            Customer customer = Customers.Find(c => c.CustomerId == customerId);
            if (customer != null)
            {
                // Remove all accounts associated with this customer
                Accounts.RemoveAll(a => a.AccountHolder.CustomerId == customerId);
                Customers.Remove(customer);
            }
        }

        public void ListCustomers()
        {
            foreach (var customer in Customers)
            {
                Console.WriteLine($"ID: {customer.CustomerId}, Name: {customer.Name}, Email: {customer.Email}, Phone: {customer.PhoneNumber}");
            }
        }

        public void CreateAccount(Account account)
        {
            Accounts.Add(account);
        }

        public Account GetAccount(int accountNumber)
        {
            return Accounts.Find(a => a.AccountNumber == accountNumber);
        }

        public void ListTransactions(int accountNumber)
        {
            foreach (var transaction in Transactions.FindAll(t => t.Account.AccountNumber == accountNumber))
            {
                Console.WriteLine($"Transaction ID: {transaction.TransactionId}, Date: {transaction.TransactionDate}, Amount: {transaction.Amount}, Type: {transaction.Type}, Reason: {transaction.Reason}");
            }
        }

        public void DepositMoney(int accountNumber, decimal amount, string reason)
        {
            Account account = GetAccount(accountNumber);
            if (account != null)
            {
                account.Deposit(amount);
                Transactions.Add(new Transaction(account, account.AccountHolder, amount, "Deposit", reason));
            }
        }

        public void WithdrawMoney(int accountNumber, decimal amount, string reason)
        {
            Account account = GetAccount(accountNumber);
            if (account != null && account.Status == "Active")
            {
                account.Withdraw(amount);
                Transactions.Add(new Transaction(account, account.AccountHolder, amount, "Withdrawal", reason));
            }
        }

        public void TransferMoney(int fromAccountNumber, int toAccountNumber, decimal amount, string reason)
        {
            Account fromAccount = GetAccount(fromAccountNumber);
            Account toAccount = GetAccount(toAccountNumber);
            if (fromAccount != null && toAccount != null && fromAccount.Status == "Active")
            {
                fromAccount.Withdraw(amount);
                toAccount.Deposit(amount);
                Transactions.Add(new Transaction(fromAccount, fromAccount.AccountHolder, -amount, "Transfer", reason));
                Transactions.Add(new Transaction(toAccount, toAccount.AccountHolder, amount, "Transfer", reason));
            }
        }

        public void ApplySavingsInterest(int accountNumber)
        {
            SavingAccount account = GetAccount(accountNumber) as SavingAccount;
            if (account != null && account.Status == "Active")
            {
                account.ApplyInterest();
            }
        }

        public void ApplyCheckingMonthlyFee(int accountNumber)
        {
            CheckingAccount account = GetAccount(accountNumber) as CheckingAccount;
            if (account != null && account.Status == "Active")
            {
                account.ApplyMonthlyFee();
            }
        }
    }
}
