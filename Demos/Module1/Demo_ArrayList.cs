/* 
 
Arrays vs. ArrayList
 
1) Arrays are strongly-typed collections of the same data type and have a fixed length that 
cannot be changed during runtime. 
2) An Array list is not a strongly-typed collection. It can store the values of different 
data types or same datatype. The size of an array list increases or decreases dynamically so 
it can take any size of values from any data type.

*/

using System;
using static System.Console;
using System.Collections;
using System.Collections.Generic;


public class SamplesArrayList
{
    public static void Main()
    {

        //=========Demo 1: Basic ArrayList==============
        ArrayList myAL = new ArrayList();
        myAL.Add("Hello");
        myAL.Add(1);
        myAL.Add(10.5);
        myAL.Add(true);

        // Displays the properties and values of the ArrayList.
        // Here's an analogy: Think of the ArrayList as a box (Capacity) where you can put items (Count).
        // The Count is how many items are currently in the box, while the Capacity is the size of the box.
        // If the box gets full (Count equals Capacity), and you try to add another item,
        // you'd need a bigger box (Capacity increases).
        WriteLine("myAL");
        WriteLine("    Count:    {0}", myAL.Count);
        WriteLine("    Capacity: {0}", myAL.Capacity);
        Write("    Values:");
        PrintValues(myAL);

        //=========Demo 2: A demo that show the differences between .count and .capacity=========
        ArrayList demoAL = new ArrayList();

        // Adding 5 elements to the ArrayList
        demoAL.Add("Item 1");
        demoAL.Add("Item 2");
        demoAL.Add("Item 3");
        demoAL.Add("Item 4");
        demoAL.Add("Item 5");

        // After adding 5 elements
        WriteLine("Count after adding 5 elements: {0}", demoAL.Count); // Count is 5
        WriteLine("Capacity after adding 5 elements: {0}", demoAL.Capacity); // Capacity might be more than 5, depending on how ArrayList increases its capacity

        // Adding another element to potentially increase the capacity
        demoAL.Add("Item 6");
        demoAL.Add("Item 7");
        demoAL.Add("Item 8");
        demoAL.Add("Item 9");

        // After adding the 6th element, which might trigger an increase in capacity
        WriteLine("Count after adding 6 elements: {0}", demoAL.Count); // Count is 6
        WriteLine("Capacity after adding 6 elements: {0}", demoAL.Capacity); // Capacity is likely increased from the initial value to accommodate more elements

        // Insert at a specific index
        myAL.Insert(2, "Inserted Item");

        // Remove elements
        myAL.Remove(1);   // Removes first occurrence of 1
        myAL.RemoveAt(0); // Removes "Hello"
        //ArrayList can't do RemoveAll (we have to use the generic list)


        // Check if an element exists
        if (myAL.Contains(true))
        {
            WriteLine("ArrayList contains 'true'");
        }

        // Iterate through the ArrayList
        WriteLine("\nArrayList contents:");
        foreach (var item in myAL)
        {
            Write(item + " | ");
        }

        // Convert ArrayList to an Object Array
        object[] objArray = myAL.ToArray();
        WriteLine("\nConverted ArrayList to Object Array.");

        // Get the total count of elements
        WriteLine($"Total elements in ArrayList: {myAL.Count}");


        //=========Demo 3: Generic List, which is recommended for dynamic arrays with the same data type.=========
        //Advantages of List

        //Resizes automatically when adding/ removing elements.
        //Strongly typed.
        //No boxing/ unboxing for value types.

        //  Create a List of integers
        List<int> numbers = new List<int> { 10, 20, 30, 40, 50, 10 };

        //  Add elements dynamically
        numbers.Add(60);
        numbers.AddRange(new int[] { 70, 80, 90,100,100 });

        //  Insert at a specific index
        numbers.Insert(2, 25); // Inserts 25 at index 2

        //  Remove elements
        numbers.Remove(30);  // Removes first occurrence of 30
        numbers.RemoveAt(0); // Removes element at index 0
        numbers.RemoveRange(3, 2); // Removes 2 elements starting at index 3
        numbers.RemoveAll(x => x == 100); //LINQ language! :)

        //  Check if a number exists
        if (numbers.Contains(50))
        {
            WriteLine("50 is in the list.");
        }

        //  Find an element
        int foundNumber = numbers.Find(x => x > 50); // Finds the first number > 50
            WriteLine($"First number greater than 50: {foundNumber}");

        //  Sort the list
        numbers.Sort();

        //  Iterate through the list
        WriteLine("List contents:");
        foreach (int num in numbers)
        {
            Write(num + " ");
        }

        //  Convert to an array
        int[] numberArray = numbers.ToArray();

        //  Get the count of elements
        WriteLine($"\nTotal elements in list: {numbers.Count}");


    }

    public static void PrintValues(IEnumerable myList)
    {
        //Treat each item simply as an object.
        foreach (Object obj in myList)
            Write("   {0}", obj);
        WriteLine();
    }
}