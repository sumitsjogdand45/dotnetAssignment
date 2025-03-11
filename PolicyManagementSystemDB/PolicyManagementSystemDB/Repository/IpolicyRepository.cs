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
        public int AddNewPolicy(Policy policy);
        public int UpdatePolicy(int id);
        public int DeletePolicy(int id);
        public List<Policy> ViewAllPolicy();
        public void SearchPolicyById(int id);
        public void ViewActivePolicies();
    }
}
