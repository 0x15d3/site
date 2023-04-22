using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Site.Areas.Identity.Data;
using Site.Data;
using Site.Models;


public class UsersController : Controller
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly IdentityContext _context;

    public UsersController(
        UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager,
        IdentityContext context)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _context = context;
    }

 
    public async Task<IActionResult> Index()
    {
        var users = await _userManager.Users.ToListAsync();
        var viewModel = new List<UsersViewModel>();

        foreach (var user in users)
        {
            var userViewModel = new UsersViewModel
            {
                UserId = user.Id,
                Email = user.Email,
                Aidat = _context.AylikAidatlar
                    .Where(a => a.UserId == user.Id)
                    .OrderByDescending(a => a.Tarih)
                    .FirstOrDefault()?.Tutar ?? 0
            };
            viewModel.Add(userViewModel);
        }

        return View(viewModel);
    }

    public async Task<IActionResult> UserIndex()
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null)
        {
            return NotFound();
        }

        var viewModel = new UserDetailsViewModel
        {
            User = user,
            AylikAidatlar = _context.AylikAidatlar.Where(a => a.UserId == user.Id).ToList(),
            Araclar = _context.AracKayit.Where(a => a.UserId == user.Id).ToList()
        };

        return View(viewModel);
    }
 
    [HttpGet]
    public async Task<IActionResult> Edit(string id)
    {
        var user = await _userManager.FindByIdAsync(id);
        if (user == null)
        {
            return RedirectToAction("Login", "Account");
        }

        var viewModel = new UsersViewModel
        {
            UserId = user.Id,
            Email = user.Email,
            Aidat = _context.AylikAidatlar
                .Where(a => a.UserId == user.Id)
                .OrderByDescending(a => a.Tarih)
                .FirstOrDefault()?.Tutar ?? 0
        };

        return View(viewModel);
    }

 
    [HttpPost]
    public async Task<IActionResult> Edit(string id, decimal aidat)
    {
        var user = await _userManager.FindByIdAsync(id);

        if (user == null)
        {
            return NotFound();
        }

        var aylikAidat = new AylikAidat
        {
            UserId = user.Id,
            Tarih = DateTime.Today,
            Tutar = aidat
        };

        _context.AylikAidatlar.Add(aylikAidat);
        await _context.SaveChangesAsync();

        return RedirectToAction("Index");
    }

 
    [HttpGet]
    public IActionResult AracEkle()
    {
        return View();
    }

 
    [HttpPost]
    public async Task<IActionResult> AracEkle(string plaka, string marka)
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null)
        {
            return RedirectToAction("Login", "Account");
        }


        var aracSayisi = _context.AracKayit.Count(a => a.UserId == user.Id);
        if (aracSayisi >= 3)
        {
            ModelState.AddModelError("", "Maksimum araç sayısına ulaşıldı.");
            return View();
        }

        var aracKayit = new AracKayit()
        {
            UserId = user.Id,
            Plaka = plaka,
            Marka = marka,
            Tarih = DateTime.Now
        };

        _context.AracKayit.Add(aracKayit);
        await _context.SaveChangesAsync();

        return RedirectToAction("Index", "Home");
    }

 
    public IActionResult Details(string id)
    {
        var user = _userManager.FindByIdAsync(id.ToString()).Result;
        var aylikAidat = _context.AylikAidatlar.Where(a => a.UserId == id).ToList();
        var viewModel = new UserDetailsViewModel
        {
            User = user,
            AylikAidatlar = aylikAidat
        };
        return View(viewModel);
    }

 
    public IActionResult AracDetails(string id)
    {
        var user = _userManager.FindByIdAsync(id.ToString()).Result;
        var araclar = _context.AracKayit.Where(a => a.UserId == id).ToList();
        var viewModel = new UserDetailsViewModel
        {
            User = user,
            Araclar = araclar
        };
        var aracSayisi = _context.AracKayit.Count(a => a.UserId == user.Id);
        Console.WriteLine(aracSayisi.ToString() + "----------------------------------------");
        return View(viewModel);
    }


    ////////////// admin
    ///


 
    [HttpGet]
    //[Authorize(Roles ="Yonetici")]
    public IActionResult AdminAracEkle()
    {
        ViewBag.UserId = new SelectList(_context.Users, "Id", "UserName");
        return View();
    }

 
    [HttpPost]
    public async Task<IActionResult> AdminAracEkle(string plaka, string marka,string userid)
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null)
        {
            return RedirectToAction("Login", "Account");
        }
        var aracSayisi = _context.AracKayit.Count(a => a.UserId == user.Id);
        Console.WriteLine(aracSayisi);
        var aracKayit = new AracKayit()
        {
            UserId = userid,
            Plaka = plaka,
            Marka = marka,
            Tarih = DateTime.Now
        };
        if (aracSayisi < 2)
        {
            Console.WriteLine("arac 2den fzla");
            SelectUserIdFromDropDown(user.Id);
            aracKayit.Tarih = DateTime.Now;
            _context.AracKayit.Add(aracKayit);
            await _context.SaveChangesAsync();
        }
        
            return RedirectToAction("Index", "Users");
    }

    private void SelectUserIdFromDropDown(object selectedUser = null)
    {
        var useridQuery = from d in _context.AracKayit
                               orderby d.UserId
                               select d;
        ViewBag.UserId = new SelectList(useridQuery, "UserId", "Name", selectedUser);
    }

}
