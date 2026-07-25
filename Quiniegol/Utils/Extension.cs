using System;

namespace Quiniegol.Utils
{
    /// <summary>
    /// Métodos de extensión para tipos del sistema.
    /// </summary>
    public static class Extension
    {
        /// <summary>
        /// Determina si la cadena de texto corresponde a una dirección de Gmail válida.
        /// </summary>
        public static bool IsGmail(this string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return false;
            }

            if (input.EndsWith("@gmail.com", StringComparison.CurrentCultureIgnoreCase))
            {
                return true;
            }

            return false;
        }
    }
}
