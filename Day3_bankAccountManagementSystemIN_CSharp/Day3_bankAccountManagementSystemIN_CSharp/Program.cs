using System;
using System.Net.NetworkInformation;
using System.Security.Principal;
using static System.Runtime.InteropServices.JavaScript.JSType;



Console.WriteLine("Welcome to Bank account management Sysytem");

// Create a SavingAccount instance
Day3_bankAccountManagementSysytemIN_CSharp.SavingAccount savingAcc = new Day3_bankAccountManagementSysytemIN_CSharp.SavingAccount("SA123", "1234", 5.0m, "BR001");
savingAcc.Deposit(1000);
decimal interest = savingAcc.CalculateInterest();
Console.WriteLine($"Interest for Saving Account: {interest}");
//same assembly hence protected member interestRate is accessible here

// Create a CorporateAccount instance from another assembly
CorporateAccount corpAcc = new CorporateAccount("CA123", "5678", 7.0m, "BR002");
corpAcc.Deposit(5000);
corpAcc.ApplyCorporateInterest();
Console.WriteLine("Corporate Account interest applied successfully.");
//protected internal member interestRate is accessible here as CorporateAccount is derived from BankAccount


//| *Requirement*                             | *Access Modifier Used* |
//| ------------------------------------------- | ------------------------ |
//| Account PIN must be hidden                  | private                |
//| Account number accessible everywhere        | public                 |
//| Interest calculation for derived accounts   | protected              |
//| Bank audit logic shared within bank project | internal               |
//| Extension by partner banks & internal use   | protected internal     |

//Step 1: Create a base class 'BankAccount' with appropriate access modifiers( Core banking assebly)
//Step 2: Derive classes like 'SavingsAccount' and 'CurrentAccount' from 'BankAccount' to demonstrate protected access modifier. (Same assembly) 
//Step 3: Create another assembly/project for 'BankAudit' to demonstrate internal access modifier.