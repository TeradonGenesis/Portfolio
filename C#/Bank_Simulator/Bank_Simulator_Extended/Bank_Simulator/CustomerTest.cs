using System;
using NUnit.Framework;

namespace Bank_Simulator
{
	[TestFixture]
	public class CustomerTest
	{
		/// <summary>
		/// Tests the customer constructor.
		/// </summary>
		[Test]
		public void TestCustomerConstructor()
		{
			Customer jia = new Customer("Jia", "E12345678");
			Assert.AreEqual("Jia", jia.CustomerName);
			Assert.AreEqual("E12345678", jia.Pin);
		}

		/// <summary>
		/// Tests the add account.
		/// </summary>
		[Test]
		public void TestAddAccount()
		{
			Customer eddie = new Customer("Eddie", "980780-13-9087");
			int count = eddie.CountAccounts;

			Assert.AreEqual(0, count, "There are no accounts here");

			eddie.AddAccounts(111, AccountType.Savings);
			eddie.AddAccounts(222, AccountType.FixedDeposit);
			eddie.AddAccounts(333, AccountType.Current);

			count = eddie.CountAccounts;

			Assert.AreEqual(3, count, "There are two accounts created");

		}

		/// <summary>
		/// Tests the remove accounts.
		/// </summary>
		[Test]
		public void TestRemoveAccounts()
		{
			Customer irene = new Customer("Irene", "908765-12-7689");

			irene.AddAccounts(333, AccountType.Savings);
			irene.AddAccounts(444, AccountType.Current);
			irene.AddAccounts(555, AccountType.FixedDeposit);
			int count = irene.CountAccounts;

			Assert.AreEqual( 3, count, "There are two accounts");

			irene.RemoveAccounts(333);
			count = irene.CountAccounts;

			Assert.AreEqual(2, count, "There is one account");

			Assert.AreEqual(444, irene[0].AccNumber);
			Assert.AreEqual(AccountType.Current, irene[0].Type);
			Assert.AreEqual(555, irene[1].AccNumber);
			Assert.AreEqual(AccountType.FixedDeposit, irene[1].Type);

		}

		/// <summary>
		/// Tests the customer deposit.
		/// </summary>
		[Test]
		public void TestCustomerDeposit()
		{
			Customer irene = new Customer("Irene", "908765-12-7689");

			irene.AddAccounts(555, AccountType.Current);
			irene.AddAccounts(666, AccountType.Savings);
			irene.AddAccounts(777, AccountType.FixedDeposit);

			irene.CustomerDeposit(555, 10000);
			irene.CustomerDeposit(666, 2500);
			irene.CustomerDeposit(777, 1000);

			BankAccount TheCurrentAccount = irene[0];
			BankAccount TheSavingsAccount = irene[1];
			BankAccount TheFixedDepositAccount = irene[2];

			Assert.AreEqual(10000,TheCurrentAccount.Balance );

			Assert.AreEqual(2500,TheSavingsAccount.Balance );

			Assert.AreEqual(1000,TheFixedDepositAccount.Balance );	
		}

		/// <summary>
		/// Tests the customer withdraw.
		/// </summary>
		[Test]
		public void TestCustomerWithdraw()
		{
			Customer brawn = new Customer("Brawn", "945678-11-9087");

			brawn.AddAccounts(555, AccountType.Savings);
			brawn.AddAccounts(777, AccountType.FixedDeposit);
			brawn.AddAccounts(888, AccountType.Current);

			brawn.CustomerDeposit(555, 2500);
			brawn.CustomerDeposit(777, 2500);
			brawn.CustomerDeposit(888, 12500);

			brawn.CustomerWithdraw(555, 3000);
			brawn.CustomerWithdraw(777, 1000);
			brawn.CustomerWithdraw(888, 3000);

			BankAccount TheSavingsAccount = brawn[0];
			BankAccount TheFixedDepositAccount = brawn[1];
			BankAccount TheCurrentAccount = brawn[2];

			Assert.AreEqual(0, TheSavingsAccount.Balance);
			Assert.AreEqual(1500, TheFixedDepositAccount.Balance);
			Assert.AreEqual(12500, TheCurrentAccount.Balance);
		}

