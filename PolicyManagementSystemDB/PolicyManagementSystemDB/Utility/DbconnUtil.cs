using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;

namespace PolicyManagementSystemDB.Utility
{
    static class DbconnUtil
    {
        static IConfiguration _iconfiguration;
        static DbconnUtil() 
        {
            GetAppSettingFile();
        }

        private static void GetAppSettingFile() 
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            _iconfiguration = builder.Build();
        }

        public static string GetConnectionString()
        {
            return _iconfiguration.GetConnectionString("LocalConnectionString");
        }
    }
}
