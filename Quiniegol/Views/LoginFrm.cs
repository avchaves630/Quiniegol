using Quiniegol.Controllers;
using Quiniegol.Models;
using Quiniegol.Utils;
using System;
using System.Windows.Forms;

namespace Quiniegol.Views
{
    /// <summary>
    /// Formulario de inicio de sesión de la aplicación.
    /// </summary>
    public partial class LoginFrm : Form
    {
        private LoginController LoginController { get; set; }
        private MatchController MatchController { get; set; }
        private PredictionController PredictionController { get; set; }
        private QuinielaController QuinielaController { get; set; }

        public LoginFrm()
        {
            InitializeComponent();
        }

        public LoginFrm(LoginController loginController, MatchController matchController, PredictionController predictionController, QuinielaController quinielaController)
            : this()
        {
            this.LoginController = loginController;
            this.MatchController = matchController;
            this.PredictionController = predictionController;
            this.QuinielaController = quinielaController;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var user = txtUser.Text.Trim();
            var password = txtPassword.Text;

            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Por favor complete todos los campos.");
                return;
            }

            var isPasswordValid = InputValidation.ValidatePassword(password);
            if (!isPasswordValid)
            {
                MessageBox.Show("La contraseña debe tener al menos 3 caracteres y por lo menos un número.");
                return;
            }

            var loginSuccess = LoginController.Login(user, password);

            if (loginSuccess)
            {
                var loggedInUser = LoginController.UserController.FindUser(user);

                PredictionController.RecomputeAllUserScores(LoginController.UserController, MatchController.Matches);
                LoginController.UserController.RecalculateInsignias(PredictionController.Predictions, MatchController.Matches, QuinielaController.Quinielas);

                MessageBox.Show($"¡Inicio de sesión exitoso! Bienvenido {loggedInUser.Name}");

                var mainFrm = new MainDashboardFrm(loggedInUser, LoginController.UserController, MatchController, PredictionController, QuinielaController);
                mainFrm.Show();
                this.Hide();

                mainFrm.FormClosed += (s, args) => this.Close();
            }
            else
            {
                MessageBox.Show("Nombre de usuario o contraseña incorrectos.");
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            var registerFrm = new RegisterFrm(LoginController, MatchController.Teams);
            registerFrm.ShowDialog();
        }
    }
}
