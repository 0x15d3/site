using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using login2.Models;
using Microsoft.AspNetCore.Identity;

namespace login2.Areas.Identity.Data;

public class ApplicationUser : IdentityUser
{
    public string DaireNo { get; set; }
    public decimal Aidat { get; set; }
    public string TelefonNumarasi { get; set; }

    public ICollection<AylikAidat> Aidatlar { get; set; }
}

