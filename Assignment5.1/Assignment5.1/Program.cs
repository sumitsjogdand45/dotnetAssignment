using System.Security.Cryptography.X509Certificates;
using Assignment5._1.Model;

namespace Assignment5._1
{
    public class Program
    {
      
        static void Main(string[] args)
        {
            TwoWheeler tw = new TwoWheeler(1000);
            FourWheeler fw = new FourWheeler(2000);
            Commercial cm = new Commercial(1230);

            Console.WriteLine($"vehicle is {tw.Vtype} premium is {tw.PremiumCalcualtion()}");
            Console.WriteLine($"vehicle is {fw.Vtype} premium is { fw.PremiumCalcualtion()}");
            Console.WriteLine($"vehicle is {cm.Vtype} premium is {cm.PremiumCalcualtion()}");
            
        }
    }
}
