using System.Collections.Generic;

namespace ClassExampleController.Abstractions
{
    /// <summary>
    /// Contract for the data operations.
    /// All the data operations should follow this contract.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IDataHandler<T>
        where T : class
    {
        /// <summary>
        /// Loads the specified file name.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns>A list with the elements from the file.</returns>
        List<T> Load(string fileName);

        /// <summary>
        /// Updates the specified file name.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="element">The element.</param>
        /// <returns>true if the element has been updated, otherwise false.</returns>
        bool Update(string fileName, T element);

        /// <summary>
        /// Removes the specified filename.
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <param name="element">The element.</param>
        /// <returns>true if the element has been removed, otherwise false.</returns>
        bool Remove(string filename, T element);

        /// <summary>
        /// Creates the specified file name.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="element">The element.</param>
        /// <returns>true if the element has been created, otherwise false.</returns>
        bool Create(string fileName, T element);
    }
}
