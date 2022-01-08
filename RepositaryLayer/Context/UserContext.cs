using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RepositaryLayer.Entity;

namespace RepositaryLayer.Context
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions options)
            : base(options)
        {

        } 
        public DbSet<Users> User { get; set; }
        public DbSet<Notes> Note { get; set; }
        public DbSet<Collabrators> Collabrator { get; set; }

    }
}
