using Entities;
using LogicLayer.Interfaces;
using LogicLayer.Managers;

namespace SynthesisDesktop
{
    public partial class Form1 : Form
    {
        private IAuthenticationManager _authenticationManager;
        private IUserManager _userManager;
        private IMatchManager _matchManager;
        private ITournamentManager _tournamentManager;

        public Form1(IAuthenticationManager authenticationManager,IUserManager userManager,IMatchManager matchManager,ITournamentManager tournamentManager)
        {
            InitializeComponent();
            _authenticationManager = authenticationManager;
            _userManager = userManager;
            _matchManager = matchManager;
            _tournamentManager = tournamentManager;

      
            UpdateUsers();

            UpdateTournaments();
            
            cbTournamentSchedule.DataSource = _tournamentManager.GetAllTournaments();
            cbTournamentSchedule.DisplayMember = "Description";
            
        }

        public void UpdateTournaments()
        {
            _tournamentManager.ResetAllTournaments();
            lbTournaments.DataSource = _tournamentManager.GetAllTournaments();
        }

        public void UpdateUsers()
        {
            _userManager.ResetAllUsers();
            lbUsers.DataSource = _userManager.GetAllUsers();
        }

        
        private void btnTournaments_Click(object sender, EventArgs e)
        {
            stackPanel.SelectedTab = tpTournaments;
            UpdateTournaments();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            stackPanel.SelectedTab = tpHome;
        }

        private void btnSchedule_Click(object sender, EventArgs e)
        {
            stackPanel.SelectedTab = tpSchedule;
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            stackPanel.SelectedTab = tpUsers;
            UpdateUsers();
        }

        private void btnMatchResult_Click(object sender, EventArgs e)
        {
            AMatch match = (AMatch)lbSchedule.SelectedValue; 
            MatchResultCreation matchResultCreation = new MatchResultCreation(_matchManager,_userManager,match,this);
            if (match.Tournament.EndDate < DateTime.Now)
            {
                MessageBox.Show("Tournament has finished.");
            }
            else if (match.Tournament.StartDate > DateTime.Now)
            {
                MessageBox.Show("Tournament has not started yet");
            }
            else
            {
                matchResultCreation.Show();
            }
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            UserCreation userCreation = new UserCreation(_userManager,this);
            userCreation.Show();
        }

        private void btnUpdateUser_Click(object sender, EventArgs e)
        {
            if (lbUsers.SelectedValue != null)
            {
                User user = (User)lbUsers.SelectedValue;
                UserModification userModification = new UserModification(_userManager,user,this);
                userModification.Show();
            }
        }

        private void btnAddTournament_Click(object sender, EventArgs e)
        {
            TournamentCreation tournamentCreation = new TournamentCreation(_tournamentManager,this);
            tournamentCreation.Show();
            UpdateTournaments();
        }

        private void btnUpdateTournament_Click(object sender, EventArgs e)
        {
            if (lbTournaments.SelectedValue != null)
            {
                Tournament tournament = (Tournament)lbTournaments.SelectedValue;
                if (DateTime.Now > tournament.EndDate)
                {
                    MessageBox.Show("Tournament has finished.");
                }
                else
                {
                    TournamentManagement tournamentManagement =
                        new TournamentManagement(_tournamentManager, tournament, this);
                    tournamentManagement.Show();
                }
            }
            else
            {
                MessageBox.Show("Please select a tournament");
            }
        }

        public void CreateSchedule()
        {
            Tournament tournament = (Tournament)cbTournamentSchedule.SelectedValue;
            _tournamentManager.CreateSchedule(tournament);
            lbSchedule.DataSource = _matchManager.GetAllMatchesPerTournament(tournament);
        }

        private void btnCreateSchedule_Click(object sender, EventArgs e)
        {
            Tournament tournament = (Tournament)cbTournamentSchedule.SelectedValue;
            if ((tournament.StartDate - DateTime.Now).TotalDays < 7)
            { 
                CreateSchedule();
            }
            else
            {
               MessageBox.Show("Schedule can be made 7 days before the start of the tournament at the earliest");
            }
        }

        private void btnDeleteSchedule_Click(object sender, EventArgs e)
        {
            Tournament tournament = (Tournament)cbTournamentSchedule.SelectedValue;
            foreach (AMatch match in _matchManager.GetAllMatchesPerTournament(tournament))
            {
                _matchManager.DeleteMatch(match.Id);
            }

            lbSchedule.DataSource = null;
            lbSchedule.Items.Clear();
        }

        private void lbSchedule_SelectedIndexChanged(object sender, EventArgs e)
        {
                
        }

        private void lbTournaments_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lbTournaments.SelectedItem != null)
            {
               Tournament tournament = (Tournament)lbTournaments.SelectedValue;
               MessageBox.Show(
                   $"Description:{tournament.Description} \n Sport Type:{tournament.SportType} \n Tournament Type:{tournament.TournamentType} \n" +
                   $"Start Date:{tournament.StartDate.ToString("d")} \n End Date:{tournament.EndDate.ToString("d")} \n Players:[{tournament.Players.Count}/{tournament.MaxPlayers}]");
            }
        }

        private void btnSignOut_Click(object sender, EventArgs e)
        {
           
            Login login = new Login(_authenticationManager,_userManager,_tournamentManager,_matchManager);
            login.Show();
            this.Close();
        }
    }
}