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
        /// Carga todos los elementos desde el archivo CSV indicado con compartición de lectura/escritura y manejo de errores.
        /// </summary>
        public List<T> Load(string fileName)
        {
            if (string.IsNullOrEmpty(fileName) || !File.Exists(fileName))
            {
                return new List<T>();
            }

            var data = new List<T>();
            var lines = ReadLinesWithShare(fileName);

            for (var i = 1; i < lines.Count; i++)
            {
                if (string.IsNullOrWhiteSpace(lines[i]))
                {
                    continue;
                }
                try
                {
                    var lineElement = lines[i].Split(',');
                    var newElement = Activator.CreateInstance(typeof(T), new object[] { lineElement });
                    data.Add((T)newElement);
                }
                catch
                {
                    // Evitar que una línea corrupta invalide la carga completa del archivo
                }
            }

            return data;
        }

        private List<string> ReadLinesWithShare(string fileName)
        {
            var lines = new List<string>();
            try
            {
                using (var fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                using (var sr = new StreamReader(fs))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        lines.Add(line);
                    }
                }
            }
            catch (IOException)
            {
                // Reintento breve por si el archivo está siendo bloqueado momentáneamente por OneDrive o Excel
                System.Threading.Thread.Sleep(100);
                try
                {
                    using (var fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    using (var sr = new StreamReader(fs))
                    {
                        string line;
                        while ((line = sr.ReadLine()) != null)
                        {
                            lines.Add(line);
                        }
                    }
                }
                catch
                {
                    return lines;
                }
            }
            catch
            {
                return lines;
            }

            return lines;
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
                }

                using (var fs = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.ReadWrite))
                using (var sw = new StreamWriter(fs))
                {
                    foreach (var line in lines)
                    {
                        sw.WriteLine(line);
                    }
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
