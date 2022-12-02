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
    public partial class TournamentCreation : Form
    {
        private ITournamentManager _tournamentManager;
        private Form1 form;

        public TournamentCreation(ITournamentManager tournamentManager, Form1 form)
        {
            _tournamentManager = tournamentManager;
            InitializeComponent();
            this.form = form;
        }

        private void btnCreateTournament_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(tbMinPlayers.Text) < Convert.ToInt32(tbMaxPlayers.Text))
                {
                    if (cbTournamentType.SelectedIndex == 0)
                    {
                        Tournament tournament = new RoundRobin(SportType.Badminton, tbTournamentDesc.Text,
                            tbLocation.Text,
                            TournamentType.RoundRobin,
                            Convert.ToDateTime(dtStartDate.Text), Convert.ToDateTime(dtEndDate.Text),
                            Convert.ToInt32(tbMinPlayers.Text), Convert.ToInt32(tbMaxPlayers.Text));
                        _tournamentManager.AddTournament(tournament);
                    }
                    else if (cbTournamentType.SelectedIndex == 1)
                    {
                        Tournament tournament = new DoubleRoundRobin(SportType.Badminton, tbTournamentDesc.Text,
                            tbLocation.Text, TournamentType.DoubleRoundRobin,
                            Convert.ToDateTime(dtStartDate.Text), Convert.ToDateTime(dtEndDate.Text),
                            Convert.ToInt32(tbMinPlayers.Text), Convert.ToInt32(tbMaxPlayers.Text));
                        _tournamentManager.AddTournament(tournament);
                    }

                    MessageBox.Show("Tournament has been created");
                    this.Close();
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TournamentCreation_FormClosed(object sender, FormClosedEventArgs e)
        {
            form.UpdateTournaments();
        }
    }
}
