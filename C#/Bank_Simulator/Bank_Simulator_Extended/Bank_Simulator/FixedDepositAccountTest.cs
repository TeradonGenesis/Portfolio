using System;
using NUnit.Framework;

namespace Bank_Simulator
{
	public class FixedDepositAccountTest
	{
		/// <summary>
		/// Tests the constructors.
		/// </summary>
		[Test]
		public void TestConstructors()
		{
			BankAccount a = new FixedDepositAccount(111, 1);
			Assert.AreEqual(111, a.AccNumber);
			Assert.AreEqual(1, ((FixedDepositAccount) a).Tenure);
		}

		/// <summary>
		/// Tests the deposit.
		/// </summary>
		[Test]
		public void TestDeposit()
		{
			BankAccount a2 = new FixedDepositAccount(111, 1);
			a2.Deposit(100);
			Assert.AreEqual(100, a2.Balance);
		}

		/// <summary>
		/// Tests the withdraw.
		/// </summary>
		[Test]
		public void TestWithdraw()
		{
			BankAccount a3 = new FixedDepositAccount(444, 1);
			a3.Deposit(500);
			a3.Withdraw(200);
			Assert.AreEqual(300, a3.Balance);
		}

		/// <summary>
		/// Tests the withdraw with zero.
		/// </summary>
		[Test]
		public void TestWithdrawWithZero()
		{
			BankAccount a4 = new FixedDepositAccount(222, 1);
			a4.Withdraw(100);
			Assert.AreEqual(0, a4.Balance);
		}

		/// <summary>
		/// Tests the details.
		/// </summary>
		[Test]
		public void TestDetails()
		{
			BankAccount a5 = new FixedDepositAccount(222, 1);
			a5.Deposit(500);
			a5.Withdraw(300);

			string AccountDetail = a5.Type + " Account :\t" + a5.AccNumber + "\tBalance :\t" + a5.Balance + "\n";
			string AccountTenure = "Your account tenure is: " + ((FixedDepositAccount)a5).Tenure + "month" + "\n";
			StringAssert.AreEqualIgnoringCase(AccountDetail + AccountTenure, a5.Details());
		}

		/// <summary>
		/// Tests the tenure.
		/// </summary>
		public void TestTenure()
		{
			BankAccount a6 = new FixedDepositAccount(222, 5);
			BankAccount a7 = new FixedDepositAccount(333, 3);

			Assert.AreEqual(5, ((FixedDepositAccount)a6).Tenure);
			Assert.AreEqual(3, ((FixedDepositAccount)a7).Tenure);
		}

	}
}
