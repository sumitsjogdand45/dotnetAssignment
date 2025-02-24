namespace Assignment1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Question 1
            String name;
            int age;
            double percent;

            Console.WriteLine("please enter name :");
            name = Console.ReadLine();
            Console.WriteLine("please enter age :");
            age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("please enter percent :");
            percent = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine($"Name is {name},age is {age},percentage  is {percent}");


            //Question 2

            Console.WriteLine("Enter age");
            bool isAge = true;
            isAge = int.TryParse(Console.ReadLine(), out age);
            if (isAge)
            {
                Console.WriteLine($"age is {age}");
            }
            else
            {
                Console.WriteLine("Bad input");
                isAge = int.TryParse(Console.ReadLine(), out age);
               

            }


            //Question 3

            String email;
            Console.WriteLine("Enter your email");
            email = Console.ReadLine();

            if (email.Length==0)
            {
                Console.WriteLine("this field is required please Enter your Email");
                Console.WriteLine(email);
            }
            else
            {
                Console.WriteLine($"enter your email{email}");
            }


            // Question 4

            String date;
            Console.WriteLine("Enter the discharge date of patient");
            date= Console.ReadLine();
            if (date.Length > 0)
            {
                Console.WriteLine($"date is {date}");
            }
            else
            {
                Console.WriteLine("Not Discharged");
            }

        }
    }
}
