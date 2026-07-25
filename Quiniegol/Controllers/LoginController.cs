using Quiniegol.Models;
using System;

namespace Quiniegol.Controllers
{
    /// <summary>
    /// Controlador para las operaciones de inicio de sesión y registro de usuarios.
    /// </summary>
    public class LoginController
    {
        public UserController UserController { get; set; }

        public LoginController(UserController userController)
        {
            this.UserController = userController;
        }

        /// <summary>
        /// Autentica a un usuario mediante nombre de usuario o correo y contraseña.
        /// </summary>
        public bool Login(string user, string password)
        {
            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(password))
            {
                return false;
            }

            var element = this.UserController.FindUser(user);
            if (element != null && element.Password == password)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Registra un nuevo usuario en el sistema.
        /// </summary>
        public bool Register(string name, string username, string password, string email, string preferredCountry)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(email))
            {
                return false;
            }

            var existingUser = this.UserController.FindUser(username);
            var existingEmail = this.UserController.FindUser(email);
            if (existingUser != null || existingEmail != null)
            {
                return false;
            }

            var newUser = new User(name, username, password, email, "0", preferredCountry);
            return this.UserController.SaveUser(newUser);
        }
    }
}
