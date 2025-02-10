using Microsoft.AspNetCore.Mvc;
using NSE.WebApp.MVC.Models;

namespace NSE.WebApp.MVC.Controllers
{
    public class IdentityController: Controller
    {
        [HttpGet]
        [Route("new-account")]
        public IActionResult Register() => View();

        [HttpPost]
        [Route("new-account")]
        public async Task<IActionResult> Register(UserRegister userRegister)
        {
            if(!ModelState.IsValid) return View(userRegister);

            if (false) return View(userRegister);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [Route("login")]
        public IActionResult Login() => View();

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(UserLogin userLogin)
        {
            if (!ModelState.IsValid) return View(userLogin);

            if (false) return View(userLogin);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [Route("logout")]
        public async Task<IActionResult> Logout()
        {
            return RedirectToAction("Index", "Home");
        }
    }
}
