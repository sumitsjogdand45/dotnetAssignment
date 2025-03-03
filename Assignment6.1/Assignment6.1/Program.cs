namespace Assignment6._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BankQueue bankQueue = new BankQueue();

            
            bankQueue.AddCustomer("Somnath");
            bankQueue.AddCustomer("Govind");
            bankQueue.AddCustomer("Prasad");

            
            bankQueue.CheckNext();  //to check for next one

            // Serving customers
            bankQueue.ServeCustomer();
            bankQueue.ServeCustomer();

            bankQueue.CheckNext(); //checking who will be the next
             
            bankQueue.ServeCustomer();
            bankQueue.ServeCustomer();  
        }
    
    }
}
