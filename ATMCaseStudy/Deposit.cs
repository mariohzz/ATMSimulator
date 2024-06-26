// Deposit.cs
// Represents a deposit ATM transaction.
public class Deposit : Transaction
{
   private decimal amount; // amount to deposit
   private Keypad keypad; // reference to the Keypad
   private DepositSlot depositSlot; // reference to the deposit slot

   // constant representing cancel option
   private const int CANCELED = 0;

   // five-parameter constructor initializes class's instance variables
   public Deposit( int userAccountNumber, Screen atmScreen, 
      BankDatabase atmBankDatabase, Keypad atmKeypad, 
      DepositSlot atmDepositSlot )
      : base( userAccountNumber, atmScreen, atmBankDatabase )
   {
      // initialize references to keypad and deposit slot
      keypad = atmKeypad;
      depositSlot = atmDepositSlot;
   } // end five-parameter constructor

   // perform transaction; overrides Transaction's abstract method
   public override void Execute()
   {
      amount = PromptForDepositAmount(); // get deposit amount from user

      // check whether user entered a deposit amount or canceled
      if ( amount != CANCELED )
      {
         // request deposit envelope containing specified amount
         UserScreen.DisplayMessage(
            "\nPlease insert a deposit envelope containing " );
         UserScreen.DisplayDollarAmount( amount );
         UserScreen.DisplayMessageLine( " in the deposit slot." );

         // retrieve deposit envelope
         bool envelopeReceived = depositSlot.IsDepositEnvelopeReceived();

         // check whether deposit envelope was received
         if ( envelopeReceived )
         {
            UserScreen.DisplayMessageLine(
               "\nYour envelope has been received.\n" +
               "The money just deposited will not be available " +
               "until we \nverify the amount of any " +
               "enclosed cash, and any enclosed checks clear." );

            // credit account to reflect the deposit
            Database.Credit( AccountNumber, amount );
         } // end inner if
         else
            UserScreen.DisplayMessageLine(
               "\nYou did not insert an envelope, so the ATM has " +
               "canceled your transaction." );
      } // end outer if
      else
         UserScreen.DisplayMessageLine( "\nCanceling transaction..." );
   } // end method Execute

   // prompt user to enter a deposit amount to credit
   private decimal PromptForDepositAmount()
   {
      // display the prompt and receive input
      UserScreen.DisplayMessage(
         "\nPlease input a deposit amount in CENTS (or 0 to cancel): " );
      int input = keypad.GetInput();

      // check whether the user canceled or entered a valid amount
      if ( input == CANCELED )
         return CANCELED;
      else
         return input / 100.00M;
   } // end method PromptForDepositAmount
} // end class Deposit


