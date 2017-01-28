using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BankAccount
{
	class Account
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

		//constructor, only called by derived classes
		protected Account(string firstName, string lastName, string accountType)
		{
			this.FirstName = firstName;
			this.LastName = lastName;
			Random rand = new Random();
			this.AccountNumber = rand.Next(30000000);
			this.accountType = accountType;
		}

		//methods
		//should only be accessed by other methods in derived classes, so is protected
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

		//deposits user-entered amount of money into overall balance. Only used in LogDeposit, so private
		private double Deposit()
		{
			double amount = GetAmount("deposit");
			Balance += amount;
			return amount;
		}

		//logs and writes record of deposit transaction to file - base class will be altered by derived classes, 
		//so this will version never be called outside of derived class
		protected void LogDeposit(string filename)
		{
			double amount = Deposit();
			string text = TimestampAmountToString(true, amount);
			WriteToFile(filename, text);
			Console.WriteLine("${0} deposited.", amount);
		}
		
		//withdraws user-entered amount of money from overall balance. Only used in LogWithdraw, so private
		private double Withdraw()
		{
			double amount = GetAmount("withdraw");
			Balance -= amount;
			return amount;
		}

		//logs and writes record of deposit transaction to file - base class will be altered by derived classes, 
		//so this will version never be called outside of derived class
		protected void LogWithdraw(string filename)
		{
			double amount = Withdraw();
			string text = TimestampAmountToString(false, amount);
			WriteToFile(filename, text);
			Console.WriteLine("${0} withdrawn.", amount);
		}

		//creates the timestamp record of deposit string to be written into file
		protected string TimestampAmountToString(bool isDeposit, double amount)
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

		//writes name and account number to file at top of file
		protected virtual void WriteInitialDataToFiles(string filename)
		{
			StreamWriter writer = new StreamWriter(filename + ".txt");
			writer.WriteLine("Client name: " + this.FullName);
			writer.WriteLine("Account #: " + this.AccountNumber);
			writer.Close();
		}

		//writes desired text to specified file - base should only be used in derived classes, so is protected
		public void WriteToFile(string filename, string text)
		{
			StreamWriter writer = File.AppendText(filename + ".txt");
			writer.WriteLine(text);
			writer.Close();
		}

	}
}
