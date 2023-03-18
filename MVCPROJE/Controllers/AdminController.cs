using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MVCPROJE.Controllers
{
    public class AdminController : Controller
    {
        //Sadece Admin rolü olanlar bu controller'a girebilir.
        [Authorize(Roles ="Admin")]
        public IActionResult AdminRol()
        {
            return View();
        }
    }
}
