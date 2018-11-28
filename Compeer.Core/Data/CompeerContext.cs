using Compeer.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Compeer.Core.Data
{
    public class CompeerContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public CompeerContext()
        {                       
        }





    }
}