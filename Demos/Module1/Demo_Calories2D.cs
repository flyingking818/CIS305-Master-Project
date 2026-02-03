/*
 Create a 2D array program to calculate the 
    1) daily average calories (e.g., Sun - Sat)
    2) meal type average calories (e.g., breakfast, lunch and dinner)
    3) per meal average calories
*/

//F5 runs project in debugging mode, CTRL+F runs project without debugging.

using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace CIS_305_Master_Project.Demo.Module1
{
    class Calories2D
    {
        public static void Main()
        {
            //======================= Array Exercises==========================
            //Create a 7x3 2D array with values
            int[,] calories =   {
                {900, 750, 1020},
                {300, 1000, 2700},
                {500, 700, 2100},
                {400, 900, 1780},
                {600, 1200, 1100},
                {575, 1150, 1900},
                {600, 1020, 1700}
            };

            //Create an empty 7x3 2D array
            int[,] caloriesEmpty = new int[7, 3];

            //Let's take a look some properties and methods
            //Length property gets total number of elements in all dimensions 
            WriteLine(calories.Length); //nouns are properties, verbs are actions/methods
                                        //Rank property shows the number of dimensions (e.g., 2D? 3D?)
            WriteLine(calories.Rank);

            //GetLength( ) – returns the number of rows or columns, commmonly used for loop processing.
            WriteLine(calories.GetLength(0));   //how many rows?
            WriteLine(calories.GetLength(1));   //how many columns?
            //If you are using .GetLength, i < .GetLength (which is more common)



            //Get upper index number (row or column) - 
            WriteLine(calories.GetUpperBound(0));  // return 6 (upper row index)
            WriteLine(calories.GetUpperBound(1));  // return 2 (upper column index)
                                                   //Quick question - what the result of GetLowerBound(0) and GetLowerBound(1)?
                                                   //If you are using .GetUpperBound, i <= .GetUpperBound (which is less common)

            //Calculate Daily Average
            double[] dailyAverage = CalculateAverageByDay(calories);

            //Calculate Average by Meal
            double[] mealAverage = CalculateAverageByMeal(calories);

            //Display the results
            DisplayDailyAverage(dailyAverage);
            DisplayMealAverage(mealAverage);


            DisplayAverageCaloriesPerMeal(calories);
            ReadKey();

        }

        public static double[] CalculateAverageByDay(int[,] calories)
        {
            int sum = 0;
            double[] dailyAverage = new double[7];  //the new 1D array for daily averages

            for (int r = 0; r < calories.GetLength(0); ++r)
            {
                //Add up the daily calories
                for (int c = 0; c < calories.GetLength(1); ++c)                
                    sum += calories[r, c];
                dailyAverage[r] = (double)sum / calories.GetLength(1);
                //This step is important
                sum = 0;
            }

            return dailyAverage;
        }

        public static double[] CalculateAverageByMeal(int[,] calories)
        {
            int sum = 0;
            double[] mealAverage = new double[3];
            for (int c = 0; c < calories.GetLength(1); ++c)
            {
                for (int r = 0; r < calories.GetLength(0); ++r)
                    sum += calories[r, c];
                mealAverage[c] = (double)sum / calories.GetLength(0);
                sum = 0;
            }
            return mealAverage;
        }

        public static void DisplayDailyAverage(double[] dailyAverage)
        {
            int dayNumber = 1;
            WriteLine("Calorie Counter");
            WriteLine("Daily Averages");
            foreach (double avgCalorie in dailyAverage)
            {
                WriteLine("Day {0}: {1,6:N0}", dayNumber, avgCalorie);
                dayNumber++;
            }
        }

        public static void DisplayMealAverage(double[] mealAverage)
        {
            string[] mealTime = { "Breakfast", "Lunch", "Dinner" };
            WriteLine("\n\nCalorie Counter");
            WriteLine("Meal Averages");
            for (int c = 0; c < mealAverage.Length; c++)
            {

                WriteLine("{0,-10}: {1,6}", mealTime[c], mealAverage[c].ToString("N0"));
            }

        }

        public static void DisplayAverageCaloriesPerMeal(int[,] calories)
        {
            double sum = 0;


            for (int da = 0; da < calories.GetLength(0); da++)
                for (int ml = 0; ml < calories.GetLength(1); ml++)
                    sum += calories[da, ml];
            WriteLine("\nCaloric Average Per Meal: {0:N0}", sum / calories.Length);


            /*or even better with foreach
            foreach (int cal in calories)
                sum += cal;
            WriteLine("\nCaloric Average Per Meal: {0:N0}",
                              sum / calories.Length);
           */
        }
    }

    
}
