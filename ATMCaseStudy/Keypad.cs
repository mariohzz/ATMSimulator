// Keypad.cs
// Represents the keypad of the ATM.
using System;

public class Keypad
{
   // return an integer value entered by user
   public int GetInput()
   {
      return Convert.ToInt32( Console.ReadLine() );
   } // end method GetInput
} // end class Keypad


