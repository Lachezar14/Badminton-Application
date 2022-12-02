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
    public partial class UserModification : Form
    {
        private IUserManager _userManager;
        private User user;
        private Form1 form;
        private PasswordHasher _passwordHasher = new PasswordHasher();

        public UserModification(IUserManager userManager,User user, Form1 form)
        {
            _userManager = userManager;
            this.user = user;
            this.form = form;
            InitializeComponent();
            Info();
        }

        public void Info()
        {
            tbId.Text = user.Id.ToString();
            tbFName.Text = user.FName;
            tbLName.Text = user.LName;
            tbEmail.Text = user.Email;
            tbPhone.Text = user.Phone;
            cbAccountType.Text = user.Type.ToString();
            tbUsername.Text = user.Username;
        }

        private void cbAccountType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnUpdateUser_Click(object sender, EventArgs e)
        {
            try
            {
                User user = new User(Convert.ToInt32(tbId.Text), tbFName.Text, tbLName.Text, tbEmail.Text, tbPhone.Text,
                    Enum.Parse<AccountType>(cbAccountType.SelectedItem.ToString()), tbUsername.Text,
                    this.user.Password);
                _userManager.UpdateUser(user);
                MessageBox.Show("User has been updated");
                this.Close();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            _userManager.DeleteUser(Convert.ToInt32(tbId.Text));
            MessageBox.Show("User has been deleted");
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                if (_passwordHasher.ValidateHashedPassword(tbOldPassword.Text, user.Password))
                {
                    var password = _passwordHasher.HashPassword(tbNewPassword.Text);
                    _userManager.UpdateUserPassword(user, password);
                    MessageBox.Show("Password changed successfully");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Wrong old password.");
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UserModification_FormClosed(object sender, FormClosedEventArgs e)
        {
            form.UpdateUsers();
        }
    }
}
