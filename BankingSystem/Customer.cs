namespace BankingSystem
{
    // Customer class
    public class Customer
    {
        public int CustomerId { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string PhoneNumber { get; private set; }

        public Customer(int customerId, string name, string email, string phoneNumber)
        {
            CustomerId = customerId;
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
        }
    }
}
