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
            this.Score = int.Parse(score);
            this.PreferredCountry = preferredCountry;
            this.Insignias = string.IsNullOrEmpty(insignias) ? new List<string>() : insignias.Split(';').ToList();
            this.Quinielas = string.IsNullOrEmpty(quinielas) ? new List<string>() : quinielas.Split(';').ToList();
        }

        public User(string[] props)
        {
            this.Name = props[0];
            this.Username = props[1];
            this.Password = props[2];
            this.Email = props[3];
            this.Score = int.Parse(props[4]);
            this.PreferredCountry = props.Length > 5 ? props[5] : string.Empty;

            this.Insignias = new List<string>();
            if (props.Length > 6 && !string.IsNullOrEmpty(props[6]))
            {
                this.Insignias = props[6].Split(';').ToList();
            }

            this.Quinielas = new List<string>();
            if (props.Length > 7 && !string.IsNullOrEmpty(props[7]))
            {
                this.Quinielas = props[7].Split(';').ToList();
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
