using System;
using NUnit.Framework;

namespace Bank_Simulator
{
	/// <summary>
	/// Bank account test.
	/// </summary>
	[TestFixture]
	public class BankAccountTest
	{
		/// <summary>
		/// Tests the constructors.
		/// </summary>
		[Test]
		public void TestConstructors()
		{
			BankAccount a = new BankAccount(111);
			Assert.AreEqual(111,a.AccNumber);
		}

		/// <summary>
		/// Tests the deposit and return the correct balance.
		/// </summary>
	    [Test]
		public void TestDeposit()
		{
			BankAccount a2 = new BankAccount(111);
			a2.Deposit(100);
			Assert.AreEqual(100, a2.Balance);
		}

		/// <summary>
		/// Tests the withdraw and return the correct balance..
		/// </summary>
		[Test]
		public void TestWithdraw()
		{
			BankAccount a3 = new BankAccount(444);
			a3.Deposit(500);
			a3.Withdraw(200);
			Assert.AreEqual(300, a3.Balance);
		}

		/// <summary>
		/// Tests the withdraw by having it withdrawing over more money than the actual balance.
		/// </summary>
		[Test]
		public void TestWithdrawWithZero()
		{
			BankAccount a4 = new BankAccount(222);
			a4.Withdraw(100);
			Assert.AreEqual(0, a4.Balance);
		}

		/// <summary>
		/// Tests the details.
		/// </summary>
		[Test]
		public void TestDetails()
		{
			BankAccount a5 = new BankAccount(222);
			a5.Deposit(500);
			a5.Withdraw(300);

			string AccountDetail = a5.Type + " Account :\t" + a5.AccNumber + "\tBalance :\t" + a5.Balance + "\n";
			StringAssert.AreEqualIgnoringCase(AccountDetail, a5.Details());
		} 

	}
}
