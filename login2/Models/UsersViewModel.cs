using login2.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace login2.Models
{
    public class UsersViewModel
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string DaireNo { get; set; }
        [Display(Name = "Aidat")]
        public decimal Aidat { get; set; }
        public string TelefonNumarasi { get; set; }
        public ApplicationUser User { get; set; }
    }

    public class AylikAidat
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public decimal Aidat { get; set; }

        [Required]
        public DateTime Tarih { get; set; }

        [Required]
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }
    }
}
