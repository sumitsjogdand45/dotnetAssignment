using System;
 namespace Assignment5._1.Model
{
    internal class Commercial:VehiclesInsurances
    {
        public Commercial(double InsuranceAmount) :base("commercial", InsuranceAmount) { }

        public override double PremiumCalcualtion()
        {
            return InsuranceAmount ;
        }
    }
}
