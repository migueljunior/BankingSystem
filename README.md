# BankingSystem
This repository contains the final project of Dev Fundamentals course.
## Exercise Requirements
The implementation must follow the next guidelines:
- The application interface must be in English.
- **Access Modifiers:** Use access modifiers appropriately.
- **Encapsulation:** : Ensure that data is encapsulated and provide methods to access and modify
the encapsulated data safely.
- **Inheritance:** Proper constructors and data extraction. Proper use of “base” and “override”
if used.
- **Interfaces:** Proper declaration and usage.
- **Association:** Properly associate classes between each other.
- **Error handling:** The program must not crash at any point.
## Exercise Explanation
### Objective
Create a console-based Banking System.
### Entities
#### SavingAccount
- **AccountNumber (int):** Unique identifier for the account.
- **Balance (decimal):** Current balance in the account.
- **AccountHolder (Customer):** Customer who holds this account.
- **InterestRate (double):** Interest rate applicable to the account.
- **CreationDate (DateTime):** Date when the account was created.
- **Status (string):** Status of the account (e.g., Active, Closed, Suspended).
- **WithdrawalLimit (decimal):** Maximum amount that can be withdrawn in a single transaction.
- **MinBalance (decimal):** Minimum balance that must be maintained.
#### CheckingAccount
- **AccountNumber (int):** Unique identifier for the account.
- **Balance (decimal):** Current balance in the account.
- **AccountHolder (string):** Customer who holds the account.
- **InterestRate (double):** Interest rate applicable to the account.
- **CreationDate (DateTime):** Date when the account was created.
- **Status (string):** Status of the account (e.g., Active, Closed, Suspended).
- **OverdraftLimit (decimal):** Maximum overdraft limit allowed.
- **MonthlyFee (decimal):** Monthly maintenance fee for the account.
#### Customer
- **CustomerId (int):** Unique identifier for the customer.
- **Name (string):** Name of the customer.
- **Email (string):** Email address of the customer.
- **PhoneNumber (string):** Phone number of the customer.
#### Transaction
- **TransactionId (Guid):** Unique identifier for the transaction.
- **Account (Account):** Account associated with the transaction.
- **Customer (Customer):** Customer associated with the transaction.
- **Amount (decimal):** Amount involved in the transaction.
- **TransactionDate (DateTime):** Date of the transaction.
- **Type (string):** Type of transaction (e.g., Deposit, Withdrawal).
- **Reason (string):** Reason for the transaction.
#### Bank
- **Customers (List\<Customer\>):** List of all customers.
- **Accounts (List\<Account\>):** List of all accounts.
- **Transactions (List\<Transaction\>):** List of all transactions.
### Menu
- Customers
  - Add Customer
  - Remove Customer
  - List all customers
- Accounts
  - Create Account
  - View Account Details
  - View Transaction History
  - Apply Savings Interest
  - Apply Checking Monthly Fee
- Transactions
  - Deposit Money
  - Withdraw Money
  - Transfer Money
- Exit
#### Menu Actions description
- **Customers > Add Customer:** Add a customer to customers list.
- **Customers > Remove Customer:** Remove a customer from customers list.
  - Remove all associated accounts.
- **Customers > List all customers:** Display all customers.
- **Accounts > Create Account:** Create an account.
- **Accounts > View Account Details:** Find an account and display its details.
- **Accounts > View Transaction History:** Find an account and display all its transactions.
- **Accounts > Apply savings interest:** Find a savings account and apply its interest rate.
  - Can only apply on active accounts.
- **Accounts > Apply checking monthly fee:** Find a checking account and apply its monthly fee.
  - Can only apply on active accounts.
  - If fee is more than account balance, suspend the account.
- **Transactions > Deposit Money:** Find a savings account and deposit money.
  - If account was suspended, activate the account after the deposit.
- **Transactions > Withdraw Money:** Find a savings account and withdraw money.
  - Can only apply on active accounts.
  - If account reaches MinBalance, suspend account.
- **Transactions > Transfer Money:** Find a savings account, and transfer money to another
account (savings or checking).
  - Source account must be active.
  - If target account was suspended, activate the account after the transfer.
- **Exit:** Terminate the program.