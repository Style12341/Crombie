using EntityFrameworkPractice.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace EntityFrameworkPractice.Persistance.Interfaces
{
    public interface IEFPContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Post> Posts { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
