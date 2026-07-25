using ClassExampleController.Abstractions;
using System.Collections.Generic;
using System.ComponentModel;

namespace ClassExampleController
{
    /// <summary>
    /// Implementation of the IExamples interface.
    /// </summary>
    /// <seealso cref="ClassExampleController.Abstractions.IExamples" />
    public class Examples : IExamples
    {
        /// <summary>
        /// Characters the count.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>
        /// a key value element with the char who appears an int times.
        /// </returns>
        public Dictionary<char, int> CharCount(string input)
        {
            var resultDict = new Dictionary<char, int>();
            for (var i = 0; i < input.Length; i++)
            {
                if (resultDict.ContainsKey(input[i]))
                {
                    resultDict[input[i]]++;
                }
                else
                {
                    resultDict.Add(input[i], 1);
                }
            }

            return resultDict;
        }

        /// <summary>
        /// Gets the index.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        public int GetIndex(string input, char charToSearch)
        {
            var indexPosition = -1;

            for (var i = 0; i < input.Length; i++)
            {
                if (charToSearch.Equals(input[i]))
                {
                    indexPosition = i;
                    break;
                }
            }

            return indexPosition;
        }

        /// <summary>
        /// The minimum and the the maximum of the list.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        public (int, int) MinMax(List<int> input)
        {
            int max = input[0];
            int min = input[0];

            for (var i = 1; i < input.Count; i++)
            {
                if (max < input[i])
                {
                    max = input[i];
                }
                else if (min > input[i])
                {
                    min = input[i];
                }
            }

            return (min, max);
        }

        /// <summary>
        /// Sums the elements.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>
        /// the sum of the elements in the array.
        /// </returns>
        public int SumElements(List<int> input)
        {
            var result = 0;
            foreach (var item in input)
            {
                result += item;
            }

            return result;
        }
    }
}
