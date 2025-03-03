namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<long> Accounts = new List<long> {};
            Accounts.Add(111000);
            Accounts.Add(222000);
;           Accounts.Add(333000);
            Accounts.Add(444000);

            try
            {
                Console.WriteLine("Enter your A/C number");
                long AccNum = Convert.ToInt64(Console.ReadLine());
                if (!Accounts.Contains(AccNum))
                {
                    throw new Exception("This Account Number doesn't exist!");
                }
                Console.WriteLine("This Account Number is Valid!");
            }
            catch (FormatException)
            {
                Console.WriteLine("Incorrect input! Please enter numeric data only");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Transaction is Completed.");
            }
        }
    }
}
