using login2.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration.UserSecrets;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;
using login2.Models;

namespace login2.Data;


public partial class Sikayet
{
    public int Id { get; set; }
    public string Konu { get; set; }
    [Display(Name ="Şikayet Edilen")]
    public string SikayetEdenId { get; set; }
    [Display(Name ="Şikayetiniz")]
    public string SikayetText { get; set; }
}

public class IdentityContext : IdentityDbContext<ApplicationUser>
{
    public IdentityContext(DbContextOptions<IdentityContext> options)
        : base(options)
    {/*
        var optionsBuilder = new DbContextOptionsBuilder<IdentityContext>();
        optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Login;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        var context = new IdentityContext(optionsBuilder.Options); */
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);


    }

    public DbSet<Sikayet> sikayetler { get; set; }
    public DbSet<login2.Models.UsersViewModel> UsersViewModel { get; set; } = default!;
    public DbSet<ApplicationUser> applicationUser { get; set; }
    public ICollection<AylikAidat> Aidatlar { get; set; }
}
