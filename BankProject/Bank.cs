using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankProject
{
    public class Bank
    {
        // Dictionary will store accounts
        public Dictionary<string, Account> accounts = new Dictionary<string, Account>();
        public string BankName;

        // Assign bank name in constructor
        public Bank(string BankingName)
        {
            BankName = BankingName;
        }

    }

    // Base class for different account types
    public class Account
    {
        public string OwnerName;
        public int Balance;
        public int WithdrawalLimit;

        // Method to make deposits to account balance
        public void Deposit(int Amount)
        {
            Balance += Amount;
            Console.WriteLine("Money deposited to account, new balance is: " + Balance);

            return;
        }

        // Method to make withdrawals from account balance
        public void Withdraw(int Amount)
        {

            // Only withdraw if the account has enough money and is not over withdrawal limit
            if (Balance >= Amount && (WithdrawalLimit >= Amount || WithdrawalLimit == 0))
            {
                Balance -= Amount;
                Console.WriteLine("Money withdrawn from account, new balance is: " + Balance);
            }
            else
            {
                Console.WriteLine("Insufficient funds or over withdrawal limit...");
            }

            return;
        }

        // Method to make transfers from a target account to a host account
        public void Transfer(Account Target, int Amount)
        {

            // Only withdraw if the target account has enough money
            if (Target.Balance >= Amount)
            {
                Target.Balance -= Amount;
                Console.WriteLine("Money withdrawn from target account, new balance is: " + Target.Balance);
                Balance += Amount;
                Console.WriteLine("Money deposited to account, new balance is: " + Balance);
            }
            else
            {
                Console.WriteLine("Insufficient funds on target account...");
            }

            return;
        }
    }

    // Base Checking account
    public class Checking : Account
    {
        public Checking(string Owner, int StartingBalance)
        {
            OwnerName = Owner;
            Balance = StartingBalance;
        }
    }

    // Base Investment account
    public class Investment : Account
    {

    }

    // Individual account with withdrawal limit of 500
    public class Individual : Investment
    {

        public Individual(string Owner, int StartingBalance)
        {
            OwnerName = Owner;
            Balance = StartingBalance;
            WithdrawalLimit = 500;
        }
    }

    // Corporate account
    public class Corporate : Investment
    {
        public Corporate(string Owner, int StartingBalance)
        {
            OwnerName = Owner;
            Balance = StartingBalance;
        }
    }
}
