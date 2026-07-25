using ClassExampleController;
using System;
using System.Windows.Forms;

namespace ClassExampleWF
{
    /// <summary>
    /// Main form for the application.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class MainForm : Form
    {
        public UserController UserController { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MainForm"/> class.
        /// </summary>
        public MainForm(UserController userController)
        {
            InitializeComponent();
            this.UserController = userController;
        }

        private void btnExamples_Click(object sender, EventArgs e)
        {
            var examplesFrm = new ExamplesFrm(new ClassExampleController.ExamplesController(new ClassExampleController.Examples()));
            examplesFrm.Show();
        }

        private void btnMantainance_Click(object sender, EventArgs e)
        {
            var userMantainanceFrm = new UserMantainance(UserController);
            userMantainanceFrm.Show();
        }

        private void btnRanking_Click(object sender, EventArgs e)
        {
            var rankingFrm = new RankingFrm(UserController);
            rankingFrm.Show();
        }
    }
}
