using Site.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;

namespace Site.Models
{
    public class AracKayit
    {
        public int Id { get; set; }
        public string UserId { get; set; }

        [Required]
        [StringLength(10)]
        public string Plaka { get; set; }
        public string Marka { get; set; }

        public DateTime Tarih { get; set; }
        public ApplicationUser User { get; set; }
    }
}
