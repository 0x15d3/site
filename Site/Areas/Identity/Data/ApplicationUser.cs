using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Build.Framework;

namespace Site.Areas.Identity.Data;

// Add profile data for application users by adding properties to the ApplicationUser class
public class ApplicationUser : IdentityUser
{
    public string UserName { get; set; }
    public string DaireNo { get; set; }
    public string TelefonNumarasi { get; set; }
    public double Aidat { get; set; }
}

