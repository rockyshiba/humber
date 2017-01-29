using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IntroClasses.Models
{
    public class Person
    {
        //Properties
        private string _name;
        private int _age;
        private bool _alive = true;

        //Constructor 
        public Person(string name) //a new instance will require a name arugment
        {
            _name = name;
        }

        //Fields
        public string Name
        {
            get { return _name; } 
            set { _name = value; } //person.Name = "Steve";
        }

        public int Age
        {
            get { return _age; } 
            set { _age = value; } //person.Age = 15;
        }

        public bool Alive
        {
            get { return _alive; }
            set { if (value || !value) { _alive = value; } } //if value is true or false
        }

        //Methods
        public string Hello()
        {
            return "Hello";
        }

        public string Hello(string name) //overloaded method
        {
            return "Hello " + name;
        }

        public string isAlive()
        {
            if (this._alive)
            {
                return this._name + " is alive";
            }
            else
            {
                return this._name + " is not alive";
            }
        }
    }

    public class Student : Person //This Student class will inherit everything in the Person class
    {
        private string _number;

        //Person, the base class, had a constructor so Student needs one as well
        public Student(string name) : base(name) //Constructors aren't automatically inherited, they need to be redeclared
        {
            Name = name;
        }

        public string Number
        {
            get { return _number; }
            set { _number = value; }
        }
    }

}