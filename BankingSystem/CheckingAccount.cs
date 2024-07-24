namespace BankingSystem
{
    // Checking Account class
    public class CheckingAccount : Account
    {
        public double InterestRate { get; private set; }
        public decimal OverdraftLimit { get; private set; }
        public decimal MonthlyFee { get; private set; }

        public CheckingAccount(int accountNumber, Customer accountHolder, double interestRate, decimal overdraftLimit, decimal monthlyFee)
            : base(accountNumber, accountHolder)
        {
            InterestRate = interestRate;
            OverdraftLimit = overdraftLimit;
            MonthlyFee = monthlyFee;
        }

        public override void Deposit(decimal amount)
        {
            if (Status == "Suspended" && Balance + amount > 0)
            {
                Status = "Active";
            }
            Balance += amount;
        }

        public override void Withdraw(decimal amount)
        {
            if (Status == "Active" && Balance - amount >= -OverdraftLimit)
            {
                Balance -= amount;
                if (Balance < 0)
                {
                    Status = "Suspended";
                }
            }
            else
            {
                throw new InvalidOperationException("Withdrawal exceeds overdraft limit.");
            }
        }

        public void ApplyMonthlyFee()
        {
            if (Status == "Active")
            {
                if (Balance >= MonthlyFee)
                {
                    Balance -= MonthlyFee;
                }
                else
                {
                    Balance -= MonthlyFee;
                    Status = "Suspended";
                }
            }
        }
    }
}
