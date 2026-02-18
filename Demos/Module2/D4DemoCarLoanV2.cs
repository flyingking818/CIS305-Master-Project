/*============App requirements===========
1) Extend Loan Class to CarLoan class (also called extended, inherited class, child class, sub class)
2) Add Year and Make properties
 */

/*===========Inheritance Concepts=============
Inheritance
    The principle that you can apply knowledge of a general category to more specific objects
    Similar to how your blood type and eye color are the products of inherited genes
Advantages of inheritance:
    Saves time by resuing codes
    Reduces the chance of errors
    Makes it easier to understand the inherited class
    Makes programs easier to write

 */


using static System.Console;
class DemoCarLoanV2
{
   static void Main()
   {
      Loan aLoan = new Loan();
      CarLoan aCarLoan = new CarLoan();
      aLoan.LoanNumber = 2239;
      aLoan.LastName = "Mitchell";
      aLoan.LoanAmount = 1_000.00;

        //Inheritance allows you to reuse codes!!!
      aCarLoan.LoanNumber = 3358;
      aCarLoan.LastName = "Jansen";
      aCarLoan.LoanAmount = 20_000.00;
      aCarLoan.Make = "Ford";
      aCarLoan.Year = 2007;

      WriteLine("Loan #{0} for {1} is for {2}",
         aLoan.LoanNumber, aLoan.LastName,
         aLoan.LoanAmount.ToString("C2"));
      WriteLine("Loan #{0} for {1} is for {2}",
         aCarLoan.LoanNumber, aCarLoan.LastName,
         aCarLoan.LoanAmount.ToString("C2"));
      WriteLine("   Loan #{0} is for a {1} {2}",
         aCarLoan.LoanNumber, aCarLoan.Year,
         aCarLoan.Make);
   }
}

//Base class Loan (also called superclass or parent class)
class Loan
{
   public int LoanNumber {get; set;}
   public string LastName {get; set;}
   public double LoanAmount {get; set;}
}

//Derived class CarLoan (also called subclass or child class) - *use : to specifiy the inherence relationship
//Interfaces is about ability to do something. - What can you do?
class CarLoan : Loan  //inherentence is about hierarchy of identifies. - Who are you?
{
   public int Year {get; set;}
   public string Make {get; set;}


}
