using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ClassExampleWF.Utils
{
    /// <summary>
    /// Internal class with utilities to validate inputs.
    /// </summary>
    internal static class InputValidation
    {
        /// <summary>
        /// Converts the string to list.
        /// </summary>
        /// <param name="listAsText">The list as text.</param>
        /// <returns></returns>
        internal static List<int> ConvertStringToList(string listAsText)
        {
            var result = new List<int>();
            foreach (var item in listAsText)
            {
                if (int.TryParse(item.ToString(), out int number))
                {
                    result.Add(number);
                }
            }

            if (result.Count == 0)
            {
                MessageBox.Show("No valid digits found in the first value. Please enter a list of elements.");
            }

            return result;
        }

        /// <summary>
        /// Validates the password.
        /// </summary>
        /// <param name="password">The password.</param>
        /// <returns>true if the password contains more than 3 chars and at least 1 number.</returns>
        internal static bool ValidatePassword(string password)
        {
            if (ValidateString(password, "Password should not be empty!") && password.Length >= 3)
            {
                foreach(var element in password)
                {
                    if (char.IsDigit(element))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Validates the score.
        /// </summary>
        /// <param name="newScore">The new score.</param>
        /// <param name="scoreAsInt">The score as int.</param>
        /// <returns></returns>
        internal static bool ValidateScore(string newScore, out int scoreAsInt)
        {
            var isValid = int.TryParse(newScore, out int score);
            if (!isValid || score < 0)
            {
                scoreAsInt = 0;
                return false;
            }

            scoreAsInt = score;
            return true;
        }

        /// <summary>
        /// Validates the string.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        internal static bool ValidateString(string input, string message)
        {
            if (string.IsNullOrEmpty(input))
            {
                MessageBox.Show(message);
                return false;
            }

            return true;
        }
    }
}
