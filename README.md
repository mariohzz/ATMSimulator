a simple ATM program in C# demonstrating OOP concepts

Classes:
Account: Represents a bank account with properties like balance, account number, and PIN. It can have methods for deposit, withdrawal (checking balance first), and maybe even a method to display current balance.
ATM: Represents the ATM machine itself. It interacts with the Account object and provides functionalities such as PIN verification, menu display for transactions (deposit, withdrawal, etc.), and calling the appropriate Account methods.

Principles Demonstrated:
Encapsulation: Account data (balance, PIN) is hidden within the Account class, accessible only through its methods (deposit, withdrawal).
Abstraction: The ATM class interacts with the Account object without needing to know the internal workings of how the account calculates balance or stores data.
