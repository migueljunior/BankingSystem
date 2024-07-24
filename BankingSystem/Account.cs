namespace BankingSystem
{
    // Abstract class for Account
    public abstract class Account : IAccount
    {
        public int AccountNumber { get; protected set; }
        public decimal Balance { get; protected set; }
        public Customer AccountHolder { get; protected set; }
        public DateTime CreationDate { get; protected set; }
        public string Status { get; protected set; }

        public Account(int accountNumber, Customer accountHolder)
        {
            AccountNumber = accountNumber;
            AccountHolder = accountHolder;
            CreationDate = DateTime.Now;
            Status = "Active";
        }

        public abstract void Deposit(decimal amount);
        public abstract void Withdraw(decimal amount);
    }
}
