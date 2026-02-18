using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace CIS305_Master_Project.Demos.Module2
{
    internal class FlaglerPersonnel
    {
        public static void Main() { 

        }

    }

    public abstract class Person
    {
        //Constants
        const int MIN_AGE = 17;
        const int MAX_AGE = 130;

        // public int Id { get; } //Readonly property
        public string Name { get; set; }
        //public int Age { get; set; }

        //We want do some validation of the Age Property
        //17<=Age<=130
        private int _age;  //underscore indicates private!
        public int Age
        {
            get 
            { 
                return _age; 
            }
            set
            {
                if(_age>=MIN_AGE && _age <= MAX_AGE)
                {
                    _age = value;
                }
                else
                {
                    throw new ArgumentException("Please enter valid age!");
                }
            }
        }

        //Custom constructor to take in 2 parameters. 

        //After class, create another custom constructor with 3 parameters.
        //This is an example of overloaded methods
        public Person(string name, int age) { 
            Name = name;
            Age = age;        
        }

        //One method to show the role of the person

        //Virtual - we need a method in our sub classes to override this method.
        public virtual void DisplayRole()
        {
            WriteLine($"{Name} is a person at Flagler!");
        }

    }
}
