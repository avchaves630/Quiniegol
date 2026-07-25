using ClassExampleController.Abstractions;
using System;
using System.Collections.Generic;
using System.IO;

namespace ClassExampleController
{
    /// <summary>
    /// Implementation of the contract to handle data by files.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="ClassExampleController.Abstractions.IDataHandler&lt;T&gt;" />
    public class FileHandler<T> : IDataHandler<T>
        where T : class
    {
        /// <summary>
        /// Creates the specified file name.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="element">The element.</param>
        /// <returns>
        /// true if the element has been created, otherwise false.
        /// </returns>
        public bool Create(string fileName, T element)
        {
            return true;
        }

        /// <summary>
        /// Loads the specified file name.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns>
        /// A list with the elements from the file.
        /// </returns>
        public List<T> Load(string fileName)
        {
            if (string.IsNullOrEmpty(fileName) || !File.Exists(fileName))
            {
                return null;
            }

            var data = new List<T>();
            var lines = File.ReadAllLines(fileName);

            for (var i = 1; i < lines.Length; i++)
            {
                var lineElement = lines[i].Split(',');
                var newElement = Activator.CreateInstance(typeof(T), lineElement);
                data.Add((T)newElement);
            }

            return data;
        }

        /// <summary>
        /// Removes the specified filename.
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <param name="element">The element.</param>
        /// <returns>
        /// true if the element has been removed, otherwise false.
        /// </returns>
        public bool Remove(string filename, T element)
        {
            return false;
        }

        /// <summary>
        /// Updates the specified file name.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="element">The element.</param>
        /// <returns>
        /// true if the element has been updated, otherwise false.
        /// </returns>
        public bool Update(string fileName, T element)
        {
            return false;
        }
    }
}
