using static System.Console;
class BorderDemo
{

    static void Main()
    {
        /*
         Overloading
            Involves the ability to write multiple versions of a method using the same method name
         When you overload a C# method:
            You write multiple methods with the same name but different parameter lists
            The method’s name and parameter list is called the method’s signature
         Methods are overloaded correctly when they have the same identifier but different parameter lists
        */
        DisplayWithBorder("Ed");
        DisplayWithBorder(3);
        DisplayWithBorder(456);
        DisplayWithBorder(897654);
        DisplayWithBorder("Veronica");
    }
    private static void DisplayWithBorder(string word)
    {

        const int EXTRA_STARS = 4;
        const string SYMBOL = "*";
        int size = word.Length + EXTRA_STARS;
        int x;
        for (x = 0; x < size; ++x)
            Write(SYMBOL);
        WriteLine();
        WriteLine(SYMBOL + " " + word + " " + SYMBOL);
        for (x = 0; x < size; ++x)
            Write(SYMBOL);
        WriteLine("\n\n");
    }
    private static void DisplayWithBorder(int number)
    {

        const int EXTRA_STARS = 4;
        const string SYMBOL = "*";
        int size = EXTRA_STARS + 1;
        int leftOver = number;
        int x;
        //Anyone sees what is being done here?
        while (leftOver >= 10)
        {
            leftOver = leftOver / 10;
            ++size;
        }

        //This is better.
        //size = EXTRA_STARS + number.ToString().Length;

        for (x = 0; x < size; ++x)
            Write(SYMBOL);
        WriteLine();
        WriteLine(SYMBOL + " " + number + " " + SYMBOL);
        for (x = 0; x < size; ++x)
            Write(SYMBOL);
        WriteLine("\n\n");
    }
}