using Site.Areas.Identity.Data;

namespace Site.Models
{
    public class UsersViewModel
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string DaireNo { get; set; }
        public string TelefonNumarasi { get; set; }
        public bool UserExists { get; set; }
        public string UserId { get; set; }
        public decimal Aidat { get; set; }
        public int AracSayisi { get; set; }
    }

    public class UserDetailsViewModel
    {
        public ApplicationUser User { get; set; }
        public List<AylikAidat> AylikAidatlar { get; set; }
        public List<AracKayit> Araclar { get; set; }
    }
}
