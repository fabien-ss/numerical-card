using Microsoft.EntityFrameworkCore;
using Sante.Models.service;

namespace Sante.Models.bdd;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    
    // set the object database here
    
    public DbSet<Civil> civil { get; set; }
    public DbSet<Hopital> hopital { get; set; }
    public DbSet<PersonDesease> personDeseases { get; set; }
    public DbSet<Disease> diseases { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PersonDesease>().HasNoKey();
    }
    // ...
}