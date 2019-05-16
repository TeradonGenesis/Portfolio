using System;
using System.Collections.Generic;

namespace Bank_Simulator
{
	/// <summary>
	/// Customer class where customer can create account, remove account, fetch account, withdrawing specific amount, depositing specific amount from a list.
	/// </summary>
	public class Customer
	{
		
		private string _customername;
		private string _pin;
		private List<BankAccount> _accounts;

		/// <summary>
		/// Initializes a new instance of the <see cref="T:Bank_Simulator.Customer"/> class.
		/// </summary>
		/// <param name="customername">Customername.</param>
		/// <param name="pin">Pin.</param>
		public Customer(string customername, string pin)
		{
			_customername = customername;
			_pin = pin;
			_accounts = new List<BankAccount>();
		}

		/// <summary>
		/// Gets the <see cref="T:Bank_Simulator.Customer"/> at the specified index.
		/// </summary>
		/// <param name="index">Index.</param>
		public BankAccount this[int index]
		{
			get { return _accounts[index];}
		}

		/// <summary>
		/// Gets or sets the name of the customer.
		/// </summary>
		/// <value>The name of the customer.</value>
		public string CustomerName
		{
			get { return _customername; }
			set { _customername = value; }
		}

		/// <summary>
		/// Gets or sets the pin.
		/// </summary>
		/// <value>The pin.</value>
		public string Pin
		{
			get { return _pin; }
			set { _pin = value; }
		}

		/// <summary>
		/// Adds the accounts.
		/// </summary>
		/// <param name="accNumber">Acc number.</param>
		/// <param name="type">Type.</param>
		public void AddAccounts(int accNumber, AccountType type)
		{
			if (type == AccountType.Savings)
			{
				_accounts.Add(new BankAccount(accNumber));
			}
			else if (type == AccountType.Current)
			{
				_accounts.Add(new CurrentAccount(accNumber));
			}
			else if (type == AccountType.FixedDeposit)
			{
				_accounts.Add(new FixedDepositAccount(accNumber, 1));
			}
		}

		/// <summary>
		/// Removes the accounts.
		/// </summary>
		/// <param name="accNumber">Acc number.</param>
		public void RemoveAccounts(int accNumber)
		{
			_accounts.RemoveAll(r => r.AccNumber==accNumber);
		}

		/// <summary>
		/// Gets the count accounts.
		/// </summary>
		/// <value>The count accounts.</value>
		public int CountAccounts
		{
			get { return _accounts.Count; }
		}

		/// <summary>
		/// Customers the deposit.
		/// </summary>
		/// <param name="accNumber">Acc number.</param>
		/// <param name="amount">Amount.</param>
		public void CustomerDeposit(int accNumber, double amount)
		{
			 var depositaccount = _accounts.Find(f => f.AccNumber == accNumber);
			 depositaccount.Deposit(amount);
		}

		/// <summary>
		/// Customers the withdraw.
		/// </summary>
		/// <param name="accNumber">Acc number.</param>
		/// <param name="amount">Amount.</param>
		public void CustomerWithdraw(int accNumber, double amount)
		{
			var withdrawaccount = _accounts.Find(f => f.AccNumber == accNumber);
			withdrawaccount.Withdraw(amount);
		}

	}
}
