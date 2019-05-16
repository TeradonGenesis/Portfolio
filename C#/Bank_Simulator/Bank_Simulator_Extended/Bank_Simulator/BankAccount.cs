using System;
namespace Bank_Simulator
{
	/// <summary>
	/// Bank account class is where the accounts are set up
	/// </summary>
	public class BankAccount
	{
		private int _accNumber;
		private double _balance;
		private AccountType _type;

		/// <summary>
		/// Initializes a new instance of the <see cref="T:Bank_Simulator.BankAccount"/> class.
		/// </summary>
		/// <param name="accNumber">Acc number.</param>
		public BankAccount(int accNumber)
		{
			_accNumber = accNumber;
			_type = AccountType.Savings;
		}

		/// <summary>
		/// Gets or sets the type.
		/// </summary>
		/// <value>The type.</value>
		public AccountType Type
		{
			get{return _type;}

			set{_type = value;}
	
		}

		/// <summary>
		/// Gets the acc number.
		/// </summary>
		/// <value>The acc number.</value>
		public int AccNumber
		{
			get
			{
				return _accNumber;
			}
		}

		/// <summary>
		/// Gets the balance.
		/// </summary>
		/// <value>The balance.</value>
		public double Balance
		{
			get
			{
				return _balance;

			}
		}

		/// <summary>
		/// Deposit the specified amt.
		/// </summary>
		/// <returns>The deposit.</returns>
		/// <param name="amt">Amt.</param>
		public void Deposit(double amt)
		{
			if (amt > 0)
			{
				_balance += amt;
			}
		}

		/// <summary>
		/// Withdraw the specified amt.
		/// </summary>
		/// <returns>The withdraw.</returns>
		/// <param name="amt">Amt.</param>
		public virtual void Withdraw(double amt)
		{
			if (_balance < amt)
			{
				_balance = 0;
				Console.WriteLine("Insufficient Funds (Account = {0})\n", AccNumber);
			}
			else
			{
				_balance -= amt;
			}
		}

		/// <summary>
		/// Details this instance.
		/// </summary>
		/// <returns>The details.</returns>
		public virtual string Details()
		{
			string AccountDetail = Type + " Account :\t" + AccNumber + "\tBalance :\t" + Balance + "\n";
			return AccountDetail;
		}

	}
}
