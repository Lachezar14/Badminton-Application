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
using LogicLayer.Interfaces;

namespace SynthesisDesktop
{
    public partial class MatchResultCreation : Form
    {
        private IMatchManager _matchManager;
        private IUserManager _userManager;
        private AMatch match;
        private Form1 form;

        public MatchResultCreation(IMatchManager matchManager, IUserManager userManager,AMatch match, Form1 form)
        {
            this.match = match;
            this._matchManager = matchManager;
            this._userManager = userManager;
            InitializeComponent();
            tbMatch.Text = $"{match.Player1} vs {match.Player2}";
            Update();
            this.form = form;
        }

        public void Update()
        {
            if (match.Player1_Score != 0 || match.Player2_Score != 0)
            {
                tbPlayer1Score.Text = match.Player1_Score.ToString();
                tbPlayer2Score.Text = match.Player2_Score.ToString();
                btnAddResult.Visible = false;
                btnUpdateResult.Visible = true;
            }
            else
            {
                btnAddResult.Visible = true;
                btnUpdateResult.Visible = false;
            }
        }

        private void btnAddResult_Click(object sender, EventArgs e)
        {
            try
            {
                match.Result(Convert.ToInt32(tbPlayer1Score.Text), Convert.ToInt32(tbPlayer2Score.Text));
                
                Player player1 = (Player)match.Player1;
                Player player2 = (Player)match.Player2;

                if (Convert.ToInt32(tbPlayer1Score.Text) > Convert.ToInt32(tbPlayer2Score.Text))
                {
                    _userManager.IsWinner(player1);
                    _userManager.IsLoser(player2);
                    _matchManager.UpdateMatch(match);
                    MessageBox.Show("Result added");
                    this.Close();
                }
                else if (Convert.ToInt32(tbPlayer1Score.Text) < Convert.ToInt32(tbPlayer2Score.Text))
                {
                    _userManager.IsWinner(player2);
                    _userManager.IsLoser(player1);
                    _matchManager.UpdateMatch(match);
                    MessageBox.Show("Result added");
                    this.Close();
                }
                else if (Convert.ToInt32(tbPlayer1Score.Text) == Convert.ToInt32(tbPlayer2Score.Text))
                {
                    MessageBox.Show("Result cannot be a draw");
                }
            }
            catch(ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void btnUpdateResult_Click(object sender, EventArgs e)
        {
            try
            {
                match.Result(Convert.ToInt32(tbPlayer1Score.Text), Convert.ToInt32(tbPlayer2Score.Text));

                if (Convert.ToInt32(tbPlayer1Score.Text) == Convert.ToInt32(tbPlayer2Score.Text))
                {
                    MessageBox.Show("Result cannot be a draw");
                }
                else
                {
                    _matchManager.UpdateMatch(match);
                    MessageBox.Show("Result updated");
                    this.Close();
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

        private void MatchResultCreation_FormClosed(object sender, FormClosedEventArgs e)
        {
            form.CreateSchedule();
        }
    }
}
