using Microsoft.EntityFrameworkCore;
using SleepTrackerApi.Models;

namespace SleepTrackerApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<SleepRecord> SleepRecords { get; set; }
    }
}
