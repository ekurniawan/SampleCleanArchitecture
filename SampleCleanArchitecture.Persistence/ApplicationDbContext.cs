using Microsoft.EntityFrameworkCore;
using SampleCleanArchitecture.Domain.Common;
using SampleCleanArchitecture.Domain.Entities;

namespace SampleCleanArchitecture.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Event> Events { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            var guid1 = new Guid("f5f3b3d3-3b4b-4b1e-8f4b-6f1f3f3f3f3f");
            //create different guid for each entity
            var guid2 = new Guid("f5f3b3d3-3b4b-4b1e-8f4b-6f1f3f3f3f3e");
            var guid3 = new Guid("f5f3b3d3-3b4b-4b1e-8f4b-6f1f3f3f3f3d");
            var guid4 = new Guid("f5f3b3d3-3b4b-4b1e-8f4b-6f1f3f3f3f3c");

            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = guid1, Name = "Black Pink" }
            );
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = guid2, Name = "Red Velvet" }
            );
            modelBuilder.Entity<Category>().HasData(
                               new Category { CategoryId = guid3, Name = "Twice" }
            );
            modelBuilder.Entity<Category>().HasData(
                               new Category { CategoryId = guid4, Name = "Mamamoo" }
            );

            modelBuilder.Entity<Event>().HasData(
                               new Event
                               {
                                   EventId = Guid.NewGuid(),
                                   Name = "Black Pink Concert",
                                   Artist = "Black Pink",
                                   Price = 10000,
                                   Date = DateTime.Now.AddMonths(1),
                                   Description = "Black Pink Concert",
                                   ImageUrl = "",
                                   CategoryId = guid1
                               },
                               new Event
                               {
                                   EventId = Guid.NewGuid(),
                                   Name = "Red Velvet Concert",
                                   Artist = "Red Velvet",
                                   Price = 10000,
                                   Date = DateTime.Now.AddMonths(2),
                                   Description = "Red Velvet Concert",
                                   ImageUrl = "",
                                   CategoryId = guid2
                               },
                               new Event
                               {
                                   EventId = Guid.NewGuid(),
                                   Name = "Twice Concert",
                                   Artist = "Twice",
                                   Price = 10000,
                                   Date = DateTime.Now.AddMonths(3),
                                   Description = "Twice Concert",
                                   ImageUrl = "",
                                   CategoryId = guid3
                               },
                               new Event
                               {
                                   EventId = Guid.NewGuid(),
                                   Name = "Mamamoo Concert",
                                   Artist = "Mamamoo",
                                   Price = 10000,
                                   Date = DateTime.Now.AddMonths(3),
                                   Description = "Mamamoo Concert",
                                   ImageUrl = "",
                                   CategoryId = guid4
                               }

            );
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
