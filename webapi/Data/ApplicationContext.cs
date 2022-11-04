using Microsoft.EntityFrameworkCore;
using webapi.Models;

namespace webapi.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options): base(options){}
        public DbSet<Organization> Organizations { get; set; } = null!;
        public DbSet<Shift> Shifts { get; set; } = null!;
        public DbSet<ShiftPosition> ShiftPositions { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<UserConfirmationKey> UserConfirmationKeys { get; set; } = null!;
    }
}