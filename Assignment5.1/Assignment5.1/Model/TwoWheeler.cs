using System;

namespace Assignment5._1.Model
{
    internal class TwoWheeler : VehiclesInsurances
    {
        public TwoWheeler(double insuranceAmount):base("two Wheeler", insuranceAmount) { }

        public override double PremiumCalcualtion()
        {
            return InsuranceAmount*;
        }
    }
}
