/* 
Create a base Loan Class with three properties
1) LoanNumber
2) LastName
3) Loan Amount
*/

/*===========Class Concepts Review=============
 Solution is defined in terms of a collection of cooperating objects
 Class serves as template from which many objects can be created (the instantiation process to create new objects!)
    Abstraction
    Attributes/properties (data)  ===> nouns / using pascal naming convention for properties and methods
    Behaviors/methods (processes on the data)  ==> verbs 

Can define your own classes from which other classes can inherit 
    Base class is called the super or parent class  
    Base class has (also called sub class or child class)
        Data members defined with a private (protected) access modifier ==> good for security/privacy purpose
        Constructors defined with public access modifiers => special methods for using the class/ black box (you need to 
have at least a default constructor)
        Properties offering public access to data fields
 */

using System;
using static System.Console;

class DemoLoanV1
{
    static void Main()
    {
        Loan aLoan = new Loan();  //object instantiation 
        aLoan.LoanNumber = 2239;  //dot notation to access properties and methods
        aLoan.LastName = "Mitchell";
        aLoan.LoanAmount = 1_000.00; //use _ for the "," for values. Not recommended, though. 
        aLoan.LoanStartDate = DateTime.Parse("2/2/2022");
        aLoan.APR = 3;
        WriteLine("Loan #{0} for {1} is for {2}, which was started on {3} at the APR of {4}.",
           aLoan.LoanNumber, aLoan.LastName,
           aLoan.LoanAmount.ToString("C2"),
           aLoan.LoanStartDate.ToString("MM/dd/yyyy"),
           aLoan.APR.ToString("P"));
    }  //implementation of the class
}

class Loan
{  // if you don't have any specific requirements/processing, then you can use the auto properties feature. 
    public int LoanNumber { get; set; }
    public string LastName { get; set; }
    public double LoanAmount { get; set; }  //hint: decimal  decimal loanAmount = 1000M
    public string Email { get; set; }
    public string LoanDuration { get; set; }
    public DateTime LoanStartDate { get; set; }

    //public double APR { get; set; }
    //Another alternative format (rocket symbol)
    public double apr = 0;
    public double APR
    //The APR property has special business rules. Therefore, the instance variables are required.
    {
        get
        {
            return apr;
        }
        set
        {
            if (value>.1)
            {
                apr = 0.08;       //set the max APR of the company. You may also perform calculations here.
            }
            else
            {
                apr = value;
            }
            
        }
    }
}
