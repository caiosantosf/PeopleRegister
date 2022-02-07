using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PeopleRegister.Data.Mappings;
using PeopleRegister.Domain.Entities;

namespace PeopleRegister.Data;

public class Context : DbContext
{
    public IConfiguration Configuration { get; }

    public Context() { }

    public Context(DbContextOptions<Context> options, IConfiguration configuration) : base(options)
    {
        Configuration = configuration;
    }

    public DbSet<Person> People { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var conn = Configuration.GetConnectionString("Default");
        if (conn == null)
            optionsBuilder.UseSqlServer();
        else
            optionsBuilder.UseSqlServer(conn);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Ignore<Notification>();

        modelBuilder.ApplyConfiguration(new PersonMap());

        base.OnModelCreating(modelBuilder);
    }

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

