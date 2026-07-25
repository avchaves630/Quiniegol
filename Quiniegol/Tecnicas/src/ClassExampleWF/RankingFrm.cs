using ClassExampleController;
using System.Windows.Forms;

namespace ClassExampleWF
{
    /// <summary>
    /// Ranking Form.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class RankingFrm : Form
    {
        /// <summary>
        /// Gets or sets the user controller.
        /// </summary>
        /// <value>
        /// The user controller.
        /// </value>
        public UserController UserController { get; set; }

        private RankingController RankingController { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="RankingFrm"/> class.
        /// </summary>
        /// <param name="userController">The user controller.</param>
        public RankingFrm(UserController userController)
        {
            InitializeComponent();
            this.UserController = userController;
            this.RankingController = new RankingController(userController);

            this.dataGridView1.Columns.Add("Name", "Name");
            this.dataGridView1.Columns.Add("Score", "Score");

            this.LoadGrid();
        }

        private void LoadGrid()
        {
            var rankingList = this.RankingController.GetRankingByScoreDesc();
            foreach (var user in rankingList)
            {
                this.dataGridView1.Rows.Add(user.Name, user.Score);
            }
        }

    }
}
