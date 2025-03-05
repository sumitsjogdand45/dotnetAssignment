using System;
using PolicyManagementSystem.constants;
using PolicyManagementSystem.Exception;
using PolicyManagementSystem.Model;

namespace PolicyManagementSystem.Repository
{
    internal class PolicyRepository : IpolicyRepository
    {
        List<Policy> policies = new List<Policy>();
        public PolicyRepository()
        {
            policies = new List<Policy>();
        }

        public void AddNewPolicy(Policy policy)
        {
            policies.Add(policy);
            Console.WriteLine("Policy added successfully!!!");
            Console.WriteLine("Now your SECURITY is Our PRIORITY :)");
            Console.WriteLine();
        }

        public void DeletePolicy(int id)
        {
            Policy policy = SearchPolicyById(id);
            policies.Remove(policy);
            Console.WriteLine("Policy Deleted Successfully");
            Console.WriteLine("Congratulations! you now officially have..no policy.\nBut don't worry we can fix that in just one click!! ");
            Console.WriteLine();
        }

        public Policy SearchPolicyById(int id)
        {
            Policy policy = policies.Find(p => p.PolicyID == id);
            if (policy == null)
                throw new PolicyNotFoundException("Incorrect Policy ID !!!");
            Console.WriteLine("That policy ID must be from parallel universe.Try again with real one!");
            Console.WriteLine();
            return policy;
        }

        public void UpdatePolicy(int id, string name, PolicyType type, DateTime startDate, DateTime endDate)
        {
            Policy policy = SearchPolicyById(id);
            policy.HolderName = name;
            policy.Type = type;
            policy.StartDate = startDate;
            policy.EndDate = endDate;
            Console.WriteLine("You're Covered! Update Successful");
            Console.WriteLine();
        }

        public void ViewActivePolicies()
        {
            List<Policy> activePolicies = policies.FindAll(p => p.IsActive());
            if (activePolicies.Count == 0)
            {
                Console.WriteLine("Your policy took a vacation! Get a new one.");

                return;
            }
            activePolicies.ForEach(p => Console.WriteLine(p));
        }

        public void ViewAllPolicy()
        {
            if (policies.Count == 0)
            {
                Console.WriteLine("Uh-Oh! Looks like you're policy free.No Policies found");
                return;
            }
            policies.ForEach(p => Console.WriteLine(p));
        }

    }
}
