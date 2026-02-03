using System;
using static System.Console;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CIS305_Master_Project.Demos.Module1
{
    internal class CoffeeSales
    {
        static void Main()
        {
            const int DAYS = 5;
            const int SIZES = 3;

            int[,] coffeeSales = new int[DAYS, SIZES];

            //Call the methods
            FillArray(coffeeSales);
            DisplayTable(coffeeSales);
            DisplayDailyTotals(coffeeSales);
            DisplaySizeTotals(coffeeSales);
        }

        public static void FillArray(int[,] data)
        {
            Random rand = new Random();

            //loop through the table! :)  
            //Preferred => Row -> column

            //Outer loop - looping through 5 days
            for (int row = 0; row < data.GetLength(0); row++)
            {
                //inner loop - looping through 3 sizes
                for (int col = 0; col < data.GetLength(1); col++)
                {
                    //Next method => [lower, upper)
                    data[row, col] = rand.Next(20, 101);
                    
                }

            }
        }

        public static void DisplayTable(int[,] data) 
        {
            WriteLine("Coffee Sales Report");
            WriteLine("{0,12}{1,12}{2,12}{3,12}", "Day", "Small", "Medium", "Large");

            //Generate the Table for display. 
            //Nested loops to go thorugh rows and columns.
            for (int row = 0; row < data.GetLength(0); row++)
            {
                //inner loop - looping through 3 sizes
                Write("{0,12}", $"Day {row + 1}");
                for (int col = 0; col < data.GetLength(1); col++)
                {
                    //Show the 2D elements
                    Write("{0,12}", data[row, col]);
                }
                WriteLine(); //Move a new line.

            }

        }

        public static void DisplayDailyTotals(int[,] data) {

            WriteLine("\nTotal Cups Sold Per Day");

            for (int row = 0; row < data.GetLength(0); row++)
            {
                int total = 0;  //restart the total for each row.

                for (int col = 0; col < data.GetLength(1); col++)
                {
                    total += data[row, col]; //Here, we need add up the daily sales.
                }

                WriteLine("Day {0}: {1}", row + 1, total);
            }

        }

        public static void DisplaySizeTotals(int[,] data)
        {
            WriteLine("\nTotal Cups Sold Per Size");

            string[] sizes = { "Small", "Medium", "Large" };

            for (int col = 0; col < data.GetLength(1); col++)
            {
                int total = 0;

                for (int row = 0; row < data.GetLength(0); row++)
                {
                    total += data[row, col];
                }

                WriteLine("{0}: {1}", sizes[col], total);
            }
        }







    }
}
