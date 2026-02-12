/*
 
Mandatory Parameter
    An argument for it is required in every method call
Types of mandatory parameters:
    1) Value parameters, when they are declared without default values
    2) Reference parameters
        Declared with the ref modifier
    3) Output parameters
        Declared with the out modifier
    4) Parameter arrays (DSS)
        Declared with the params modifier
Please note:
    1) Arrays are ref types (which can be changed in a method).
    2) Reference parameters, output parameters, and parameter arrays do not occupy their own memory locations
        Rather, they act as aliases for the same memory location occupied by the values passed to them

*/



using System;
using static System.Console;
class ParameterTypes
{
   static void Main()
   {
        //===========1. Value parameter demo==========
        int x = 4;
        WriteLine("======1. Value parameter demo=====");
        WriteLine("In main, x is {0}", x);

        //When a value is passed by value, the method receives a copy of the value and cannot alter the original.
        DisplayValueParameter(x);
        WriteLine("In main, x is {0}", x);

        //===========2. Reference parameter demo===========
        int y = 4;
        WriteLine("======2. Reference parameter demo=====");
        WriteLine("In main, y is {0}", y);

        //When a value is passed by reference, the method receives the memory address and can alter the original
        DisplayReferenceParameter(ref y);
        WriteLine("In main, y is {0}", y);

        //===========3. out parameters demo==========
        int first, second;

        /* Major differences between references parameters and out parameters
           1) Reference parameters need to contain a value before calling the method
           2) Output parameters do not need to contain a value
        */

        //Declared with the out modifier
        WriteLine("======3. out parameters demo=====");
        InputMethod(out first, out second);

        WriteLine("After InputMethod first is {0}", first);
        WriteLine("and second is {0}", second);

        //Use the TryParse() method
        string entryString;
        int score;
        Write("Enter your test score >> ");
        entryString = ReadLine();           

        while (!int.TryParse(entryString, out score))
        {
            WriteLine("Please enter a numeric value!!!!");
            entryString = ReadLine();
        }
        WriteLine("You entered {0}", score);

        //===========4. Params parameter demo=============
        /* 
           1) A local array declared within the method header by using the keyword params
           2) Used when you don�t know how many arguments of the same type you might eventually send to a method
           3) No additional parameters are permitted after the params keyword

        When a method header uses the params keyword, two restrictions apply:
            1) Only one params keyword is permitted in a method declaration
            2) If a method declares multiple parameters, the params�qualified parameter must be the last one in the list
        */

        
        WriteLine("======4. Params parameter demo=====");
        double[] array = { 3, 4, 5, 6, 7, 8 };       
        Average(3);
        Average(12, 15);
        Average(22.3, 44.5, 88.1);
        Average(array);

    }

    private static void DisplayValueParameter(int x)  //Signature
    {
        x = 777;
        WriteLine("In method, x is {0}", x);
    }

    private static void DisplayReferenceParameter(ref int number)
    {
        number = 888;
        WriteLine("In method, y is {0}", number);
    }

    private static void InputMethod(out int one, out int two) //notice the out keyword, 
    {
        string s1, s2;
        Write("Enter first integer ");
        s1 = ReadLine();
        Write("Enter second integer ");
        s2 = ReadLine();
        one = Convert.ToInt32(s1);  //1, 2, 4 if user enters "one"   int.TryParse (out number)
        two = Convert.ToInt32(s2);
    }

    public static void Average(params double[] nums)// Convert to an array automatically
    {
        double total = 0;
        double avg;
        foreach (double number in nums)
        {
            Write("{0} ", number);
            total += number;
        }
        avg = total / nums.Length;
        WriteLine(" -- Average is {0}", avg);
    }
}