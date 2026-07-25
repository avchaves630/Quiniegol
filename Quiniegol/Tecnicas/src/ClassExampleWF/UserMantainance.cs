using ClassExampleController;
using ClassExampleModels;
using ClassExampleWF.Utils;
using System.Windows.Forms;

namespace ClassExampleWF
{
    /// <summary>
    /// Form to maintain users score.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class UserMantainance : Form
    {
        private int currentIndex = 0;

        /// <summary>
        /// Gets or sets the user controller.
        /// </summary>
        /// <value>
        /// The user controller.
        /// </value>
        public UserController UserController { get; set; }

        private User CurrentUser
        {
            get
            {
                if (this.UserController.Users.Count == 0)
                {
                    return null;
                }

                return this.UserController.Users[currentIndex];
            }
        }

        private MantainanceController MantainanceController { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="UserMantainance"/> class.
        /// </summary>
        /// <param name="userController">The user controller.</param>
        public UserMantainance(UserController userController)
        {
            InitializeComponent();
            this.UserController = userController;
            this.MantainanceController = new MantainanceController(userController);
        }

        private void btnUpdate_Click(object sender, System.EventArgs e)
        {
            var newScore = this.tbxScore.Text;
            var isValidScore = InputValidation.ValidateScore(newScore, out int scoreAsInt);
            if (isValidScore && this.MantainanceController.UpdateScore(this.CurrentUser.Name , scoreAsInt))
            {
                MessageBox.Show("Score updated successfully!");
                this.UpdateForm();
            }
            else
            {
                MessageBox.Show("Invalid score. Please enter a valid integer value.");
            }
        }

        private void btnPrev_Click(object sender, System.EventArgs e)
        {
            if (currentIndex == 0)
            {
                return;
            }

            this.currentIndex--;
            this.UpdateForm();
        }

        private void btnNext_Click(object sender, System.EventArgs e)
        {
            if (currentIndex == this.UserController.Users.Count - 1)
            {
                this.currentIndex = 0;
            }
            else
            {
                this.currentIndex++;
            }

            this.UpdateForm();
        }

        private void UpdateForm()
        {
            this.lblUser.Text = CurrentUser.Name;
            this.tbxScore.Text = CurrentUser.Score.ToString();
        }
    }
}
