using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace VitruviSoft.DAL.Entities
{
    public class GroupContext : DbContext
    {
        public DbSet<Group> Groups { get; set; }
        public DbSet<Provider> Providers { get; set; }

        public GroupContext(DbContextOptions<GroupContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
