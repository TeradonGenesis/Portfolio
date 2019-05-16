using System;
using System.Collections.Generic;

namespace Bank_Simulator
{
	/// <summary>
	/// Main class.
	/// </summary>
	class MainClass
	{
		/// <summary>
		/// Shows all.
		/// </summary>
		/// <param name="accounts">Accounts.</param>
		public static void ShowAll(BankAccount[] accounts)
		{
 
			foreach (BankAccount a in accounts)
			{
				///Prints an instance of the bank details for each bank account [4]
				Console.WriteLine(a.Details());
			}
		}

		/// <summary>
		/// The entry point of the program, where the program control starts and ends.
		/// </summary>
		/// <param name="args">The command-line arguments.</param>
		public static void Main(string[] args)
		{

			///Initialise the accounts into arrays
			BankAccount[] myAccount = new BankAccount[4];
			myAccount[0] = new BankAccount(111);
			myAccount[1] = new CurrentAccount(222);
			myAccount[2] = new FixedDepositAccount(333, 1);
			myAccount[3] = new BankAccount(444);

			///Prints out all the bank account details
			MainClass.ShowAll(myAccount);

			///Performing banking operation
			myAccount[0].Deposit(100);
			myAccount[1].Deposit(100000);
			myAccount[1].Withdraw(3000);
			myAccount[2].Deposit(500);
			myAccount[2].Withdraw(300);
			myAccount[3].Withdraw(200);

			///Updates the balance of the bank accounts
			MainClass.ShowAll(myAccount);

			Console.ReadLine();
		}
	}
}
