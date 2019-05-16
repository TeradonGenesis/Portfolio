using System;
namespace Bank_Simulator
{
	/// <summary>
	/// Current account is a child class of BankAccount
	/// </summary>
	public class CurrentAccount : BankAccount
	{
		private double _limit;
		private double _balance;

		/// <summary>
		/// Initializes a new instance of the <see cref="T:Bank_Simulator.CurrentAccount"/> class.
		/// </summary>
		/// <param name="accNumber">Acc number.</param>
		public CurrentAccount(int accNumber) : base(accNumber)
		{
			_limit = 100000;
			Type = AccountType.Current;
		}

		/// <summary>
		/// Gets the limit.
		/// </summary>
		/// <value>The limit.</value>
		public double Limit
		{
			get { return _limit; }
		}

		/// <summary>
		/// Withdraw the specified amt.
		/// </summary>
		/// <returns>The withdraw.</returns>
		/// <param name="amt">Amt.</param>
		public override void Withdraw(double amt)
		{
			if (_balance < Limit)
					Console.WriteLine("Withdraw failed (Account = {0}).\nYour current account balance cannot be less than 100000\n", AccNumber);
			do
			{
				if (Balance < amt)
				{
					_balance = 0;
					Console.WriteLine("Insufficient Funds (Account = {0})\n", AccNumber);
				}
				else 
				{
					_balance -= amt;
				}
			} while (Balance > Limit);

		}

		/// <summary>
		/// Details this instance.
		/// </summary>
		/// <returns>The details.</returns>
		public override string Details()
		{
			string AccountDetail = Type + " Account :\t" + AccNumber + "\tBalance :\t" + Balance + "\n";
			string AccountLimit = "Your balance cannot be less than " + Limit + "\n";
			return AccountDetail + AccountLimit;
		}
	}
}
