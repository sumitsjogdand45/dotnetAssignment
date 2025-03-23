using System;
using System.Data.SqlClient;
using PolicyManagementSystem.constants;
using PolicyManagementSystem.Exception;
using PolicyManagementSystem.Model;
using PolicyManagementSystemDB.Utility;

namespace PolicyManagementSystem.Repository
{
    internal class PolicyRepository : IpolicyRepository
    {
        SqlConnection sqlConnection = null;
        SqlCommand cmd = null;
        string connstring;

        List<Policy> policies = new List<Policy>();
        public PolicyRepository()
        {
           cmd=new SqlCommand();
           connstring=DbconnUtil.GetConnectionString();
        }

        public int AddNewPolicy(Policy policy)
        {
            using SqlConnection sqlConnection = new SqlConnection(connstring);
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "Insert into PolicyManagementSystem(HolderName, PolicyType,StartDate,EndDate) values (@HolderName,@PolicyType,@StartDate,@EndDate)";
                
                cmd.Parameters.AddWithValue("@HolderName", policy.HolderName);
                cmd.Parameters.AddWithValue("@PolicyType", policy.Type);
                cmd.Parameters.AddWithValue("@StartDate", policy.StartDate);
                cmd.Parameters.AddWithValue("@EndDate", policy.EndDate);
                cmd.Connection = sqlConnection;
                cmd.Connection.Open();
                Console.WriteLine("Policy added successfully!!!");
                Console.WriteLine("Now your SECURITY is Our PRIORITY :)");
                return cmd.ExecuteNonQuery();
            }
        } 
        public int DeletePolicy(int id)
        {
            using (SqlConnection sqlConnection =new SqlConnection (connstring))
            {
                cmd.CommandText = "Delete from PolicyManagementSystem where PolicyID=@PolicyID";
                cmd.Parameters.AddWithValue("@PolicyId", id);
                cmd.Connection=sqlConnection;
                sqlConnection.Open();
                Console.WriteLine("Policy Deleted Successfully");
                Console.WriteLine("Congratulations! you now officially have..no policy.\nBut don't worry we can fix that in just one click!! ");
                return cmd.ExecuteNonQuery();
            }            
        }
        public void SearchPolicyById(int id)
        {

            List<Policy> policies = ViewAllPolicy();
            using (SqlConnection sqlConnection = new SqlConnection(connstring))
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "select * from PolicyManagementSystem where PolicyID=@PolicyID";
                cmd.Parameters.AddWithValue("@PolicyId", id);
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                try
                {
                    if (!policies.Any(p => p.PolicyID == id))
                    {
                        Console.WriteLine("That policy ID must be from parallel universe.Try again with real one!");
                        throw new PolicyNotFoundException("Incorrect Policy ID !!!");                         
                    }
                    if (reader.Read())
                    {
                        Policy policy = new Policy();
                        policy.PolicyID = (int)reader["PolicyID"];
                        policy.HolderName = (string)reader["HolderName"];
                        policy.Type = (PolicyType)reader["PolicyType"];
                        policy.StartDate = (DateTime)reader["StartDate"];
                        policy.EndDate = (DateTime)reader["EndDate"];
                        Console.WriteLine($"PolicyId:{policy.PolicyID}\t Holdername::{policy.HolderName}\t PolicyType::{policy.Type}\t startDate:{policy.StartDate}\tEndDate:{policy.EndDate}");

                    }

                }
                catch (PolicyNotFoundException ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
        }
        public void ViewActivePolicies()
        {
            List<Policy> activePolicies = ViewAllPolicy();
            foreach (Policy item in activePolicies) 
            {
                if (item.IsActive()) 
                {
                    Console.WriteLine(item);
                }   
            }               
        }
        public List<Policy> ViewAllPolicy()
        {
            List<Policy> policies = new List<Policy>();
            using(SqlConnection sqlConnection =new SqlConnection(connstring))
                {
                cmd.CommandText = "select * from PolicyManagementSystem";
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read()) 
                {
                    Policy policy = new Policy();
                    policy.PolicyID = (int)reader["PolicyID"];
                    policy.HolderName = (string)reader["HolderName"];
                    policy.Type = (PolicyType)reader["PolicyType"];
                    policy.StartDate = (DateTime)reader["StartDate"];
                    policy.EndDate = (DateTime)reader["EndDate"];
                    policies.Add(policy);
                }
                return policies;
            }           
        }
       public int UpdatePolicy(int id)
        {
            List<Policy> policyList = ViewAllPolicy();
            using (SqlConnection sqlConnection = new SqlConnection(connstring))
            {
                cmd.Parameters.Clear();
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                try
                {
                    Console.WriteLine("Choose the option to update");
                    Console.WriteLine("1.Policy Holder Name");
                    Console.WriteLine("2.Policy Type");
                    Console.WriteLine("3.End Date");
                    Console.WriteLine("4.Exit");

                    if (!policyList.Any(policies => policies.PolicyID == id))
                    {
                        throw new PolicyNotFoundException($"Policy ID {id} not found");
                    }
                    while (true)
                    {
                        Console.WriteLine("Enter your choice ");
                        int choice = Convert.ToInt32(Console.ReadLine());

                        switch (choice)
                        {
                            case 1:
                                Console.Write("Enter new Policy Holder Name: ");
                                string HolderName = Console.ReadLine();
                                cmd.Parameters.Clear();
                                cmd.CommandText = "Update PolicyManagementSystem set HolderName=@HolderName where PolicyID=@PolicyID";
                                cmd.Parameters.AddWithValue("@HolderName", HolderName);
                                cmd.Parameters.AddWithValue("@PolicyID", id);
                                Console.WriteLine("policy holder nme updated successfully");
                                cmd.ExecuteNonQuery();
                                break;

                            case 2:
                                Console.WriteLine("Enter new Policy Type (Life, Health, Vehicle, Property):");
                                PolicyType policytype = (PolicyType)Enum.Parse(typeof(PolicyType), Console.ReadLine(), true);
                                cmd.Parameters.Clear();
                                cmd.CommandText = "Update PolicyManagementSystem set PolicyType=@PolicyType where PolicyID=@PolicyID";
                                cmd.Parameters.AddWithValue("@PolicyType", policytype);
                                cmd.Parameters.AddWithValue("@PolicyID", id);
                                Console.WriteLine("Policy type updated successfully.");
                                cmd.ExecuteNonQuery();
                                break;

                            case 3:
                                Console.Write("Enter new End Date (yyyy-MM-dd): ");
                                DateTime EndDate = DateTime.Parse(Console.ReadLine());
                                cmd.Parameters.Clear();
                                cmd.CommandText = "Update PolicyManagementSystem set  EndDate=@EndDate where PolicyID=@PolicyID";
                                cmd.Parameters.AddWithValue("@EndDate", EndDate);
                                cmd.Parameters.AddWithValue("@PolicyID", id);
                                Console.WriteLine("Policy EndDate updated successfully.");
                                cmd.ExecuteNonQuery();
                                break;

                            case 4:
                                return cmd.ExecuteNonQuery();                               

                            default:
                                Console.WriteLine("Invalid Choice");
                                break;
                        }        

                    }
                }
                catch (PolicyNotFoundException ex)
                {
                    Console.WriteLine("Invalid Policy ID");
                    return 0;
                }
            }
        }
    }
    
}
