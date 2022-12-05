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
        public DbSet<UserToken> UserTokens { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Organization>().HasData(
                new Organization { 
                    Id = 1,
                    Name = "Demo Organization"
                }
            );

            modelBuilder.Entity<User>().HasData(
                new User { 
                    Id = 1, 
                    OrganizationId = 1,
                    UserName = "DemoAdmin", 
                    Nickname = "John Admin", 
                    Email = "JohnAdmin@demo.com",
                    EmailIsConfirmed = true,
                    PasswordHash = "xz0rpXQA20GApgQN1mbzGB2k0cPZon6pqj27QlMT9FusR0qivML/6ZpeP+8vPiZ++2ojmdN0PWUZKdFNEsizXA==",
                    PasswordSalt = "Y1kTl8HvHA4dRuD95FEXNLWhqkUwREWmSwefPg+cVLCRVfJ2ZxFWyDq9SCNm1EdpIDkrTlFQsbJCcd7t7G8wk6JHDcG9u7Db6+/xAOngNSGfzZnb7y5QpFCQ79WnEBl888hjQsvDBFFeLkORNThF6I3allb0ilSEPzgkNo2pr1s=",
                    OrganizationRole = OrganizationRole.Administrator
                },

                new User { 
                    Id = 2, 
                    OrganizationId = 1,
                    UserName = "DemoManager1", 
                    Nickname = "Amy Manager", 
                    Email = "AmyManager@demo.com",
                    EmailIsConfirmed = true,
                    PasswordHash = "xz0rpXQA20GApgQN1mbzGB2k0cPZon6pqj27QlMT9FusR0qivML/6ZpeP+8vPiZ++2ojmdN0PWUZKdFNEsizXA==",
                    PasswordSalt = "Y1kTl8HvHA4dRuD95FEXNLWhqkUwREWmSwefPg+cVLCRVfJ2ZxFWyDq9SCNm1EdpIDkrTlFQsbJCcd7t7G8wk6JHDcG9u7Db6+/xAOngNSGfzZnb7y5QpFCQ79WnEBl888hjQsvDBFFeLkORNThF6I3allb0ilSEPzgkNo2pr1s=",
                    OrganizationRole = OrganizationRole.Manager
                },

                new User { 
                    Id = 3, 
                    OrganizationId = 1,
                    UserName = "DemoManager2", 
                    Nickname = "Adam Manager", 
                    Email = "AdamManager@demo.com",
                    EmailIsConfirmed = true,
                    PasswordHash = "xz0rpXQA20GApgQN1mbzGB2k0cPZon6pqj27QlMT9FusR0qivML/6ZpeP+8vPiZ++2ojmdN0PWUZKdFNEsizXA==",
                    PasswordSalt = "Y1kTl8HvHA4dRuD95FEXNLWhqkUwREWmSwefPg+cVLCRVfJ2ZxFWyDq9SCNm1EdpIDkrTlFQsbJCcd7t7G8wk6JHDcG9u7Db6+/xAOngNSGfzZnb7y5QpFCQ79WnEBl888hjQsvDBFFeLkORNThF6I3allb0ilSEPzgkNo2pr1s=",
                    OrganizationRole = OrganizationRole.Manager
                },

                new User { 
                    Id = 4, 
                    OrganizationId = 1,
                    UserName = "DemoCrew1", 
                    Nickname = "George Crew", 
                    Email = "GeorgeCrew@demo.com",
                    EmailIsConfirmed = true,
                    PasswordHash = "xz0rpXQA20GApgQN1mbzGB2k0cPZon6pqj27QlMT9FusR0qivML/6ZpeP+8vPiZ++2ojmdN0PWUZKdFNEsizXA==",
                    PasswordSalt = "Y1kTl8HvHA4dRuD95FEXNLWhqkUwREWmSwefPg+cVLCRVfJ2ZxFWyDq9SCNm1EdpIDkrTlFQsbJCcd7t7G8wk6JHDcG9u7Db6+/xAOngNSGfzZnb7y5QpFCQ79WnEBl888hjQsvDBFFeLkORNThF6I3allb0ilSEPzgkNo2pr1s=",
                    OrganizationRole = OrganizationRole.Crew
                },

                new User { 
                    Id = 5, 
                    OrganizationId = 1,
                    UserName = "DemoCrew2", 
                    Nickname = "Jamie Crew", 
                    Email = "JamieCrew@demo.com",
                    EmailIsConfirmed = true,
                    PasswordHash = "xz0rpXQA20GApgQN1mbzGB2k0cPZon6pqj27QlMT9FusR0qivML/6ZpeP+8vPiZ++2ojmdN0PWUZKdFNEsizXA==",
                    PasswordSalt = "Y1kTl8HvHA4dRuD95FEXNLWhqkUwREWmSwefPg+cVLCRVfJ2ZxFWyDq9SCNm1EdpIDkrTlFQsbJCcd7t7G8wk6JHDcG9u7Db6+/xAOngNSGfzZnb7y5QpFCQ79WnEBl888hjQsvDBFFeLkORNThF6I3allb0ilSEPzgkNo2pr1s=",
                    OrganizationRole = OrganizationRole.Crew
                },

                new User { 
                    Id = 6, 
                    OrganizationId = 1,
                    UserName = "DemoCrew3", 
                    Nickname = "Rebecca Crew", 
                    Email = "RebeccaCrew@demo.com",
                    EmailIsConfirmed = true,
                    PasswordHash = "xz0rpXQA20GApgQN1mbzGB2k0cPZon6pqj27QlMT9FusR0qivML/6ZpeP+8vPiZ++2ojmdN0PWUZKdFNEsizXA==",
                    PasswordSalt = "Y1kTl8HvHA4dRuD95FEXNLWhqkUwREWmSwefPg+cVLCRVfJ2ZxFWyDq9SCNm1EdpIDkrTlFQsbJCcd7t7G8wk6JHDcG9u7Db6+/xAOngNSGfzZnb7y5QpFCQ79WnEBl888hjQsvDBFFeLkORNThF6I3allb0ilSEPzgkNo2pr1s=",
                    OrganizationRole = OrganizationRole.Crew
                }
            );
        }
    }
}