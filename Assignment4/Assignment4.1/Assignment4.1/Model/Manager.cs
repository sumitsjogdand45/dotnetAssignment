using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4._1.Model
{
    public class Manager:Employee
    {
        public double Bonus {  get; set; }

        public Manager(String Name, double Salary, Double bonus):base(Name,Salary)
        {
            Bonus=bonus;
        }
        public override void displayDetails()
        {
          //  base.displayDetails();
            Console.WriteLine($"bonus is {Bonus}");

        }
    }
}
