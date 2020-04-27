using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace IdentityServer.Data
{
  public  class IdentityServerDbContext:DbContext
    {
        public IdentityServerDbContext(DbContextOptions option) :base(option) { 
        
        }
 
        public DbSet<APIS> aPIS { get; set; }

        public DbSet<UserAllowedScopes> userAllowedScopes { get; set; }

        public DbSet<UserClient> userClient { get; set; }

        public DbSet<Users> users { get; set; }

        public DbSet<UserSecret> userSecret { get; set; }

    }
}
