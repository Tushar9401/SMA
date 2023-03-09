using SMA.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMA.SQl
{
    public class AppDbContext:DbContext
    {
        public AppDbContext() : base("DefaultConnection")
        {
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<UserRegistration> User { get; set; }
    }
}

