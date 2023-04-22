using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Site.Areas.Identity.Data;
using Site.Models;

namespace Site.Data;

public class IdentityContext : IdentityDbContext<ApplicationUser>
{
    public DbSet<AylikAidat> AylikAidatlar { get; set; }
    public DbSet<AracKayit> AracKayit { get; set; }
    public IdentityContext(DbContextOptions<IdentityContext> options)
        : base(options)
    {
    }

protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
