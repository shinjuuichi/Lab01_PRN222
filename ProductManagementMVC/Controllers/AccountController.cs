using BusinessObjects;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace ProductManagementMVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(AccountMember model)
        {
            var user = _accountService.GetAccountByEmail(model.EmailAddress);
            if (user != null && user.MemberPassword == model.MemberPassword)
            {
                HttpContext.Session.SetString("UserId", user.MemberId);
                HttpContext.Session.SetString("Username", user.FullName);
                return RedirectToAction("Index","Products");
            }
            else
            {
                ModelState.AddModelError("", "Invalid username or password.");
            }
            return View(model);
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
