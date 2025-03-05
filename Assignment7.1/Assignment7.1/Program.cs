using System;

namespace Assignment7._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee emp = new Employee("sumit", 101, new DateTime(2019, 5, 12));
            int experience = emp.CalculateExperice();

            Console.WriteLine($"Experience:{experience}");

        }
    }
}
