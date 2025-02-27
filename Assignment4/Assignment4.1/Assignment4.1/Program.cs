using Assignment4._1.Model;

namespace Assignment4._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Manager pgm = new Manager("sumit", 100000.344, 1234.34);
            
            pgm.displayDetails();
            Employee emp = new Employee("sonu", 43223.32);

            emp.displayDetails();
        }
    }
}
