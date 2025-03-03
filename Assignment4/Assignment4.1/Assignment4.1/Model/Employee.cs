

namespace Assignment4._1.Model
{
     public class Employee
    {
        public String Name { get; set; }
        public double Salary{get; set;}       

        public Employee(String name, double salary)
        {
            Name = name;
            Salary = salary;
        }


        public virtual void displayDetails()
        {
            Console.WriteLine($"Name of the Employee {Name}");
            Console.WriteLine($"salary of the Employee {Salary}");

        }

    }
}
