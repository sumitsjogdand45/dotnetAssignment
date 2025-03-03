using System;
 namespace Assignment5._1.Model
{
    internal class FourWheeler:VehiclesInsurances
    {
        public FourWheeler(double InsuranceAmount):base("four-wheeler",InsuranceAmount) { }

        public override double PremiumCalcualtion()
        {
            return InsuranceAmount * 0.09;
        }
    }
}
