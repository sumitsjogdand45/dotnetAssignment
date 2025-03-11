using System;
using PolicyManagementSystem.constants;
namespace PolicyManagementSystem.Model
{
    internal class Policy
    {
            private static int idCounter = 1;
        private string? name;
        private DateTime start;
        private DateTime end;

      
            public int PolicyID { get; set; }
            public string HolderName { get; set; }
            public PolicyType Type { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }

            //public Policy(string holderName, PolicyType type, DateTime startDate, DateTime endDate)
            //{
            //    PolicyID = idCounter++;
            //    HolderName = holderName;
            //    Type = type;
            //    StartDate = startDate;
            //    EndDate = endDate;
            //}
            public override string ToString()
            {
                return $"ID:{PolicyID},\tPolicy Holder Name:{HolderName}\tPolicy Type:{Type}\tStart Date:{StartDate}\tEnd Date:{EndDate} ";
            }

            public bool IsActive()
            {
                return DateTime.Now >= StartDate && DateTime.Now <= EndDate;
            }
    }
}
