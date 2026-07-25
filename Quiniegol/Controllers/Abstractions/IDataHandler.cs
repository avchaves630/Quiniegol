using System.Collections.Generic;

namespace Quiniegol.Controllers.Abstractions
{
    /// <summary>
    /// Contrato para las operaciones de datos del sistema.
    /// </summary>
    /// <typeparam name="T">Tipo de entidad gestionada.</typeparam>
    public interface IDataHandler<T>
        where T : class
    {
        /// <summary>
        /// Carga todos los elementos desde el archivo indicado.
        /// </summary>
        List<T> Load(string fileName);

        /// <summary>
        /// Actualiza un elemento existente en el archivo indicado.
        /// </summary>
        bool Update(string fileName, T element);

        /// <summary>
        /// Elimina un elemento del archivo indicado.
        /// </summary>
        bool Remove(string filename, T element);

        /// <summary>
        /// Agrega un nuevo elemento al archivo indicado.
        /// </summary>
        bool Create(string fileName, T element);
    }
}
