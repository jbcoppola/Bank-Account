using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
	class Reserve : Account
	{
		//fields
		private string accountType = "Reserve";

		//properties
		//read-only, will never change per account
		public new string AccountType
		{
			get { return this.accountType; }
		}

		//constructors
		public Reserve(string firstName, string lastName) : base(firstName, lastName, "Reserve")
		{
		}
		//methods
		//will always write to checking file
		public void LogDeposit()
		{
			base.LogDeposit(AccountType);
		}

		public void LogWithdraw()
		{
			base.LogWithdraw(AccountType);
		}

		public void WriteInitialDataToFiles()
		{
			base.WriteInitialDataToFiles(AccountType);
			WriteToFile(AccountType, AccountType);
		}
	}
}
