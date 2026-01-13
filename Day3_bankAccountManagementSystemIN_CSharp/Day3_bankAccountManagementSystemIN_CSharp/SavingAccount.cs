using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3_bankAccountManagementSysytemIN_CSharp
{
    // Derived class 'SavingAccount' from base class 'BankAccount'
    //so that it can access protected members, protected internal members, and public members of base class

    public class SavingAccount : BankAccount // derived class from BankAccount
    {
        public SavingAccount(string accNumber, string pin, decimal interest, string branchCode)
            : base(accNumber, pin, interest, branchCode)
        {
        }
        // Method to calculate interest for saving account
        public decimal CalculateInterest()
        {
            return balance * interestRate / 100;
        }

    }
}