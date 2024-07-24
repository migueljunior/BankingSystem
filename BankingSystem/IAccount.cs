namespace BankingSystem
{
    // Interface for Account
    public interface IAccount
    {
        int AccountNumber { get; }
        decimal Balance { get; }
        Customer AccountHolder { get; }
        DateTime CreationDate { get; }
        string Status { get; }
    }
}
