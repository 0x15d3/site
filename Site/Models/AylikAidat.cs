using Site.Areas.Identity.Data;

namespace Site.Models
{
    public class AylikAidat
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public DateTime Tarih { get; set; }
        public decimal Tutar { get; set; }
        public ApplicationUser User { get; set; }
    }

}
