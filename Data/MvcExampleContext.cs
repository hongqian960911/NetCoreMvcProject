using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NetCoreMvcPeoject.Models;

namespace NetCoreMvcPeoject.Data
{
    public class NetCoreMvcPeojectContext : DbContext
    {
        public NetCoreMvcPeojectContext (DbContextOptions<NetCoreMvcPeojectContext> options)
            : base(options)
        {
        }

        public DbSet<NetCoreMvcPeoject.Models.Customer> Customer { get; set; }
    }
}
