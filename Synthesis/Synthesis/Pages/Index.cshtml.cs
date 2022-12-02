using Entities;
using LogicLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Synthesis.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private IUserManager _userManager;

        public IndexModel(ILogger<IndexModel> logger,IUserManager userManager)
        {
            _logger = logger;
            _userManager = userManager;
        }

        [BindProperty]
        public Player Player { get; set; }

        public void OnGet()
        {
            int? id = HttpContext.Session.GetInt32("User_Id");
            if (id != null)
            {
                Player = (Player)_userManager.GetUser((int)id);
            }
        }
    }
}