using System;
using System.Collections.Generic;
using System.Linq;

namespace Quiniegol.Models
{
    /// <summary>
    /// Modelo que representa un usuario del sistema.
    /// </summary>
    public class User : ICSVSerializable, IIdentifiable
    {
        public User(string name, string username, string password, string email, string score, string preferredCountry, string insignias = "", string quinielas = "")
        {
            this.Name = name;
            this.Username = username;
            this.Password = password;
            this.Email = email;
            int.TryParse(score, out int parsedScore);
            this.Score = parsedScore;
            this.PreferredCountry = preferredCountry;
            this.Insignias = string.IsNullOrEmpty(insignias) ? new List<string>() : insignias.Split(';').Select(s => s.Trim()).Where(s => !string.IsNullOrEmpty(s)).ToList();
            this.Quinielas = string.IsNullOrEmpty(quinielas) ? new List<string>() : quinielas.Split(';').Select(s => s.Trim()).Where(s => !string.IsNullOrEmpty(s)).ToList();
        }

        public User(string[] datos)
        {
            this.Name = datos.Length > 0 ? datos[0].Trim() : string.Empty;
            this.Username = datos.Length > 1 ? datos[1].Trim() : string.Empty;
            this.Password = datos.Length > 2 ? datos[2].Trim() : string.Empty;
            this.Email = datos.Length > 3 ? datos[3].Trim() : string.Empty;

            int score = 0;
            if (datos.Length > 4 && !string.IsNullOrWhiteSpace(datos[4]) && int.TryParse(datos[4].Trim(), out int parsedScore))
            {
                score = parsedScore;
            }
            this.Score = score;

            this.PreferredCountry = datos.Length > 5 ? datos[5].Trim() : string.Empty;

            this.Insignias = new List<string>();
            if (datos.Length > 6 && !string.IsNullOrWhiteSpace(datos[6]))
            {
                this.Insignias = datos[6].Split(';').Select(s => s.Trim()).Where(s => !string.IsNullOrEmpty(s)).ToList();
            }

            this.Quinielas = new List<string>();
            if (datos.Length > 7 && !string.IsNullOrWhiteSpace(datos[7]))
            {
                this.Quinielas = datos[7].Split(';').Select(s => s.Trim()).Where(s => !string.IsNullOrEmpty(s)).ToList();
            }
        }

        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int Score { get; set; }
        public string PreferredCountry { get; set; }
        public List<string> Insignias { get; set; }
        public List<string> Quinielas { get; set; }

        /// <summary>
        /// Retorna el nombre de usuario como identificador único.
        /// </summary>
        public string GetId()
        {
            return this.Username;
        }

        /// <summary>
        /// Convierte el usuario a una línea de texto en formato CSV.
        /// </summary>
        public string ToCSVLine()
        {
            string insJoined = this.Insignias != null ? string.Join(";", this.Insignias) : string.Empty;
            string qJoined = this.Quinielas != null ? string.Join(";", this.Quinielas) : string.Empty;
            return $"{Name},{Username},{Password},{Email},{Score},{PreferredCountry},{insJoined},{qJoined}";
        }

        /// <summary>
        /// Retorna el encabezado de columnas del CSV para usuarios.
        /// </summary>
        public string GetHeader()
        {
            return "Name,Username,Password,Email,Score,PreferredCountry,Insignias,Quinielas";
        }
    }
}
