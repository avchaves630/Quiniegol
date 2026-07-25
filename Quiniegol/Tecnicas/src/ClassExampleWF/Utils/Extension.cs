namespace ClassExampleWF.Utils
{
    /// <summary>
    /// Extension methods utilities for different elements.
    /// </summary>
    internal static class Extension
    {
        /// <summary>
        /// Determines whether this instance is email.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>
        ///   <c>true</c> if the specified input is email; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsGmail(this string input)
        {
            if (input.EndsWith("@gmail.com", System.StringComparison.CurrentCultureIgnoreCase))
            {
                return true;
            }

            return false;
        }
    }
}
