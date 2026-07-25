using Quiniegol.Controllers.Abstractions;
using Quiniegol.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace Quiniegol.Controllers
{
    /// <summary>
    /// Implementación del contrato de manejo de datos mediante archivos CSV.
    /// </summary>
    /// <typeparam name="T">Tipo de entidad gestionada.</typeparam>
    public class FileHandler<T> : IDataHandler<T>
        where T : class, ICSVSerializable, IIdentifiable
    {
        /// <summary>
        /// Agrega un nuevo elemento al archivo CSV indicado.
        /// </summary>
        public bool Create(string fileName, T element)
        {
            var list = Load(fileName);
            list.Add(element);
            return SaveAll(fileName, list);
        }

        /// <summary>
        /// Carga todos los elementos desde el archivo CSV indicado.
        /// </summary>
        public List<T> Load(string fileName)
        {
            if (string.IsNullOrEmpty(fileName) || !File.Exists(fileName))
            {
                return new List<T>();
            }

            var data = new List<T>();
            var lines = File.ReadAllLines(fileName);

            for (var i = 1; i < lines.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(lines[i]))
                {
                    continue;
                }
                var lineElement = lines[i].Split(',');
                var newElement = Activator.CreateInstance(typeof(T), new object[] { lineElement });
                data.Add((T)newElement);
            }

            return data;
        }

        /// <summary>
        /// Elimina un elemento del archivo CSV indicado.
        /// </summary>
        public bool Remove(string filename, T element)
        {
            var list = Load(filename);
            var index = list.FindIndex(item => item.GetId().Equals(element.GetId(), StringComparison.OrdinalIgnoreCase));
            if (index >= 0)
            {
                list.RemoveAt(index);
                return SaveAll(filename, list);
            }
            return false;
        }

        /// <summary>
        /// Actualiza un elemento existente en el archivo CSV indicado.
        /// </summary>
        public bool Update(string fileName, T element)
        {
            var list = Load(fileName);
            var index = list.FindIndex(item => item.GetId().Equals(element.GetId(), StringComparison.OrdinalIgnoreCase));
            if (index >= 0)
            {
                list[index] = element;
                return SaveAll(fileName, list);
            }
            return false;
        }

        private bool SaveAll(string fileName, List<T> list)
        {
            try
            {
                var directory = Path.GetDirectoryName(fileName);
                if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                var lines = new List<string>();
                if (list.Count > 0)
                {
                    lines.Add(list[0].GetHeader());
                    foreach (var item in list)
                    {
                        lines.Add(item.ToCSVLine());
                    }
                    File.WriteAllLines(fileName, lines);
                }
                else
                {
                    File.WriteAllText(fileName, string.Empty);
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
