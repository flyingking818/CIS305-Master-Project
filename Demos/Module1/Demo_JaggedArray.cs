/* 
 When the number of columns in the rows must differ, a jagged, or ragged array, 
 can be created. Jagged arrays differ from rectangular arrays in that rectangular arrays 
always have a rectangular shape, like a table. Jagged arrays are called “arrays of arrays."
*/


using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace CIS_305_Master_Project.Demo.Module1
{
    class Demo_JaggedArray
    {
        public static void Main()
        {
            //Row number is set to 4. However, the column length varies! :)
            int[][] anArray = new int[4][]; 
            anArray[0] = new int[] { 100, 200 }; 
            anArray[1] = new int[] { 11, 22, 37 }; 
            anArray[2] = new int[] { 16, 72, 83, 99, 106, 42, 87 }; 
            anArray[3] = new int[] { 1, 2, 3, 4 };

            //How many rows?
            WriteLine(anArray.Length);  //Note that method Length returns the number of arrays
                                        //contained in the jagged array. NOT the total number of elements!!!
            WriteLine(anArray.GetLength(0));

            //How many columns in the 3rd row?
            WriteLine(anArray[2].Length);
            WriteLine(anArray[2].GetLength(0));

            //What's the upper bound index number?
            WriteLine(anArray.GetUpperBound(0));


        }
    }
}
