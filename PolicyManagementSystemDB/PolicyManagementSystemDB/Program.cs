using PolicyManagementSystem.constants;
using PolicyManagementSystem.Model;
using PolicyManagementSystem.Repository;

namespace PolicyManagementSystemDB
{
    internal class Program
    {

        static void Main(string[] args)
        {
            IpolicyRepository repository = new PolicyRepository();
            while (true)
            {
                Console.WriteLine("==================================================");
                Console.WriteLine("WELCOME TO 'GHEUN_TAK' POLICY MANAGEMENT SYSTEM");
                Console.WriteLine("==================================================");
                Console.WriteLine("1.Add New Policy");
                Console.WriteLine("2.Update Policy");
                Console.WriteLine("3.Delete Policy");
                Console.WriteLine("4.Search Policy by ID: ");
                Console.WriteLine("5.View All Policies");
                Console.WriteLine("6.View Active Policies");
                Console.WriteLine("7.Exit");
                Console.WriteLine();
                Console.WriteLine("Please Enter your Choice:");


                int option = int.Parse(Console.ReadLine());

                try
                {

                    switch (option)
                    {
                        case 1:

                            Console.WriteLine("Enter Policy Holder Name: ");
                            string name = Console.ReadLine();

                            Console.WriteLine("Enter Policy Type(Life_Insurance, Health_Insurance , Vehicle_Insurance, Property_Insurance : )");
                            PolicyType type = (PolicyType)Enum.Parse(typeof(PolicyType), Console.ReadLine(), true);
                            Console.WriteLine("Wow Great Choice!!!");

                            Console.WriteLine("Your Start Date (yyyy-mm-dd) is: ");
                            DateTime start = DateTime.Now;

                            Console.WriteLine("Enter the End Date (yyyy-mm-dd): ");
                            DateTime end = DateTime.Parse(Console.ReadLine());

                            repository.AddNewPolicy(new Policy()
                            {
                                HolderName = name,
                                Type = type,
                                StartDate = start,
                                EndDate = end
                            });
                            break;

                        case 2:
                            // Console.Write("Enter Policy ID: ");
                            // int updateId = int.Parse(Console.ReadLine());

                            // Console.Write("Enter New Policy Holder Name: ");
                            // string newName = Console.ReadLine();

                            // Console.Write("Enter New Policy Type: ");
                            // PolicyType newType = (PolicyType)Enum.Parse(typeof(PolicyType), Console.ReadLine(), true);

                            //// Console.Write("Enter Start Date: ");
                            //// DateTime newStart = DateTime.Parse(Console.ReadLine());

                            // Console.Write("Enter End Date: ");
                            // DateTime newEnd = DateTime.Parse(Console.ReadLine());
                            Console.WriteLine("Enter Policy ID: ");
                            if(!int.TryParse(Console.ReadLine(),out int updateId))
                            {
                                Console.WriteLine("Invalid Policy ID !!!! Please try again");
                                break;
                            }

                            repository.UpdatePolicy(updateId );

                            break;

                        case 3:
                            Console.Write("Enter Policy ID to Delete: ");
                            int deleteId = int.Parse(Console.ReadLine());

                            repository.DeletePolicy(deleteId);
                            break;


                        case 4:
                            Console.WriteLine("Enter Policy ID: ");
                            int searchId = int.Parse(Console.ReadLine());

                            repository.SearchPolicyById(searchId);
                            break;

                        case 5:
                            List<Policy>policies=repository.ViewAllPolicy();
                            foreach (var item in policies)
                            {
                                Console.WriteLine(item);
                            }
                            break;

                        case 6:
                            repository.ViewActivePolicies();
                            break;

                        case 7:
                            return;

                        default:
                            Console.WriteLine("Invalid input! please Try again!");
                            break;
                    }
                }

                catch (ApplicationException ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }

            }
        }
    }
}
