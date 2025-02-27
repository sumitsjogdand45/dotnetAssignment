namespace Assignment2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Question 1.
            /*  Console.WriteLine("Enter Your Salary");
              double basicSal = Convert.ToDouble(Console.ReadLine());
              double tax = basicSal*0.10;
              Console.WriteLine("Enter Your rating");
              int rating=Convert.ToInt32(Console.ReadLine());
              double Bonus = 0;
              if (rating >= 8)
              {
                   Bonus = basicSal * 0.20;
              }
              else if(rating >= 5) 
              {
                      Bonus = basicSal * 0.10;
              }  
              else if (rating<5)
              {
                  Console.WriteLine("No bonus");   
              }

              double totalsal=basicSal-tax+Bonus;

              Console.WriteLine($"salary is {basicSal}");
              Console.WriteLine($"bonus applied with salary {Bonus}");
              Console.WriteLine($"tax deduction from salary {tax}");
              Console.WriteLine($"Total salary {totalsal}");*/


            // Question 2.

            //double General = 200;
            //double sleeper = 500;
            //double AC = 1000;


            //Console.WriteLine("Welcome to confirm Ticket Booking");
            //int ticketType = 0;

            //do
            //{
            //    Console.WriteLine("1.General\n2.AC\n3.Sleeper\n4.exit");
            //    Console.WriteLine("Enter the ticket type");
            //    ticketType = Convert.ToInt32(Console.ReadLine());

            //    if (ticketType == 4)
            //    {
            //        break;
            //    }

            //    Console.WriteLine("Enter the no. of tickets to Book");
            //    int totalTickets = Convert.ToInt32(Console.ReadLine());

            //    double totalAmount = 0;

            //    switch (ticketType)
            //    {
            //        case 1:
            //            totalAmount = totalTickets * General;
            //            break;
            //        case 2:
            //            totalAmount = totalTickets * AC;
            //            break;
            //        case 3:
            //            totalAmount = totalTickets * sleeper;
            //            break;
            //        default:
            //            Console.WriteLine("invalid user input please enter the correct input");
            //            continue;

            //    }



            //    Console.WriteLine($"type={ticketType}");
            //    Console.WriteLine($"total number of tickets={totalTickets}");
            //    Console.WriteLine($"total amount of your tickets={totalAmount}");
            //    Console.WriteLine("Thank you for choosing NeoSOFT Railway Reservations");

            //    Console.WriteLine("Do You want to book more tickets then choos the correct option to continue or press 4 for exit");



            //}
            //while (ticketType != 4);






            // Question 3.

            double[,] users = {

                {101, 500.10 },
                {102,100.20 },
                {103,345.5 },
                {104,432.5 },
                {105,876.9 }
            };

            bool userId=true;
            int realUser;

            Console.WriteLine("Welcome to Neosoft Shopping");

             
            
            while (userId) 
            {
                Console.WriteLine("Enter real user id");
                realUser =Convert.ToInt32( Console.ReadLine());

                for ( int i = 0; i < users.GetLength(0); i++)
                {
                    if (users[i,0]==realUser)
                    {
                        userId = false;
                        Console.WriteLine($"Wallet Balance:{users[i,1]}");
                        break;
                    }
                }
                if (userId)
                {
                   
                    Console.WriteLine("Invalid user ID please try again!!!");
                     
                }
            }




        }
    }
}
