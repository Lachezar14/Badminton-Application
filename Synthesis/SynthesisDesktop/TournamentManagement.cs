using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entities;
using Entities.ENums;
using LogicLayer.Interfaces;

namespace SynthesisDesktop
{
    public partial class TournamentManagement : Form
    {
        private ITournamentManager _tournamentManager;
        private Tournament tournament;
        private Form1 form;

        public TournamentManagement(ITournamentManager tournamentManager,Tournament tournament,Form1 form)
        {
            _tournamentManager = tournamentManager;
            this.tournament = tournament;
            this.form = form;
            InitializeComponent();
            Info();
        }

        public void Info()
        {
            tbTournament_Id.Text = tournament.Id.ToString();
            cbSportType.Text = tournament.SportType.ToString();
            tbTournamentDesc.Text = tournament.Description;
            tbLocation.Text = tournament.Location;
            cbTournamentType.Text = tournament.TournamentType.ToString();
            dtStartDate.Value = tournament.StartDate;
            dtEndDate.Value = tournament.EndDate;
            tbMinPlayers.Text = tournament.MinPlayers.ToString();
            tbMaxPlayers.Text = tournament.MaxPlayers.ToString();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdateTournament_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(tbMinPlayers.Text) < Convert.ToInt32(tbMaxPlayers.Text))
                {
                    if (cbTournamentType.SelectedIndex == 0)
                    {
                        Tournament tournament = new RoundRobin(Convert.ToInt32(tbTournament_Id.Text),
                            SportType.Badminton, tbTournamentDesc.Text, tbLocation.Text,
                            TournamentType.RoundRobin,
                            Convert.ToDateTime(dtStartDate.Text), Convert.ToDateTime(dtEndDate.Text),
                            Convert.ToInt32(tbMinPlayers.Text), Convert.ToInt32(tbMaxPlayers.Text),
                            this.tournament.Players);
                        _tournamentManager.UpdateTournament(tournament);
                        MessageBox.Show("Tournament has been modified");
                        this.Close();
                    }
                    else if (cbTournamentType.SelectedIndex == 1)
                    {
                        Tournament tournament = new DoubleRoundRobin(Convert.ToInt32(tbTournament_Id.Text),
                            SportType.Badminton, tbTournamentDesc.Text,
                            tbLocation.Text, TournamentType.DoubleRoundRobin,
                            Convert.ToDateTime(dtStartDate.Text), Convert.ToDateTime(dtEndDate.Text),
                            Convert.ToInt32(tbMinPlayers.Text), Convert.ToInt32(tbMaxPlayers.Text),
                            this.tournament.Players);
                        _tournamentManager.UpdateTournament(tournament);
                        MessageBox.Show("Tournament has been modified");
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Tournament min players must be less than the max players");
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDeleteTournament_Click(object sender, EventArgs e)
        {
            _tournamentManager.DeleteTournament(Convert.ToInt32(tbTournament_Id.Text));
            MessageBox.Show("Tournament has been deleted");
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TournamentManagement_FormClosed(object sender, FormClosedEventArgs e)
        {
            form.UpdateTournaments();
        }
    }
}
