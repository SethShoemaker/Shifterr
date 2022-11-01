using Microsoft.EntityFrameworkCore;
using webapi.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace webapi.Data
{
    public class ApplicationContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options): base(options){}
        public DbSet<Organization> Organizations { get; set; } = null!;
        public DbSet<Shift> Shifts { get; set; } = null!;
        public DbSet<ShiftPosition> ShiftPositions { get; set; } = null!;
        public DbSet<Worker> Workers { get; set; } = null!;
    }
}