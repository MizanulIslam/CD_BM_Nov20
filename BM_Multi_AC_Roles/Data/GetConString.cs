using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BM_Multi_AC_Roles.Data
{
    public class GetConString
    {
        public IConfiguration Configuration { get; }
        public string ConnectionString { get; private set; }

        public string getConnectionString(string cs )
        {
           
            var FirstConnectionString = "Server=(localdb)\\mssqllocaldb;Database=aspnet-Client_Accounts_Project-Tenant-";
            var lastConnectionString = ";Trusted_Connection=True;MultipleActiveResultSets=true";

            ConnectionString = FirstConnectionString + cs + lastConnectionString;
            return ConnectionString;
        }
    }
}
