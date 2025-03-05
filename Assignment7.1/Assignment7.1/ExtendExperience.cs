using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment7._1
{
    static  class ExtendExperience
    {
       
        public static int  CalculateExperice(this Employee employee) 
        {
            int CurrYear = DateTime.Now.Year;
            int joiningYear = employee.JoiningDate.Year;

            return CurrYear - joiningYear;
        }
    }
}
