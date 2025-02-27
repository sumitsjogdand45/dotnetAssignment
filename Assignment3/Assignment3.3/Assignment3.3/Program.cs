namespace Assignment3._3
{
    internal class Program
    {
        static void Main(string[] args)
        {

            String password;
             
           
            do
            {


                Console.WriteLine("Enter Your Password");
                password = Convert.ToString(Console.ReadLine());

                if (password.Length < 6)
                {
                    Console.WriteLine("password contains atleast 6 characters ");
                     
                }
                else if (!isupperCase(password))
                {
                    Console.WriteLine("password must contains one Uppercase letter");
                     
                }
                else if (!isDigit(password))
                {
                    Console.WriteLine("password must contains on digit");
                      
                }
                else
                {
                    Console.WriteLine("You Entered the Correct Password ");
                }
            } while (password.Length < 6 || !isupperCase(password) || !isDigit(password));

        }

        static bool isupperCase(string password)
        {
            return password.Any(char.IsUpper);
        }

        static bool isDigit(string password)
        {
            return password.Any(char.IsDigit);
        }
    }
}
