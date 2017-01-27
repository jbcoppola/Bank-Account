using System;
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
		public new string AccountType
		{
			get { return this.accountType; }
		}

		//constructors
		public Savings(string firstName, string lastName)
		{
			this.FirstName = firstName;
			this.LastName = lastName;
			this.accountType = "Savings";
		}
		//methods
		public override void Deposit()
		{
			base.Deposit();
		}
	}
}
