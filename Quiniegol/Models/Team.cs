using System;

namespace Quiniegol.Models
{
    /// <summary>
    /// Modelo que representa un equipo o selección participante en el torneo.
    /// </summary>
    public class Team : ICSVSerializable, IIdentifiable
    {
        public Team(string name, string group, string flagEmoji)
        {
            this.Name = name;
            this.Group = group;
            this.FlagEmoji = flagEmoji;
        }

        public Team(string[] props)
        {
            this.Name = props[0];
            this.Group = props[1];
        }

        public string Name { get; set; }
        public string Group { get; set; }
        public string FlagEmoji { get; set; }

        /// <summary>
        /// Retorna el nombre del equipo como su identificador único.
        /// </summary>
        public string GetId()
        {
            return this.Name;
        }

        /// <summary>
        /// Convierte el equipo a una línea de texto en formato CSV.
        /// </summary>
        public string ToCSVLine()
        {
            return $"{Name},{Group},{FlagEmoji}";
        }

        /// <summary>
        /// Retorna el encabezado de columnas del CSV para equipos.
        /// </summary>
        public string GetHeader()
        {
            return "Name,Group,FlagEmoji";
        }
    }
}
