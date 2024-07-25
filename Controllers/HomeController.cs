using LoginPOC.Data;
using LoginPOC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LoginPOC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration configuration;

        public HomeController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public IActionResult Login()
        {
            var loginmodel = new Loginviewmodel();
            return View(loginmodel);
        }

        [HttpPost]
        public IActionResult Login(Loginviewmodel loginviewmodel)
        {
            if (ModelState.IsValid)
            {
                // db call
                var loginDataAccess = new LoginDataAccess(configuration);

                var (isSuccess, message) = loginDataAccess.UserLogin(loginviewmodel.Username, loginviewmodel.Password);

                if (isSuccess)
                {
                    return RedirectToAction("Success", "Home");
                }
                else
                {
                    loginviewmodel.IsLoginFailed = true;
                    ModelState.AddModelError("", message);
                }
            }

            return View(loginviewmodel);
        }

        public IActionResult Success()
        {
            return View();
        }


        public IActionResult Register()
        {
            var viewmodel = new RegisterViewModel();

            return View(viewmodel);
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel registerViewModel)
        {
            if (ModelState.IsValid)
            {
                var registerDataAccess = new RegisterDataAccess(configuration);

                var result = registerDataAccess.SaveUser(registerViewModel.Name,
                    registerViewModel.Email,
                    registerViewModel.Password);

                registerViewModel = new RegisterViewModel();

                registerViewModel.Id = result;

                return View(registerViewModel);
            }

            return View(registerViewModel);
        }

            public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
