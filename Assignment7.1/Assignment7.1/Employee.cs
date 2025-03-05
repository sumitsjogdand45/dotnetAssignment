using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment7._1
{
   

    internal class Employee
    {
        public string Name { get; set; }
        public int ID {  get; set; }
        public DateTime JoiningDate { get; set; }
        

        public Employee(string name,int id,DateTime date) 
        {
            Name = name;
            ID = id;
            JoiningDate= date;
        }
    }
}
