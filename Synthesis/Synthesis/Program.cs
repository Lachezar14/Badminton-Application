using DAL.Interfaces;
using DAL.Repositories;
using LogicLayer.Interfaces;
using LogicLayer.Managers;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();


builder.Services.AddSession(options =>
{
    options.Cookie.Name = "SubwayCookie";
    options.IdleTimeout = TimeSpan.FromMinutes(20);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
        {
            options.LoginPath = new PathString("/path-to-login");

        }
    );

builder.Services.AddSingleton<IUserRepository>(new UserRepository());
builder.Services.AddSingleton<IMatchRepository>(new MatchRepository());
builder.Services.AddSingleton<ITournamentRepository>(new TournamentRepository());

IUserRepository _userRepository = new UserRepository();
IMatchRepository _matchRepository = new MatchRepository();
ITournamentRepository _tournamentRepository = new TournamentRepository();

builder.Services.AddScoped<IAuthenticationManager, AuthenticationManager>();
builder.Services.AddScoped<IUserManager, UserManager>();
builder.Services.AddScoped<IMatchManager, MatchManager>();
builder.Services.AddScoped<ITournamentManager , TournamentManager>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseSession();

app.UseAuthentication();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
