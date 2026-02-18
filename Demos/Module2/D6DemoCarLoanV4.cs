/*============App requirements===========
 Polymorphism - Using the same method to indicate different implementations
 Inherit and extend override constructors
 Accessing Base Class Methods and Properties from a Derived Class 
 */

using static System.Console;
class DemoCarLoanV4
{
   static void Main()
   {
      Loan aLoan = new Loan(333, "Hanson", 7_000.00);
      CarLoan aCarLoan = new CarLoan(1888, "Carlisle", 30_000.00,
         2000, "BMW");

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
   protected double loanAmount;

    //Constructor - a method we use to instantiate objects and pass in values easily!
   public Loan(int num, string name, double amount)
   {
      LoanNumber = num;
      LastName = name;
      LoanAmount = amount;
   }
    /*
    public Loan(int num, string name, double amount, string carType)
    {
        LoanNumber = num;
        LastName = name;
        LoanAmount = amount;
        //CarType = carType;
    }

    public Loan(int num, string name, double amount, int years)
    {
        LoanNumber = num;
        LastName = name;
        LoanAmount = amount;
        //Years = years;
    }
    */

    public int LoanNumber {get; set;}
   public string LastName {get; set;}
   public double LoanAmount
   {
      set
      {
         if(value < MINIMUM_LOAN)
            loanAmount = MINIMUM_LOAN;
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

    /*
        When a base class constructor requires arguments, include a constructor for each derived class you create
            The derived class constructor can contain any number of statements
        Within the header, provide values for any arguments required by the base class constructor
            Use the keyword base
     */
    public CarLoan(int num, string name, double amount,
      int year, string make) : base(num, name, amount)
   {
      Year = year;
      Make = make;
      LoanNumber = num;
   }
   public int Year
   {
      set
      {
         if(value < EARLIEST_YEAR)
         {
            year = value;
            loanAmount = 0;
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
    
   public new int LoanNumber //override LoanNumber with the new keyword
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
