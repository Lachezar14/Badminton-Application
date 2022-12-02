using Entities;
using LogicLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SynthesisWeb.Pages
{
    public class TournamentsModel : PageModel
    {
        private IUserManager _userManager;
        private ITournamentManager _tournamentManager;

        public List<Tournament> Tournaments = new List<Tournament>();

        public TournamentsModel(IUserManager userManager,ITournamentManager tournamentManager)
        {
            _userManager = userManager;
            _tournamentManager = tournamentManager;
        }

        [BindProperty]
        public User Player { get; set; }

        public void OnGet()
        {
            Tournaments = _tournamentManager.GetAllTournaments();

            int? id = HttpContext.Session.GetInt32("User_Id");
            if (id != null)
            {
                Player = _userManager.GetUser((int)id);
            }
        }

        public IActionResult OnPostJoin(int id)
        {
            int? playerId = HttpContext.Session.GetInt32("User_Id");
            if (playerId != null)
            {
                Player = _userManager.GetUser((int)playerId);
            }

            Tournament tournament = _tournamentManager.GetTournament(id);
            if (tournament.Players.Count != tournament.MaxPlayers)
            {
                _tournamentManager.AddPlayerToTournament(tournament,Player);
            }
            else
            {
                ViewData["ErrorMessage"] = "Tournament is full";
            }
            return new RedirectToPageResult("Tournaments");
        }

        public IActionResult OnPostLeave(int id)
        {
            int? playerId = HttpContext.Session.GetInt32("User_Id");
            if (playerId != null)
            {
                Player = _userManager.GetUser((int)playerId);
            }

            Tournament tournament = _tournamentManager.GetTournament(id);
            _tournamentManager.RemovePlayerFromTournament(tournament, Player);
            return new RedirectToPageResult("Tournaments");
        }
    }
}
