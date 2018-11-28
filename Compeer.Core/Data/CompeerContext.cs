using Compeer.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Compeer.Core.Data
{
    public class CompeerContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Champion> Champions { get; set; }

        public DbSet<League> Leagues { get; set; }



        public CompeerContext()
        {                 

        }


    }
}