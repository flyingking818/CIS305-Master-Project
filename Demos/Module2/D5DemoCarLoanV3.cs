/*============App requirements===========
 
For Car class, 
    set the minimum loan amount to 5000. 

For CarLoan class, further extensions:
 Add business rules
 1) For LoanAmount, if the car year is earlier than 2008, no loan is provided. (*overriding base class members)
 2) For LoanNumber, if the number is over 1000, then use the mod. Anyone remember what is mod?  10%3= 1
*/

using static System.Console;
class DemoCarLoanV3
{
   static void Main()
   {  //Instantiate objects
      Loan aLoan = new Loan();
      CarLoan aCarLoan = new CarLoan();
      
      //Set properties values
      aLoan.LoanNumber = 2239;
      aLoan.LastName = "Mitchell";
      aLoan.LoanAmount = 1_000.00;

      aCarLoan.LoanNumber = 1800;
      aCarLoan.LastName = "Jansen";
      aCarLoan.LoanAmount = 20_000.00;
      aCarLoan.Make = "Ford";
      aCarLoan.Year = 2007;
      
      //Display outputs
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

class Loan
{
   public const double MINIMUM_LOAN = 5_000;
   protected double loanAmount;  //instance variable
    /*
     A protected data field or method: (all within the family)
         Can be used within its own class or in any classes extended from that class
         Cannot be used by �outside� classes
         protected data members should be used sparingly
    */
   public int LoanNumber {get; set;}
   public string LastName {get; set;}
   public double LoanAmount
   {
      set
      {  //for photo project, check this for the size rule
         if(value < MINIMUM_LOAN)
            loanAmount = MINIMUM_LOAN;  //require $5000 as the minimum borrowing amount!
         else
            loanAmount = value;
      }
      get
      {
         return loanAmount;
      }
   }
}

class CarLoan : Loan
{
   private const int EARLIEST_YEAR = 2008;
   private const int LOWEST_INVALID_NUM = 1000;
   private int year;
   public int Year
   {
      set
      {
         if(value < EARLIEST_YEAR)
         {
            year = value;
            loanAmount = 0;  //overriding base class member
         }
         else
            year = value;
      }
      get
      {
         return year;
      }
   }
   public string Make {get; set;}
   public new int LoanNumber
   {
      get
      {
         return base.LoanNumber;
      }
      set
      {
         if(value < LOWEST_INVALID_NUM)
            base.LoanNumber = value;
         else
            base.LoanNumber = value % LOWEST_INVALID_NUM;
      }
   }
}
