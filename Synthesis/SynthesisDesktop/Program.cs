using LogicLayer.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace SynthesisDesktop
{
    internal static class Program
    {
        private static readonly IServiceProvider _provider = ServiceManager.Get(); //gets an instance of the IServiceProvider and gets the list of services.

        [STAThread]
        static void Main()
        {
            //service is a implementation
            var authenticationManager = _provider.GetService<IAuthenticationManager>();
            var userManager = _provider.GetService<IUserManager>();
            var matchManager = _provider.GetService<IMatchManager>();
            var tournamentManager = _provider.GetService<ITournamentManager>();

            Application.EnableVisualStyles();
            ApplicationConfiguration.Initialize();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1(userManager,matchManager,tournamentManager));
            Application.Run(new Login(authenticationManager,userManager,tournamentManager,matchManager));
        }
    }
}