using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BM_Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BM_Multi_AC_Roles.Data
{
    public class ClientListDbContext : DbContext
    {

       // public IConfiguration Configuration { get; }
        public ClientListDbContext(DbContextOptions<ClientListDbContext> options) : base(options)
        {
           

        }

      
        
    }
}
