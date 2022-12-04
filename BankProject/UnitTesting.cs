using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankProject
{
    internal class UnitTesting
    {

        public Bank BigBank = new Bank("WellsFargo");

        private void InitializeBank()
        {
            // Fill bank with 3 types of accounts and starting balances
            Checking paul = new Checking("Paul", 0);
            Individual anne = new Individual("Anne", 2000);
            Corporate kar = new Corporate("KarGlobal", 1000000);

            BigBank.accounts.Add(paul.OwnerName, paul);
            BigBank.accounts.Add(anne.OwnerName, anne);
            BigBank.accounts.Add(kar.OwnerName, kar);

            return;
        }

        private void TestWithdrawals()
        {

            // Test withdrawing with not enough funds edge case, expecting false
            BigBank.accounts["Paul"].Withdraw(400);

            // Test withdrawing with enough funds at withdrawal limit for individual, expecting true
            BigBank.accounts["Anne"].Withdraw(500);

            // Test withdrawing while over the withdrawal limit for individual account with enough money, expecting false
            BigBank.accounts["Anne"].Withdraw(510);

            // Test withdrawing past withdrawal limit for corporate account, expecting true
            BigBank.accounts["KarGlobal"].Withdraw(50000);

            return;
        }

        private void TestDeposits()
        {

            // Test depositing money with all accounts
            BigBank.accounts["Paul"].Deposit(1);
            BigBank.accounts["Anne"].Deposit(1000);
            BigBank.accounts["KarGlobal"].Deposit(100000);

            return;
        }

        private void TestTransfers()
        {
            // Test transfering with not enough funds on target edge case, expecting false
            BigBank.accounts["Anne"].Transfer(BigBank.accounts["Paul"], 400);

            // Test transfering with enough funds, expecting true
            BigBank.accounts["Paul"].Transfer(BigBank.accounts["Anne"], 500);

            // Test withdrawing with enough funds corporate, expecting true
            BigBank.accounts["KarGlobal"].Transfer(BigBank.accounts["Anne"], 50);

            return;

        }

        private static void Main(string[] args)
        {

            UnitTesting test = new UnitTesting();

            // Display bank name and run tests
            Console.WriteLine("Bank Name: " + test.BigBank.BankName);
            test.InitializeBank();
            test.TestWithdrawals();
            test.TestDeposits();
            test.TestTransfers();

            return;
        }

    }

}
