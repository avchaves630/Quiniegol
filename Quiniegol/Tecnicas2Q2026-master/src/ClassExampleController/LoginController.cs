using ClassExampleModels;

namespace ClassExampleController
{
    /// <summary>
    /// Controller for the login operations.
    /// </summary>
    public class LoginController
    {
        public UserController UserController { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="LoginController"/> class.
        /// </summary>
        /// <param name="userController">The user controller.</param>
        public LoginController(UserController userController)
        {
            this.UserController = userController;
            this.UserController.Load(GeneralConfig.UsersFile);
        }

        /// <summary>
        /// Logins the specified user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="password">The password.</param>
        /// <returns>True if there is a success login, otherwise false.</returns>
        public bool Login(string user, string password)
        {
            foreach (var element in UserController.Users)
            {
                if ((element.Username == user || element.Email == user) && element.Password == password)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Registers the specified name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <param name="email">The email.</param>
        /// <returns>True if the user was created, otherwise false.</returns>
        public bool Register(string name, string username, string password, string email)
        {
            var newUser = new User(name, username, password, email, "0");
            return this.UserController.SaveUser(newUser);
        }
    }
}
