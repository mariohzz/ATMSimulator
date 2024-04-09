// Transaction.cs
// Abstract base class Transaction represents an ATM transaction.
public abstract class Transaction
{
   private int accountNumber; // account involved in the transaction
   private Screen userScreen; // reference to ATM's screen
   private BankDatabase database; // reference to account info database

   // three-parameter constructor invoked by derived classes
   public Transaction( int userAccount, Screen theScreen, 
      BankDatabase theDatabase )
   {
      accountNumber = userAccount;
      userScreen = theScreen;
      database = theDatabase;
   } // end constructor

   // read-only property that gets the account number
   public int AccountNumber
   {
      get
      {
         return accountNumber;
      } // end get
   } // end property AccountNumber

   // read-only property that gets the screen reference
   public Screen UserScreen
   {
      get
      {
         return userScreen;
      } // end get
   } // end property UserScreen

   // read-only property that gets the bank database reference
   public BankDatabase Database
   {
      get
      {
         return database;
      } // end get
   } // end property Database

   // perform the transaction (overridden by each derived class)
   public abstract void Execute(); // no implementation here
} // end class Transaction



