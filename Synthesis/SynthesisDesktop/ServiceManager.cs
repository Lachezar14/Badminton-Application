using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using DAL.Repositories;
using LogicLayer.Interfaces;
using LogicLayer.Managers;
using Microsoft.Extensions.DependencyInjection;


namespace SynthesisDesktop
{
    public class ServiceManager
    {
        //This is done because if we have to change an implementation of a class, we only have to change it in one place.
        //This is what dependency injection is all about.
        public static IServiceProvider Get() //returns an object that implements IServiceProvider
        {
            //Service is a long-running application that can be started automatically when your system is started.You can pause and restart the service.
            var services = new ServiceCollection(); //list which contains all the services

            //Because managers classes have database classes interfaces passed in their constructors,when we get an object of a manager class,
            //we pass the database class object as well.
            //This singletons create only one object of managers that the program uses.

            //Singleton is a class which only allows a single instance of itself to be created,
            //and usually gives simple access to that instance.

          
            services.AddSingleton<IAuthenticationManager, AuthenticationManager>();
            services.AddSingleton<IUserManager, UserManager>();
            services.AddSingleton<IMatchManager, MatchManager>();
            services.AddSingleton<ITournamentManager, TournamentManager>();


            services.AddSingleton<IUserRepository, UserRepository>();
            services.AddSingleton<IMatchRepository, MatchRepository>();
            services.AddSingleton<ITournamentRepository, TournamentRepository>();

            return services.BuildServiceProvider(); //returns a provider with configurations from above
        }
    }
}
