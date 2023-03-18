using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MVCPROJE.Controllers
{
    [Authorize(Roles ="User")]
    public class UserController : Controller
    {

        public UserController()
        {

        }
        //Sistemde kayıtlı olan kişileri getir
        public IActionResult UserRol()
        {
            return View();
        }
    }
}
