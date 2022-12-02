using Entities;
using LogicLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SynthesisWeb.Pages
{
    public class ResultsModel : PageModel
    {
        private ITournamentManager _tournamentManager;
        private IUserManager _userManager;
        private IMatchManager _matchManager;
        public List<AMatch> Matches = new List<AMatch>();

        public ResultsModel(ITournamentManager tournamentManager, IUserManager userManager, IMatchManager matchManager)
        {
            _tournamentManager = tournamentManager;
            _userManager = userManager;
            _matchManager = matchManager;
        }

        [BindProperty]
        public User Player { get; set; }

        public Tournament Tournament { get; set; }

        public Dictionary<User, int> PlayerWins { get; set; } = new Dictionary<User, int>();
        
        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        public void OnGet()
        {
            int? id = HttpContext.Session.GetInt32("User_Id");
            if (id != null)
            {
                Player = _userManager.GetUser((int)id);
            }

            Tournament = _tournamentManager.GetTournament(Id);

            Matches = _matchManager.GetAllMatchesPerTournament(Tournament);

            foreach (var p in Tournament.Players)
            {
                PlayerWins.Add(p, _userManager.GetPlayersWinsPerTournament(Tournament, p));
            }
        }

        public void OnPost(){}
    }
}
