using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Quiniegol.Utils
{
    /// <summary>
    /// Clase de utilidades para la validación de entradas del usuario.
    /// </summary>
    public static class InputValidation
    {
        /// <summary>
        /// Convierte una cadena de texto en una lista de enteros.
        /// </summary>
        public static List<int> ConvertStringToList(string listAsText)
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
        /// Valida la contraseña del usuario.
        /// </summary>
        public static bool ValidatePassword(string password)
        {
            if (ValidateString(password, "Password should not be empty!") && password.Length >= 3)
            {
                foreach (var element in password)
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
        /// Valida el puntaje del usuario.
        /// </summary>
        public static bool ValidateScore(string newScore, out int scoreAsInt)
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
        /// Valida que la cadena de texto no sea nula ni vacía.
        /// </summary>
        public static bool ValidateString(string input, string message)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                MessageBox.Show(message);
                return false;
            }

            return true;
        }
    }
}
