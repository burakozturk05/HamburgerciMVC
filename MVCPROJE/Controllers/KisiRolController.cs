using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVCPROJE.Areas.Identity.Data;

namespace MVCPROJE.Controllers
{
	public class KisiRolController : Controller
	{
		private readonly UserManager<Kullanici> _userManager;
		public KisiRolController(UserManager<Kullanici> userManager)
		{
			_userManager=userManager;
		}
		// GET: KisiRolController
		public  IActionResult Index()
		{
			var anlikKullaniciId =  _userManager.GetUserId(HttpContext.User);

			var kendisiHaricKullanicilar = _userManager.Users.Where(u => u.Id != anlikKullaniciId).ToList();
			return View(kendisiHaricKullanicilar);
		}

		// GET: KisiRolController/Details/5
		public ActionResult Details(int id)
		{
			return View();
		}

		// GET: KisiRolController/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: KisiRolController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: KisiRolController/Edit/5
		public ActionResult Edit(int id)
		{
			return View();
		}

		// POST: KisiRolController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: KisiRolController/Delete/5
		public ActionResult Delete(int id)
		{
			return View();
		}

		// POST: KisiRolController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}
	}
}
