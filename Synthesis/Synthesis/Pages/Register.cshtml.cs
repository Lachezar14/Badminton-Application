using System.Security.Claims;
using Entities;
using Entities.DTOs;
using Entities.ENums;
using LogicLayer.Interfaces;
using LogicLayer.Utilities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SynthesisWeb.Pages
{
    public class RegisterModel : PageModel
    {
        private IUserManager _userManager;
        private PasswordHasher _passwordHasher = new PasswordHasher();

        public RegisterModel(IUserManager userManager)
        {
            _userManager = userManager;
        }

        [BindProperty]
        public PlayerDTO Player { get; set; }

        public Player User { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPostRegister()
        {
            if(ModelState.IsValid)
            {
                Player.Password = _passwordHasher.HashPassword(Player.Password);
                User = new Player(Player);
                
                try
                {
                    _userManager.AddUser(User); 
                    return RedirectToPage("Login");
                }
                catch (ArgumentException ex)
                {
                    ViewData["ErrorMessage"] = ex.Message;
                    return Page();
                }
            }
            else
            {
                ViewData["ErrorMessage"] = "Please fill in the fields";
                return Page();
            }
        }
    }
}
