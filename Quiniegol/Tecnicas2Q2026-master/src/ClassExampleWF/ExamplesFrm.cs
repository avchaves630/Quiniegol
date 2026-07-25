using System;
using System.Windows.Forms;
using ClassExampleController;
using ClassExampleWF.Utils;

namespace ClassExampleWF
{
    /// <summary>
    /// Entry form for the ClassExampleWF application.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class ExamplesFrm : Form
    {
        private ExamplesController ExamplesController { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExamplesFrm" /> class.
        /// </summary>
        /// <param name="examplesController">The examples controller.</param>
        public ExamplesFrm(ExamplesController examplesController)
        {
            InitializeComponent();
            ExamplesController = examplesController;
        }

        private void ElementsSumClick(object sender, System.EventArgs e)
        {
            var input = textBox1.Text;

            var isValid = InputValidation.ValidateString(input, "First value is empty. Please enter a list of elements.");
            var listToProcess = InputValidation.ConvertStringToList(input);

            if (isValid && listToProcess.Count > 0)
            {
                var result = ExamplesController.SumElements(listToProcess);
                resultTbx.Text = result;
            }           
        }

        private void countCharOccurencies_Click(object sender, System.EventArgs e)
        {
            var input = textBox1.Text;
            var isValid = InputValidation.ValidateString(input, "First value is empty. Please enter a list of elements.");

            if (isValid)
            {
                var result = this.ExamplesController.CharCount(input);
                resultTbx.Text = result;
            }
        }

        private void minMaxBtnClick(object sender, System.EventArgs e)
        {
            var listAsText = textBox1.Text;

            var isValid = InputValidation.ValidateString(listAsText, "First value is empty. Please enter a list of elements.");
            var inputList = InputValidation.ConvertStringToList(listAsText);

            isValid = isValid && inputList.Count > 0;

            if (isValid)
            {
                var result = ExamplesController.MinMax(inputList);
                resultTbx.Text = result;
            }

        }

        private void findIndexBtnClick(object sender, EventArgs e)
        {
            var input = textBox1.Text;
            var charToSearch = textBox2.Text;

            var isValid = InputValidation.ValidateString(input, "First value is empty. Please enter a word.");
            isValid = isValid && InputValidation.ValidateString(charToSearch, "Second value is empty. Please enter a character to search.");

            if (isValid)
            {
                var result = ExamplesController.GetIndex(input, charToSearch[0]);
                this.resultTbx.Text = result;
            }
        }
    }
}
