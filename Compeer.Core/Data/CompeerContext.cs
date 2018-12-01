using Compeer.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Compeer.Core.Data
{
    public class CompeerContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        // public DbSet<Champion> Champions { get; set; }

        // public DbSet<League> Leagues { get; set; }

        // public DbSet<Lane> Lanes { get; set; }

        // public DbSet<Match> Matches { get; set; }

        public DbSet<Queue> Queues { get; set; }

        public CompeerContext(DbContextOptions<CompeerContext> options) : base(options)
        {                 

        }

    }
}