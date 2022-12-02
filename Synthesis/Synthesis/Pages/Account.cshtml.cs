using Entities;
using Entities.DTOs;
using Entities.ENums;
using LogicLayer.Interfaces;
using LogicLayer.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SynthesisWeb.Pages
{
    [Authorize]
    public class AccountModel : PageModel
    {
        private IUserManager _userManager;
        private ITournamentManager _tournamentManager;
        private PasswordHasher _passwordHasher = new PasswordHasher();
        public List<Tournament> Tournaments = new List<Tournament>();

        public AccountModel(IUserManager userManager, ITournamentManager tournamentManager)
        {
            _userManager = userManager;
            _tournamentManager = tournamentManager;
        }

        [BindProperty]
        public string OldPassword { get; set; }

        [BindProperty]
        public string NewPassword { get; set; }

        [BindProperty]
        public PlayerDTO Player { get; set; }

        public Player User { get; set; }

        public void OnGet()
        {
            int? id = HttpContext.Session.GetInt32("User_Id");
            if (id != null)
            {
                User = (Player)_userManager.GetUser((int)id);
            }

            Tournaments = _tournamentManager.GetAllTournamentsPerPlayer(User);
        }

        public IActionResult OnPostUpdate(int id)
        {
            Player user = (Player)_userManager.GetUser(id);
            User newUser = new Player(user.Id, Player.FName, Player.LName, Player.Email, Player.Phone, AccountType.Player, Player.Username, user.Password, user.Wins, user.Losses);

            _userManager.UpdateUser(newUser);
            return Redirect("?success");
        }

        public IActionResult OnPostChangePassword(int id)
        {
            User user = _userManager.GetUser(id);
            if (OldPassword != null)
            {
                if (_passwordHasher.ValidateHashedPassword(OldPassword, user.Password))
                {
                    var password = _passwordHasher.HashPassword(NewPassword);
                    _userManager.UpdateUserPassword(user, password);
                    return Redirect("?nice");
                }
                else
                {
                    return Redirect("?nope");
                }
            }
            else
            {
                return Redirect("?nope");
            }
        }

        public IActionResult OnPostLogOut()
        {
            HttpContext.Session.Clear();
            return new RedirectToPageResult("Index");
        }
    }
}
