namespace BankingSystem
{
    // Savings Account class
    public class SavingAccount : Account
    {
        public double InterestRate { get; private set; }
        public decimal WithdrawalLimit { get; private set; }
        public decimal MinBalance { get; private set; }

        public SavingAccount(int accountNumber, Customer accountHolder, double interestRate, decimal withdrawalLimit, decimal minBalance)
            : base(accountNumber, accountHolder)
        {
            InterestRate = interestRate;
            WithdrawalLimit = withdrawalLimit;
            MinBalance = minBalance;
        }

        public override void Deposit(decimal amount)
        {
            if (Status == "Suspended" && Balance + amount > MinBalance)
            {
                Status = "Active";
            }
            Balance += amount;
        }

        public override void Withdraw(decimal amount)
        {
            if (Status == "Active" && amount <= WithdrawalLimit && Balance - amount >= MinBalance)
            {
                Balance -= amount;
                if (Balance < MinBalance)
                {
                    Status = "Suspended";
                }
            }
            else
            {
                throw new InvalidOperationException("Withdrawal exceeds limit or would drop below minimum balance.");
            }
        }

        public void ApplyInterest()
        {
            if (Status == "Active")
            {
                Balance += Balance * (decimal)InterestRate;
            }
        }
    }
}
