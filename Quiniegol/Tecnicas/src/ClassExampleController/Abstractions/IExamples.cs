using System.Collections.Generic;

namespace ClassExampleController.Abstractions
{
    /// <summary>
    /// Interface to define the behavior of the Examples to be made in class.
    /// </summary>
    public interface IExamples
    {
        /// <summary>
        /// Sums the elements.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>the sum of the elements in the array.</returns>
        int SumElements(List<int> input);

        /// <summary>
        /// Characters the count.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>a key value element with the char who appears an int times.</returns>
        Dictionary<char, int> CharCount(string input);

        /// <summary>
        /// The minimum and the the maximum of the list.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        (int, int) MinMax(List<int> input);

        /// <summary>
        /// Gets the index.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="charToSearch">The character to search.</param>
        /// <returns></returns>
        int GetIndex(string input, char charToSearch);
    }
}
