using System;

namespace ClassExampleModels
{
    /// <summary>
    /// Model for User entity.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="User"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <param name="email">The email.</param>
        /// <param name="score">The score.</param>
        public User(string name, string username, string password, string email, string score)
        {
            this.Name = name;
            this.Username = username;
            this.Password = password;
            this.Email = email;
            this.Score = int.Parse(score);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="User"/> class.
        /// </summary>
        /// <param name="props">The props.</param>
        public User(string[] props)
        {
            this.Name = props[0];
            this.Username = props[1];
            this.Password = props[2];
            this.Email = props[3];
            this.Score = int.Parse(props[4]);
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        /// <value>
        /// The username.
        /// </value>
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the score.
        /// </summary>
        /// <value>
        /// The score.
        /// </value>
        public int Score { get; set; }
    }
}
