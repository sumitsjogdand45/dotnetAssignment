using System;

namespace Assignment5._1
{
    public abstract class VehiclesInsurances
    {
        public string Vtype { get; set; }
        public double InsuranceAmount { get; set; }

        public VehiclesInsurances(string vtype, double insuranceAmount)
        {
            Vtype = vtype;
            InsuranceAmount = insuranceAmount;

        }

        public abstract double PremiumCalcualtion();

        public void DispalyDetails()
        {
            Console.WriteLine($"type of  vehicle is{Vtype}");
            Console.WriteLine($"insurance amount of  vehicle is{InsuranceAmount}");
            Console.WriteLine($"Premium cost of  vehicle is{PremiumCalcualtion()}");
        }

    }
}
