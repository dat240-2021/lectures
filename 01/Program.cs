using System;
using University;

namespace _01
{
    class Program
    {
        static void Main(string[] args)
        {
            var p = new Person();
            p.FirstName = "Fancy";
            p.LastName = "Longpants";

            Console.WriteLine(p);
        }
    }
}
namespace University {
    class Person {
        public string FirstName; 
        public string LastName;

        public override string ToString()
        {
            return FirstName + " " + LastName;
        }
    }
}