namespace Assignment3
{
    //3.1
    class Car
    {
        int carID;
        String Brand;
        String model;
        int year;
        double price;

        public void ReceiveInfo()
        {
            Console.WriteLine("please enter carID");
            carID = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("please enter Brand");
            Brand = Convert.ToString(Console.ReadLine());

            Console.WriteLine("please enter Model");
            model = Convert.ToString(Console.ReadLine());

            Console.WriteLine("please enter Year");
            year = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("please enter price of the car");
            price = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Received Car Information");

        }

        public void DisplayCarinfo()
        {
            Console.WriteLine("presenting Car Information");

            Console.WriteLine("Car-id of the car" + carID);

            Console.WriteLine("brand of the car " + Brand);

            Console.WriteLine("Model of the car " + model);

            Console.WriteLine("Year of Manufacturing" + year);

            Console.WriteLine("Price of the Car" + price);

        }
        internal class Program
        {
            static void Main(string[] args)
            {
                // Car car=new Car();

                Car car = new Car();
                car.ReceiveInfo();
                car.DisplayCarinfo();
            }
        }
    }

}
