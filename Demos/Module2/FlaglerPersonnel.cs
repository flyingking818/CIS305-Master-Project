using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

/*
An interface in C# is like a contract that defines a set of methods and properties that a class must implement. 
It provides a way to enforce consistent behavior across different classes without dictating how the behavior should be implemented.

An interface is a reference type in C#.
It cannot have any implementation (no method bodies, only method signatures).
A class must implement all members of an interface it adopts.
Multiple interfaces can be implemented by a single class (unlike inheritance, which allows only one base class).
*/



namespace CIS305_Master_Project.Demos.Module2
{
    internal class FlaglerPersonnel
    {
        public static void Main() {
            //Person aPerson = new Person(); NOT valid, Person is abstract!
            Professor prof = new Professor("Jeremy Wang", 25, "Math & Technology");
            prof.DisplayRole();

            //Option 1- Let's the interface call explicitly! Recommended!
            ITeachable t = prof;
            t.Teach();

            //Alternative - interface casting (similar to data type casting)
            ((ITeachable)prof).Teach();

            //Option 2 - Normal method call
            prof.Learn();

            //Let's work a student object
            Student flaglerStudent = new Student("Stacy", 22, "CIS");
            flaglerStudent.DisplayRole();
            ((ITeachable)flaglerStudent).Teach();
            flaglerStudent.Learn();

            //Let's work a staff object
            Staff staffMember = new Staff("Will Jackson", 45, "IT Director");
            staffMember.DisplayRole();
            ((IAdministratable)staffMember).Administrate();

        }

    }

    //Add Interfaces after the implementation class (some do this at the end)
    //Think of this as the bulletin board.
    public interface ITeachable {
        void Teach();
    }

    public interface ILearnable
    {
        void Learn();
    }

    public interface IAdministratable {
        void Administrate();
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
                if(value>=MIN_AGE && value <= MAX_AGE)  //value represents the input value
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

    //We need establish the inherent betwen subclasses and the Person base class
    //Inherence is about identity relationship!!!
    public class Professor : Person, ITeachable, ILearnable
    {
        public string Department { get; set; }

        //Custom constructor that calls the parent constructor, but add our own.
        public Professor(string name, int age, string department):base (name,age)
        {
            //Name and Age are managed by the parent class
            Department=department; //This is managed by the subclass
            //A private field with anonymous name (random) is generated. we don't care!
        }

        //Virtual (parent) -> override (child)
        public override void DisplayRole()
        {
            WriteLine($"{Name} is a professor (age: {Age.ToString()}) from {Department} at Flagler!");
        }

        //Do the interfaces after all custom methods
        //Option 1 - explicit interfaces!
        //1) Avoid name conflicts
        //2) Hide your interface from the public API
        //3) Force interface based usage! (requires specific interface declaration)

        void ITeachable.Teach()
        {
            WriteLine($"{Name} is teaching {Department} courses.");  //enhance!
        }

        //Option 2 - Normal method.
        public void Learn()
        {
            WriteLine($"{Name} is learning agentic AI now!");
        }

    }


    public class Student:Person, ITeachable, ILearnable
    {
        public string Major {  get; set; }

        public Student (string name, int age, string major) : base (name,age) { 
            Major = major;        
        }

        public override void DisplayRole()
        {
            WriteLine($"{Name} is a student (age: {Age.ToString()}) with {Major} at Flagler!");
        }

        //Student interface methods
        void ITeachable.Teach()
        {
            WriteLine($"{Name} is a TA for {Major} courses.");  //enhance!
        }

        //Option 2 - Normal method.
        public void Learn()
        {
            WriteLine($"{Name} is learning {Major} subjects!");
        }


    }

    public class Staff : Person, IAdministratable
    {
        public string Position { get; set; }

        public Staff(string name, int age, string position) : base(name, age)
        {
            Position = position;
        }

        public override void DisplayRole()
        {
            WriteLine($"{Name} (age: {Age.ToString()}) works as a {Position} at Flagler!");
        }

        void IAdministratable.Administrate()
        {       
            WriteLine($"{Name} is a {Position} serving Flagler!");  //enhance!
        }
    }

}
