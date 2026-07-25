using ClassExampleController.Abstractions;
using System.Collections.Generic;

namespace ClassExampleController
{
    /// <summary>
    /// Controller for Examples operations to be display.
    /// </summary>
    public class ExamplesController
    {
        private IExamples ExamplesExecuter { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExamplesController"/> class.
        /// </summary>
        /// <param name="examples">The examples.</param>
        public ExamplesController(IExamples examples)
        {
            ExamplesExecuter = examples;
        }

        /// <summary>
        /// Characters the count.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>
        /// a key value element with the char who appears an int times.
        /// </returns>
        public string CharCount(string input)
        {
            var resultDict = ExamplesExecuter.CharCount(input);

            var result = string.Empty;
            foreach (var key in resultDict.Keys)
            {
                result += $"'{key}' => {resultDict[key]} ; ";
            }

            return result;

        }

        /// <summary>
        /// Gets the index.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        public string GetIndex(string input, char charToSearch)
        {
            var indexPosition = this.ExamplesExecuter.GetIndex(input, charToSearch);

            if (indexPosition == -1)
            {
                return $"La letra {charToSearch} no aparece en la palabra {input}";
            }
            else
            {
                return $"La letra {charToSearch} en la palabra {input} aparece en la posicion {indexPosition}";
            }
        }

        /// <summary>
        /// The minimum and the the maximum of the list.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        public string MinMax(List<int> input)
        {
            (int, int) result = this.ExamplesExecuter.MinMax(input);

            return $"el maximo es {result.Item1} y el minimo {result.Item2}";
        }

        /// <summary>
        /// Sums the elements.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>
        /// the sum of the elements in the array.
        /// </returns>
        public string SumElements(List<int> input)
        {
            var result = this.ExamplesExecuter.SumElements(input);
            return $"La suma de los elementos de la lista es {result}";
        }
    }
}
