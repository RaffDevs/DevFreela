using DevFreela.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Infrastructure.Persistence;

public class DevFreelaDbContext : DbContext
{
    public DevFreelaDbContext(DbContextOptions<DevFreelaDbContext> options) : base(options)
    {
    }

    public DbSet<Project> Projects { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Skill> Skills { get; set; }
    public DbSet<UserSkill> UserSkills { get; set; }
    public DbSet<ProjectComment> ProjectComments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Project>()
            .HasKey(p => p.Id);
        modelBuilder.Entity<Project>()
            .HasOne(p => p.Freelencer)
            .WithMany(f => f.FreelanceProject)
            .HasForeignKey(p => p.IdFreelancer)
            .OnDelete(DeleteBehavior.Restrict);
        modelBuilder.Entity<Project>()
            .HasOne(p => p.Client)
            .WithMany(c => c.OwnedProjects)
            .HasForeignKey(p => p.IdClient)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<ProjectComment>()
            .HasKey(p => p.Id);

        modelBuilder.Entity<ProjectComment>()
            .HasOne(pc => pc.Project)
            .WithMany(p => p.Comments)
            .HasForeignKey(pc => pc.IdProject)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<ProjectComment>()
            .HasOne(pc => pc.User)
            .WithMany(u => u.Comments)
            .HasForeignKey(pc => pc.IdUser)
            .OnDelete(DeleteBehavior.Restrict);
        
        modelBuilder.Entity<Skill>()
            .HasKey(s => s.Id);

        modelBuilder.Entity<UserSkill>()
            .HasKey(s => s.Id);

        modelBuilder.Entity<User>()
            .HasKey(u => u.Id);

        modelBuilder.Entity<User>()
            .HasMany(u => u.Skills)
            .WithOne()
            .HasForeignKey(u => u.IdSkill)
            .OnDelete(DeleteBehavior.Restrict);
        
        base.OnModelCreating(modelBuilder);
    }
}