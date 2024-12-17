using EntityFrameworkPractice.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkPractice.Contexts
{
    public class EFPContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public EFPContext(DbContextOptions<EFPContext> options) : base(options) { }


    }
}
