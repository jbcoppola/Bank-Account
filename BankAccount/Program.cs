using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BankAccount
{
	class Program
	{
		static void Main(string[] args)
		{
			//create account objects and write file headers for each
			Checking checking = new Checking("Bill", "Gates");
			checking.WriteInitialDataToFiles();
			Reserve reserve = new Reserve("Bill", "Gates");
			reserve.WriteInitialDataToFiles();
			Savings savings = new Savings("Bill", "Gates");
			savings.WriteInitialDataToFiles();

			//will run until user enters 5 (exit)
			while (true)
			{
				//display menu 1-5, then have user pick their choice
				DisplayUserOptions();
				int input = GetInput(5);
				Console.Clear();
				switch (input)
				{
					case 1: //display name
						Console.WriteLine(savings.FullName);
						Console.ReadLine();
						break;
					case 2: //display money
						Console.WriteLine("Checking balance: {0}", checking.Balance);
						Console.WriteLine("Reserve balance: {0}", reserve.Balance);
						Console.WriteLine("Savings balance: {0}", savings.Balance);
						Console.ReadLine();
						break;
					case 3: //deposit to an account
						input = ChooseAccount();
						switch (input)
						{
							case 1:
								checking.LogDeposit();
								break;
							case 2:
								reserve.LogDeposit();
								break;
							case 3:
								savings.LogDeposit();
								break;
							default:
								break;
						}
						Console.ReadLine();
						break;
					case 4: //withdraw from an account
						input = ChooseAccount();
						switch (input)
						{
							case 1:
								checking.LogWithdraw();
								break;
							case 2:
								reserve.LogWithdraw();
								break;
							case 3:
								savings.LogWithdraw();
								break;
							default:
								break;
						}
						Console.ReadLine();
						break;
					case 5: //quit
						Environment.Exit(0);
						break;
					default: //shouldn't happen
						break;
				}
			}
		}

		//displays user options
		static void DisplayUserOptions()
		{
			Console.Clear();
			Console.WriteLine("Please select number for action.");
			Console.WriteLine();
			Console.WriteLine("1 - View client information");
			Console.WriteLine("2 - View account balance");
			Console.WriteLine("3 - Deposit funds");
			Console.WriteLine("4 - Withdraw funds");
			Console.WriteLine("5 - Exit");
		}

		//displays client name
		static void DisplayClientInfo(Account account)
		{
			Console.WriteLine("Client name: {0}", account.FullName);
		}
		
		//displays money in accounts
		static void DisplayBankingInfo(Account account)
		{
			Console.WriteLine(account.Balance);
		}

		//returns input between (inclusive) 1 and maxInput
		static int GetInput(int maxInput)
		{
			int input = -1;
			while (input < 1 || input > maxInput)
			{
				try
				{
					input = int.Parse(Console.ReadLine());
				}
				catch(FormatException)
				{
					Console.WriteLine("Invalid input. Please enter a number 1-{0}.", maxInput);
				}
			}
			return input;
		}

		//select which account to do something to
		static int ChooseAccount()
		{
			Console.WriteLine("Choose account.");
			Console.WriteLine("1 - Checking");
			Console.WriteLine("2 - Reserve");
			Console.WriteLine("3 - Savings");
			return GetInput(3);
		}
	}
}
