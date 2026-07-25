using ClassExampleModels;
using System.Collections.Generic;
using System.Linq;

namespace ClassExampleController
{
    /// <summary>
    /// Controller for the ranking view operations.
    /// </summary>
    public class RankingController
    {
        /// <summary>
        /// Gets or sets the user controller.
        /// </summary>
        /// <value>
        /// The user controller.
        /// </value>
        public UserController UserController { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="RankingController"/> class.
        /// </summary>
        /// <param name="userController">The user controller.</param>
        public RankingController(UserController userController)
        {
            UserController = userController;
        }

        /// <summary>
        /// Gets the ranking of the users by Score Desc.
        /// </summary>
        /// <returns>sorted list by ranking desc.</returns>
        public List<User> GetRankingByScoreDesc()
        {
            return this.UserController.Users.OrderByDescending(u => u.Score).ToList();
        }

        /// <summary>
        /// Gets the top3 scorer.
        /// </summary>
        /// <returns></returns>
        public List<User> GetTop3Scorer()
        {
            var orderedList = this.GetRankingByScoreDesc();

            var result = new List<User>()
            {
                orderedList[0],
                orderedList[1],
                orderedList[2],
            };

            return result;
        }
    }
}
