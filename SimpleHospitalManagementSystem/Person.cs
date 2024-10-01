using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleHospitalManagementSystem
{
    public enum Gender { Male, Female }
    public class Person
    {
        //Attributes
        public string Name{get;private set;}
        public int Age { get; private set; }
        public Gender GenderType { get; private set; }
        public string Password { get; set; } // New attribute for login

        //Constructor: Initialize the attributes above.
        public Person(string Name,int Age, Gender GenderType, string Password) 
        { 
            this.Name = Name;
            this.Age = Age;
            this.GenderType = GenderType;
            this.Password = Password;
        }
        
        //Method: DisplayInfo() to print the person’s details.
        public virtual void DisplayInfo()
        {
            Console.WriteLine($"Name: {Name} \t age: {Age} \t Gender: {GenderType} ");
        }
    }
}
