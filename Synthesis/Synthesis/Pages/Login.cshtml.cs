using System.Security.Claims;
using Entities;
using LogicLayer.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SynthesisWeb.Pages
{
    public class LoginModel : PageModel
    {
        private IAuthenticationManager _authenticationManager;
        private IUserManager _userManager;

        public LoginModel(IAuthenticationManager authenticationManager,IUserManager userManager)
        {
            _authenticationManager = authenticationManager;
            _userManager = userManager;
        }

        [BindProperty]
        public string Username { get; set; }
        [BindProperty]
        public string Password { get; set; }

        public void OnGet()
        {
        }

        public async void Auth(string user)
        {
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, user));
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            await HttpContext.SignInAsync(new ClaimsPrincipal(claimsIdentity));
        }

        public IActionResult OnPost()
        {
            _authenticationManager.ResetUsers();
            _userManager.ResetAllUsers();
            int userId = _authenticationManager.AuthenticatePlayer(Username, Password);
            if (userId != -1)
            {
                User user = _userManager.GetUser(userId);
                HttpContext.Session.SetInt32("User_Id", userId);
                Auth(user.ToString());
                return RedirectToPage("Account");
            }
            else
            {
                ViewData["ErrorMessage"] = "Wrong username or password";
                return Page();
            }
        }
    }
}
