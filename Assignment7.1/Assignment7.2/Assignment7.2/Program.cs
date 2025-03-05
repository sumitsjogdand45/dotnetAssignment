namespace Assignment7._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Product> products = new List<Product>
        {
            new Product { ProductID = 1, Name = "Smartphone", Category = "Electronics", Price = 15000 },
            new Product { ProductID = 2, Name = "Laptop", Category = "Electronics", Price = 50000 },
            new Product { ProductID = 3, Name = "Headphones", Category = "Electronics", Price = 1200 },
            new Product { ProductID = 4, Name = "Charger", Category = "Electronics", Price = 800 },
            new Product { ProductID = 5, Name = "Washing Machine", Category = "Home Appliance", Price = 20000 }
        };

             
            var result = from product in products
                         where product.Category == "Electronics" && product.Price > 1000
                         select product;

            var HighrestValueProduct= products.MaxBy(x => x.Price);
            Console.WriteLine($"id:{HighrestValueProduct.ProductID}\t name:{HighrestValueProduct.Name}\t price{HighrestValueProduct.Price}");

            foreach (var product in result)
            {
                Console.WriteLine($"ProductID: {product.ProductID}, Name: {product.Name}, Price: Rs{product.Price}");
            }
        }
    }
}
