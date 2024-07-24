namespace BankingSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Bank bank = new Bank();
            char option = ' ';

            while (option != '4')
            {
                Console.WriteLine("1 Customers");
                Console.WriteLine("  a Add Customer");
                Console.WriteLine("  b Remove Customer");
                Console.WriteLine("  c List all customers");
                Console.WriteLine("2 Accounts");
                Console.WriteLine("  a Create Account");
                Console.WriteLine("  b Deposit Money");
                Console.WriteLine("  c Withdraw Money");
                Console.WriteLine("  d Transfer Money");
                Console.WriteLine("  e List Transactions");
                Console.WriteLine("  f Apply Savings Interest");
                Console.WriteLine("  g Apply Checking Monthly Fee");
                Console.WriteLine("3 Reports");
                Console.WriteLine("  a List all accounts for a customer");
                Console.WriteLine("  b List all transactions for an account");
                Console.WriteLine("4 Exit");
                Console.Write("Please select an option: ");
                option = Console.ReadKey().KeyChar;
                Console.WriteLine();

                switch (option)
                {
                    case '1':
                        Console.Write("Select an option: ");
                        char subOption1 = Console.ReadKey().KeyChar;
                        Console.WriteLine();
                        if (subOption1 == 'a')
                        {
                            Console.Write("Enter Customer ID: ");
                            int id = int.Parse(Console.ReadLine());
                            Console.Write("Enter Customer Name: ");
                            string name = Console.ReadLine();
                            Console.Write("Enter Customer Email: ");
                            string email = Console.ReadLine();
                            Console.Write("Enter Customer Phone Number: ");
                            string phone = Console.ReadLine();
                            bank.AddCustomer(new Customer(id, name, email, phone));
                        }
                        else if (subOption1 == 'b')
                        {
                            Console.Write("Enter Customer ID to remove: ");
                            int id = int.Parse(Console.ReadLine());
                            bank.RemoveCustomer(id);
                        }
                        else if (subOption1 == 'c')
                        {
                            bank.ListCustomers();
                        }
                        break;
                    case '2':
                        Console.Write("Select an option: ");
                        char subOption2 = Console.ReadKey().KeyChar;
                        Console.WriteLine();
                        if (subOption2 == 'a')
                        {
                            Console.Write("Enter Account Number: ");
                            int accountNumber = int.Parse(Console.ReadLine());
                            Console.Write("Enter Customer ID: ");
                            int customerId = int.Parse(Console.ReadLine());
                            Customer accountHolder = bank.Customers.Find(c => c.CustomerId == customerId);
                            if (accountHolder != null)
                            {
                                Console.WriteLine("Select Account Type (s for Saving, c for Checking): ");
                                char accountType = Console.ReadKey().KeyChar;
                                Console.WriteLine();
                                if (accountType == 's')
                                {
                                    Console.Write("Enter Interest Rate: ");
                                    double interestRate = double.Parse(Console.ReadLine());
                                    Console.Write("Enter Withdrawal Limit: ");
                                    decimal withdrawalLimit = decimal.Parse(Console.ReadLine());
                                    Console.Write("Enter Minimum Balance: ");
                                    decimal minBalance = decimal.Parse(Console.ReadLine());
                                    bank.CreateAccount(new SavingAccount(accountNumber, accountHolder, interestRate, withdrawalLimit, minBalance));
                                }
                                else if (accountType == 'c')
                                {
                                    Console.Write("Enter Interest Rate: ");
                                    double interestRate = double.Parse(Console.ReadLine());
                                    Console.Write("Enter Overdraft Limit: ");
                                    decimal overdraftLimit = decimal.Parse(Console.ReadLine());
                                    Console.Write("Enter Monthly Fee: ");
                                    decimal monthlyFee = decimal.Parse(Console.ReadLine());
                                    bank.CreateAccount(new CheckingAccount(accountNumber, accountHolder, interestRate, overdraftLimit, monthlyFee));
                                }
                            }
                            else
                            {
                                Console.WriteLine("Customer not found.");
                            }
                        }
                        else if (subOption2 == 'b')
                        {
                            Console.Write("Enter Account Number: ");
                            int accountNumber = int.Parse(Console.ReadLine());
                            Console.Write("Enter Amount: ");
                            decimal amount = decimal.Parse(Console.ReadLine());
                            Console.Write("Enter Reason: ");
                            string reason = Console.ReadLine();
                            bank.DepositMoney(accountNumber, amount, reason);
                        }
                        else if (subOption2 == 'c')
                        {
                            Console.Write("Enter Account Number: ");
                            int accountNumber = int.Parse(Console.ReadLine());
                            Console.Write("Enter Amount: ");
                            decimal amount = decimal.Parse(Console.ReadLine());
                            Console.Write("Enter Reason: ");
                            string reason = Console.ReadLine();
                            bank.WithdrawMoney(accountNumber, amount, reason);
                        }
                        else if (subOption2 == 'd')
                        {
                            Console.Write("Enter From Account Number: ");
                            int fromAccountNumber = int.Parse(Console.ReadLine());
                            Console.Write("Enter To Account Number: ");
                            int toAccountNumber = int.Parse(Console.ReadLine());
                            Console.Write("Enter Amount: ");
                            decimal amount = decimal.Parse(Console.ReadLine());
                            Console.Write("Enter Reason: ");
                            string reason = Console.ReadLine();
                            bank.TransferMoney(fromAccountNumber, toAccountNumber, amount, reason);
                        }
                        else if (subOption2 == 'e')
                        {
                            Console.Write("Enter Account Number: ");
                            int accountNumber = int.Parse(Console.ReadLine());
                            bank.ListTransactions(accountNumber);
                        }
                        else if (subOption2 == 'f')
                        {
                            Console.Write("Enter Savings Account Number: ");
                            int accountNumber = int.Parse(Console.ReadLine());
                            bank.ApplySavingsInterest(accountNumber);
                        }
                        else if (subOption2 == 'g')
                        {
                            Console.Write("Enter Checking Account Number: ");
                            int accountNumber = int.Parse(Console.ReadLine());
                            bank.ApplyCheckingMonthlyFee(accountNumber);
                        }
                        break;
                    case '3':
                        Console.Write("Select an option: ");
                        char subOption3 = Console.ReadKey().KeyChar;
                        Console.WriteLine();
                        if (subOption3 == 'a')
                        {
                            Console.Write("Enter Customer ID: ");
                            int customerId = int.Parse(Console.ReadLine());
                            foreach (var account in bank.Accounts.FindAll(a => a.AccountHolder.CustomerId == customerId))
                            {
                                Console.WriteLine($"Account Number: {account.AccountNumber}, Balance: {account.Balance}, Creation Date: {account.CreationDate}, Status: {account.Status}");
                            }
                        }
                        else if (subOption3 == 'b')
                        {
                            Console.Write("Enter Account Number: ");
                            int accountNumber = int.Parse(Console.ReadLine());
                            bank.ListTransactions(accountNumber);
                        }
                        break;
                    case '4':
                        Console.WriteLine("Exiting...");
                        break;
                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
            }
        }
    }
}
