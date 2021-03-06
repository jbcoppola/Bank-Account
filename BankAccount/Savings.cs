﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BankAccount
{
	class Savings : Account
	{
		//fields
		private string accountType = "Savings";

		//properties
		//read-only, will never change per account
		public new string AccountType
		{
			get { return this.accountType; }
		}

		//constructors
		public Savings(string firstName, string lastName) : base(firstName, lastName, "Savings")
		{
		}
		//methods
		//will always write to savings file
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
