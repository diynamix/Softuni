namespace MoneyTransactions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<int, double> accounts = new Dictionary<int, double>();

            string[] info = Console.ReadLine()
                .Split(",", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            foreach (string account in info)
            {
                int number = int.Parse(account.Split("-")[0]);
                double balance = double.Parse(account.Split("-")[1]);
                accounts[number] = balance;
            }

            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] tokens = input.Split();
                string cmd = tokens[0];

                try
                {
                    int accountNumber = int.Parse(tokens[1]);
                    double money = double.Parse(tokens[2]);

                    if (cmd == "Deposit")
                    {
                        if (!accounts.ContainsKey(accountNumber))
                        {
                            throw new ArgumentException("Invalid account!");
                        }

                        accounts[accountNumber] += money;

                        Console.WriteLine($"Account {accountNumber} has new balance: {accounts[accountNumber]:f2}");
                    }
                    else if (cmd == "Withdraw")
                    {
                        if (!accounts.ContainsKey(accountNumber))
                        {
                            throw new ArgumentException("Invalid account!");
                        }

                        if (accounts[accountNumber] < money)
                        {
                            throw new ArgumentException("Insufficient balance!");
                        }

                        accounts[accountNumber] -= money;

                        Console.WriteLine($"Account {accountNumber} has new balance: {accounts[accountNumber]:f2}");
                    }
                    else
                    {
                        throw new ArgumentException("Invalid command!");
                    }
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
                finally
                {
                    Console.WriteLine("Enter another command");
                }
            }
        }
    }
}
