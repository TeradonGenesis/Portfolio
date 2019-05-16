using System;
using NUnit.Framework;

namespace Bank_Simulator
{
	public class CurrentAccountTest
	{
		/// <summary>
		/// Tests the constructors.
		/// </summary>
		[Test]
		public void TestConstructors()
		{
			BankAccount a = new CurrentAccount(111);
			Assert.AreEqual(111, a.AccNumber);
		}

		/// <summary>
		/// Tests the deposit.
		/// </summary>
		[Test]
		public void TestDeposit()
		{
			BankAccount a2 = new CurrentAccount(111);
			a2.Deposit(100);
			Assert.AreEqual(100, a2.Balance);
		}

		/// <summary>
		/// Tests the withdraw.
		/// </summary>
		[Test]
		public void TestWithdraw()
		{
			BankAccount a3 = new CurrentAccount(444);
			a3.Deposit(100000);
			a3.Withdraw(200);
			Assert.AreEqual(100000, a3.Balance);
		}

		/// <summary>
		/// Tests the withdraw with zero.
		/// </summary>
		[Test]
		public void TestWithdrawWithZero()
		{
			BankAccount a4 = new CurrentAccount(222);
			a4.Withdraw(100);
			Assert.AreEqual(0, a4.Balance);
		}

		/// <summary>
		/// Tests the details.
		/// </summary>
		[Test]
		public void TestDetails()
		{
			BankAccount a5 = new CurrentAccount(222);
			a5.Deposit(500);
			a5.Withdraw(300);

			string AccountDetail = a5.Type + " Account :\t" + a5.AccNumber + "\tBalance :\t" + a5.Balance + "\n";
			string AccountLimit = "Your balance cannot be less than " + ((CurrentAccount)a5).Limit + "\n";
			StringAssert.AreEqualIgnoringCase(AccountDetail + AccountLimit, a5.Details());
		}

		/// <summary>
		/// Tests the limit.
		/// </summary>
		public void TestLimit()
		{
			BankAccount a6 = new CurrentAccount(222);

			Assert.AreEqual(100000, ((CurrentAccount)a6).Limit);		
		}

	}
}
