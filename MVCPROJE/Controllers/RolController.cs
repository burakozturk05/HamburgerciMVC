using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCPROJE.Context;
using MVCPROJE.Models.Data;

namespace MVCPROJE.Controllers
{
    [Authorize(Roles ="Admin")]
    public class RolController : Controller
    {
        private readonly UygulamaDbContext _db;
        private readonly RoleManager<IdentityRole> _roleManager;
        public RolController(UygulamaDbContext db,RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _roleManager = roleManager;
        }
        // GET: RolController
        public async Task<IActionResult> Index() //Rollerin listeleneceği bölüm
        {
            var butunRoller= await _roleManager.Roles.ToListAsync();
            return View(butunRoller);
        }

        // GET: RolController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RolController/Create
        public async Task<IActionResult> Create()
        {
            return View();
        }

        // POST: RolController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IdentityRole rol)
        {
            try
            {
                //formdan gelen rolVM 'in adı bizim ekleyeceğimiz HAKİKİ rolün adıdır.
                //İşte bu rol adını role manager ı kullanarak rol ekleyeceğiz.
                //önce yeni bir rol oluşturalım.
                var yeniRol = new IdentityRole();
                yeniRol.Name = rol.Name;
                await _roleManager.CreateAsync(yeniRol);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RolController/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            var guncellenecekRol = await _roleManager.FindByIdAsync(id);
            
            return View(guncellenecekRol);
        }

        // POST: RolController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(IdentityRole rol)
        {
            try
            {
                var rol2 = await _roleManager.FindByIdAsync(rol.Id);
                rol2.Name = rol.Name;
                var sonuc =await _roleManager.UpdateAsync(rol2);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RolController/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            //Gonderilen id ye ait olan rolü sil.
            var silinecekRol = await _roleManager.FindByIdAsync(id);
            await _roleManager.DeleteAsync(silinecekRol);
            return RedirectToAction(nameof(Index));
        }

        
    }
}
