using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PolicyManagementSystem.constants;
using PolicyManagementSystem.Model;

namespace PolicyManagementSystem.Repository
{
    internal interface IpolicyRepository
    {
        public void AddNewPolicy(Policy policy);
        public void UpdatePolicy(int id, string name, PolicyType type, DateTime startDate, DateTime endDate);
        public void DeletePolicy(int id);
        public void ViewAllPolicy();
        public Policy SearchPolicyById(int id);
        public void ViewActivePolicies();
    }
}