		/// <summary>
		/// Tests the customer fetch.
		/// </summary>
		[Test]
		public void TestCustomerFetch()
		{
			Customer lim = new Customer("Lim", "K12345678");
				
			lim.AddAccounts(111, AccountType.Savings);
			lim.AddAccounts(222, AccountType.Current);
			lim.AddAccounts(333, AccountType.FixedDeposit);

			BankAccount SavingsAccountFetched = lim[0];
			BankAccount CurrentAccountFetched = lim[1];
			BankAccount FixedAccountFetched = lim[2];

			lim.CustomerDeposit(111, 12500);
			lim.CustomerWithdraw(111, 3000);

			Assert.AreEqual(111, SavingsAccountFetched.AccNumber);
			Assert.AreEqual(AccountType.Savings, SavingsAccountFetched.Type);
			Assert.AreEqual(9500, SavingsAccountFetched.Balance);
			StringAssert.AreEqualIgnoringCase("Savings Account :\t111\tBalance :\t9500\n", SavingsAccountFetched.Details());

			Assert.AreEqual(222, CurrentAccountFetched.AccNumber);
			Assert.AreEqual(AccountType.Current, CurrentAccountFetched.Type);
			Assert.AreEqual(0, CurrentAccountFetched.Balance);
			Assert.AreEqual(100000, ((CurrentAccount)CurrentAccountFetched).Limit);
			StringAssert.AreEqualIgnoringCase("Current Account :\t222\tBalance :\t0\nYour balance cannot be less than 100000\n", CurrentAccountFetched.Details());

			Assert.AreEqual(333, FixedAccountFetched.AccNumber);
			Assert.AreEqual(AccountType.FixedDeposit, FixedAccountFetched.Type);
			Assert.AreEqual(0, FixedAccountFetched.Balance);
			Assert.AreEqual(1, ((FixedDepositAccount)FixedAccountFetched).Tenure);
			StringAssert.AreEqualIgnoringCase("FixedDeposit Account :\t333\tBalance :\t0\nYour account tenure is: 1month\n", FixedAccountFetched.Details());
		}

		/// <summary>
		/// Tests the indexer.
		/// </summary>
		[Test]
		public void TestIndexer()
		{
			Customer lim = new Customer("Lim", "K12345678");
			lim.AddAccounts(111, AccountType.Savings);
			lim.AddAccounts(222, AccountType.Current);

			BankAccount LimSavingsAccount = lim[0];
			BankAccount LimCurrentAccount = lim[1];

			Assert.AreEqual(111, LimSavingsAccount.AccNumber);
			Assert.AreEqual(AccountType.Savings, LimSavingsAccount.Type);
			Assert.AreEqual(222, LimCurrentAccount.AccNumber);
			Assert.AreEqual(AccountType.Current, LimCurrentAccount.Type);

			Customer brawn = new Customer("Brawn", "945678-11-9087");
			brawn.AddAccounts(777, AccountType.FixedDeposit);
			brawn.AddAccounts(888, AccountType.Current);

			BankAccount BrawnSavingsAccount = brawn[0];
			BankAccount BrawnCurrentAccount = brawn[1];

			Assert.AreEqual(777, BrawnSavingsAccount.AccNumber);
			Assert.AreEqual(AccountType.FixedDeposit, BrawnSavingsAccount.Type);
			Assert.AreEqual(888, BrawnCurrentAccount.AccNumber);
			Assert.AreEqual(AccountType.Current, BrawnCurrentAccount.Type);

		}

		/// <summary>
		/// Tests the customer tenure.
		/// </summary>
		[Test]
		public void TestCustomerTenure()
		{
			Customer Lim = new Customer("Lim", "K12345678");
			Lim.AddAccounts(111, AccountType.FixedDeposit);

			BankAccount AccountTenure = Lim[0];

			Assert.AreEqual(1, ((FixedDepositAccount)AccountTenure).Tenure);
		}

		[Test]
		public void TestCustomerLimit()
		{
			Customer Lim = new Customer("Lim", "K12345678");
			Lim.AddAccounts(111, AccountType.Current);

			BankAccount AccountLimit = Lim[0];

			Assert.AreEqual(100000, ((CurrentAccount)AccountLimit).Limit);
		}
	}
}
