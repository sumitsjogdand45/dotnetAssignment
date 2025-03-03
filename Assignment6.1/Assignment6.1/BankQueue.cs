using System;

namespace Assignment6._1
{
    internal class BankQueue
    {
        Queue<string> queue;

        public BankQueue()
        {
            queue = new Queue<string>();
        }

        public void AddCustomer(string customerName)
        {
            queue.Enqueue(customerName);
            Console.WriteLine($"{customerName} is taking a token.");
        }
        public void ServeCustomer()
        {
            if (queue.Count > 0)
            {
                string servedCustomer = queue.Dequeue();
                Console.WriteLine($"Serving customer: {servedCustomer}");
            }
            else
            {
                Console.WriteLine("No customers in the line");
            }

        }
        public void CheckNext()
        {
            if (queue.Count > 0)
            {
                Console.WriteLine($"The next customer is: {queue.Peek()}");
            }
            else
            {
                Console.WriteLine("No customers in the line.");
            }
        }
        public bool IsEmpty()
        {
            return queue.Count == 0;
        }
    }
}
