using Microsoft.EntityFrameworkCore;
using PerfectChannel.Infrastructure.Entities;

namespace PerfectChannel.Infrastructure.Context
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options)
            : base(options)
        {
        }
 
        public DbSet<Task> Task { get; set; }
 
        public DbSet<LastDescription> LastDescription { get; set; }
    }
}