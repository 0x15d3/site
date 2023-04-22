using login2.Areas.Identity.Data;
using login2.Data;
using login2.Migrations;
using login2.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace login2.Controllers
{
    public class AdminController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IdentityContext _context;
        private List<AylikAidat> _aidatlar;

        private List<AylikAidat> GetAidatList()
        {
            return _context.Users.Include(u => u.Aidatlar).SelectMany(u => u.Aidatlar).ToList();
        }


        public AdminController(UserManager<ApplicationUser> userManager, IdentityContext context,List<AylikAidat> aidatlar)
        {
            _userManager = userManager;
            _context = context;
            _aidatlar = aidatlar;
        }

        public IActionResult Index()
        {
            var users = _userManager.Users.Include(u => u.Aidatlar);
            var model = new List<UsersViewModel>();

            foreach (var user in users)
            {
                var aidat = _aidatlar.Where(a => a.UserId == user.Id).Sum(a => a.Aidat);
                model.Add(new UsersViewModel
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Email = user.Email,
                    DaireNo = user.DaireNo,
                    Aidat = aidat,
                    TelefonNumarasi = user.TelefonNumarasi,
                    User = user
                });
            }

            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> Edit(string id, UsersViewModel model)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            if (model == null)
            {
                model = new UsersViewModel();
            }

            user.UserName = model.UserName;
            user.Email = model.Email;
            user.DaireNo = model.DaireNo;
            user.Aidat = model.Aidat;
            user.TelefonNumarasi = model.TelefonNumarasi;

            await _userManager.UpdateAsync(user);

            var aidat = new AylikAidat { Aidat = user.Aidat, Tarih = DateTime.Now, UserId = model.User.Id };
            _context.Aidatlar.Add(aidat);
            await _context.SaveChangesAsync();
            _aidatlar = GetAidatList();

            return View(model);
        }

        private bool UserExists(string id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}

