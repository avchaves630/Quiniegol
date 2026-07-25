using ClassExampleController;
using ClassExampleWF.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClassExampleWF
{
    /// <summary>
    /// Login View representation.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class LoginFrm : Form
    {
        private LoginController LoginController;

        /// <summary>
        /// Initializes a new instance of the <see cref="LoginFrm"/> class.
        /// </summary>
        /// <param name="loginController">The login controller.</param>
        public LoginFrm(LoginController loginController)
        {
            InitializeComponent();
            this.LoginController = loginController;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var user = txtUser.Text;
            var password = txtPassword.Text;

            var isGmail = user.IsGmail();

            var isPasswordValid = InputValidation.ValidatePassword(password);

            if (isPasswordValid)
            {
                var login = LoginController.Login(user, password);

                if (login)
                {
                    MessageBox.Show("Login success");
                    var mainFrm = new MainForm(LoginController.UserController);
                    mainFrm.Show();
                }
                else
                {
                    MessageBox.Show("Try again jaja");
                }
            }
            else
            {
                MessageBox.Show("Password should have more than 3 chars and at least a number");
            }
        }
    }
}
