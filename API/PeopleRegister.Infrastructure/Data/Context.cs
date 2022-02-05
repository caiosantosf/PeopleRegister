using Microsoft.EntityFrameworkCore;
using PeopleRegister.Domain.Entities;

namespace PeopleRegister.Infrastructure.Data;

public class Context : DbContext
{
    public Context() { }

    public Context(DbContextOptions<Context> options) : base(options) { }

    public DbSet<Person> People { get; set; }

    public override int SaveChanges()
    {
        foreach (var entry in ChangeTracker.Entries())
        {
            if (entry.State == EntityState.Added)
                entry.Property("CreatedAt").CurrentValue = DateTime.Now;

            if (entry.State == EntityState.Modified)
                entry.Property("UpdatedAt").CurrentValue = DateTime.Now;
        }
        
        return base.SaveChanges();
    }
}

