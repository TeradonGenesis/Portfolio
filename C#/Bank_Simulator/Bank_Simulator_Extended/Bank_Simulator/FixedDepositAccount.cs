using System;
namespace Bank_Simulator
{
	/// <summary>
	/// Fixed deposit account that is the child class of BankAccount.
	/// </summary>
	public class FixedDepositAccount : BankAccount
	{
		private int _tenure;

		/// <summary>
		/// Initializes a new instance of the <see cref="T:Bank_Simulator.FixedDepositAccount"/> class.
		/// </summary>
		/// <param name="accNumber">Acc number.</param>
		/// <param name="tenure">Tenure.</param>
		public FixedDepositAccount(int accNumber, int tenure):base(accNumber)
		{
			_tenure = tenure;
			Type = AccountType.FixedDeposit;
		}

		/// <summary>
		/// Gets or sets the tenure.
		/// </summary>
		/// <value>The tenure.</value>
		public int Tenure
		{
			get { return _tenure;}
			set { _tenure = value; }
		}

		/// <summary>
		/// Details this instance.
		/// </summary>
		/// <returns>The details.</returns>
		public override string Details()
		{
			string AccountDetail = Type + " Account :\t" + AccNumber + "\tBalance :\t" + Balance + "\n";
			string AccountTenure = "Your account tenure is: " + Tenure + "month" + "\n";
			return AccountDetail + AccountTenure;
		}
	}
}
