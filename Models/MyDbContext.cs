using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TestApp1.Models;

public class MyDbContext : IdentityDbContext<ApplicationUser>
{
    public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
    {
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure additional model mappings or relationships here
    }


    public virtual DbSet<SignUpModel> SignUpModels { get; set; }

    // public virtual DbSet<Login> Logins { get; set; }

    public virtual DbSet<TaskModel> TaskModels { get; set; }
}
