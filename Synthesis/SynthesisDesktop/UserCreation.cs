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
using LogicLayer.Utilities;

namespace SynthesisDesktop
{
    public partial class UserCreation : Form
    {
        private IUserManager _userManager;
        private Form1 form;
        private PasswordHasher _passwordHasher = new PasswordHasher();
        public UserCreation(IUserManager userManager, Form1 form)
        {
            _userManager = userManager;
            this.form = form;
            InitializeComponent();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            var password = _passwordHasher.HashPassword(tbPassword.Text);

            try
            {
                if (cbAccountType.SelectedIndex == 0)
                {
                    User user = new Player(tbFName.Text, tbLName.Text, tbEmail.Text, tbPhone.Text, AccountType.Player,
                        tbUsername.Text, password, 0, 0);
                    _userManager.AddUser(user);
                    MessageBox.Show("User has been created");
                    this.Close();
                }
                else if (cbAccountType.SelectedIndex == 1)
                {
                    User user = new Employee(tbFName.Text, tbLName.Text, tbEmail.Text, tbPhone.Text,
                        AccountType.Employee, tbUsername.Text, password);
                    _userManager.AddUser(user);
                    MessageBox.Show("User has been created");
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

        private void UserCreation_FormClosed(object sender, FormClosedEventArgs e)
        {
            form.UpdateUsers();
        }
    }
}
