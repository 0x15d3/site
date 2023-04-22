using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace login.Areas.Identity.Data;

// Add profile data for application users by adding properties to the ApplicationUser class
public class ApplicationUser : IdentityUser
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public decimal? Aidat { get; set; }
    public int? ArabaSayisi { get; set; }
    public int DaireNo { get; set; }
    public string Blok { get; set; }
    public bool Yonetici { get; set; } = false;

}

