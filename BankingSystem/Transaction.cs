namespace BankingSystem
{
    // Transaction class
    public class Transaction
    {
        public Guid TransactionId { get; private set; }
        public Account Account { get; private set; }
        public Customer Customer { get; private set; }
        public decimal Amount { get; private set; }
        public DateTime TransactionDate { get; private set; }
        public string Type { get; private set; }
        public string Reason { get; private set; }

        public Transaction(Account account, Customer customer, decimal amount, string type, string reason)
        {
            TransactionId = Guid.NewGuid();
            Account = account;
            Customer = customer;
            Amount = amount;
            TransactionDate = DateTime.Now;
            Type = type;
            Reason = reason;
        }
    }
}
