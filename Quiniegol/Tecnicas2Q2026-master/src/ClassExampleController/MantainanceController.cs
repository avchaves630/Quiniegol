using System.Runtime.Remoting.Messaging;

namespace ClassExampleController
{
    /// <summary>
    /// Controller for Mantainance view operations.
    /// </summary>
    public class MantainanceController
    {
        /// <summary>
        /// Gets or sets the user controller.
        /// </summary>
        /// <value>
        /// The user controller.
        /// </value>
        public UserController UserController { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MantainanceController"/> class.
        /// </summary>
        /// <param name="userController">The user controller.</param>
        public MantainanceController(UserController userController)
        {
            UserController = userController;
        }

        /// <summary>
        /// Updates the score.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="score">The score.</param>
        /// <returns></returns>
        public bool UpdateScore(string username, int score)
        {
            if (UserController == null && score >= 0)
            {
                return false;
            }
            
            return UserController.UpdateScore(username, score);
        }
    }
}
