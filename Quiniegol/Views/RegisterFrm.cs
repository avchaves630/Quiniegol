using Quiniegol.Controllers;
using Quiniegol.Models;
using Quiniegol.Utils;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Quiniegol.Views
{
    /// <summary>
    /// Formulario de registro de usuarios.
    /// </summary>
    public partial class RegisterFrm : Form
    {
        private LoginController LoginController { get; set; }

        public RegisterFrm(LoginController loginController, List<Team> teams)
        {
            InitializeComponent();
            this.LoginController = loginController;

            cmbCountry.Items.Clear();
            foreach (var team in teams)
            {
                cmbCountry.Items.Add(team.Name);
            }
            if (cmbCountry.Items.Count > 0)
            {
                cmbCountry.SelectedIndex = 0;
            }
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var name = txtName.Text.Trim();
            var username = txtUsername.Text.Trim();
            var email = txtEmail.Text.Trim();
            var password = txtPassword.Text;
            var preferredCountry = cmbCountry.SelectedItem?.ToString();

            if (!InputValidation.ValidateString(name, "El nombre completo es requerido.")) return;
            if (!InputValidation.ValidateString(username, "El nombre de usuario es requerido.")) return;
            if (!InputValidation.ValidateString(email, "El correo electrónico es requerido.")) return;
            if (!InputValidation.ValidateString(password, "La contraseña es requerida.")) return;
            if (string.IsNullOrEmpty(preferredCountry))
            {
                MessageBox.Show("Por favor seleccione un país preferido.");
                return;
            }

            if (!email.IsGmail())
            {
                MessageBox.Show("El correo electrónico debe ser una cuenta de Gmail (@gmail.com).");
                return;
            }

            if (!InputValidation.ValidatePassword(password))
            {
                MessageBox.Show("La contraseña debe tener más de 3 caracteres y al menos un dígito numérico.");
                return;
            }

            var success = LoginController.Register(name, username, password, email, preferredCountry);

            if (success)
            {
                MessageBox.Show("¡Registro de usuario exitoso! Ahora puede iniciar sesión.");
                this.Close();
            }
            else
            {
                MessageBox.Show("No se pudo registrar. Es posible que el nombre de usuario o correo ya estén en uso.");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
