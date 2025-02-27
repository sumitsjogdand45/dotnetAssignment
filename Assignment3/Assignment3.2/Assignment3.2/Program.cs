namespace Assignment3._2
{
    public class Class1
    {
        public int carID { get; set; }
        public string brand { get; set; }
        public string model { get; set; }
        public int year { get; set; }
        public double price { get; set; }


        public Class1(int carID, string brand, string model, int year, double price)
        {
            this.carID = carID;
            this.brand = brand;
            this.model = model;
            this.year = year;
            this.price = price;
        }

        public void displayCar()
        {
            Console.WriteLine($"car id is{carID}");
            Console.WriteLine($"brand of car {brand}");
            Console.WriteLine($"model of car {model}");
            Console.WriteLine($"year of car Manufacturing {year}");
            Console.WriteLine($"price of car {price}");
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Class1 c1 = new Class1(101, "TATA", "Tiago", 2019, 1000000);
            c1.displayCar();
        }
    }



}
