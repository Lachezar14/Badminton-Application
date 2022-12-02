using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LogicLayer.Interfaces;

namespace SynthesisDesktop
{
    public partial class Login : Form
    {
        private IAuthenticationManager _authenticationManager;
        private IUserManager _userManager;
        private ITournamentManager _tournamentManager;
        private IMatchManager _matchManager;

        public Login(IAuthenticationManager authenticationManager, IUserManager userManager, ITournamentManager tournamentManager, IMatchManager matchManager)
        {
            _authenticationManager = authenticationManager;
            _userManager = userManager;
            _tournamentManager = tournamentManager;
            _matchManager = matchManager;
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (_authenticationManager.AuthenticateEmployee(tbUsername.Text, tbPassword.Text) != -1)
            {
                Form1 main = new Form1(_authenticationManager,_userManager,_matchManager,_tournamentManager);
                main.Show();
                this.Hide();
            }
            else
            {
                lbWrongInput.Visible = true;
                lbWrongInput.Text = "Wrong username or password";
            }
        }

        private void cbShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (cbShowPassword.Checked)
            {
                tbPassword.UseSystemPasswordChar = false;
            }
            else
            {
                tbPassword.UseSystemPasswordChar = true;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
