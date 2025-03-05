using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolicyManagementSystem.Exception
{
    internal class PolicyNotFoundException: ApplicationException
    {

        public PolicyNotFoundException(string message) : base(message)
        {

        }
    }
}
