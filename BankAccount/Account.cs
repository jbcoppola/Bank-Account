using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BankAccount
{
	abstract class Account
	{
		//fields
		private int accountNumber;
		private string firstName;
		private string lastName;
		private double balance;
		private string accountType;

		//properties
		public int AccountNumber
		{
			get { return this.accountNumber; }
			set { this.accountNumber = value; }
		}

		public string FirstName
		{
			get { return this.firstName; }
			set { this.firstName = value; }
		}

		public string LastName
		{
			get { return this.lastName; }
			set { this.lastName = value; }
		}

		public double Balance
		{
			get { return this.balance; }
			set { this.balance = value; }
		}

		public string FullName
		{
			get { return this.firstName + " " + this.lastName; }
		}

		public string AccountType
		{
			get { return this.accountType; }
		}

		//constructors
		//no constructors for an abstract class

		//methods
		//should only be accessed by other methods in derived classes, so is private
		protected double GetAmount(string action)
		{
			Console.WriteLine("Enter amount to {0}.", action);
			double amount = 0;
			while (amount <= 0)
			{
				try
				{
					amount = double.Parse(Console.ReadLine());
				}
				catch (FormatException)
				{
					Console.WriteLine("Please enter a number value greater than 0.");
				}
			}
			return amount;
		}

		public virtual void Deposit()
		{
			double amount = GetAmount("deposit");
			Balance += amount;
			LogAmount(true, amount);
		}


		public virtual void Withdraw()
		{
			double amount = GetAmount("withdraw");
			Balance -= amount;
			LogAmount(false, amount);
		}

		public string LogAmount(bool isDeposit, double amount)
		{
			DateTime current = DateTime.Now;
			string text = current.ToString();
			text += " : ";
			if (isDeposit)
			{
				text += "+" + amount;
			}
			else
			{
				text += "-" + amount;
			}
			text += ", current balance is $" + Balance;
			return text;
		}
	}
}
