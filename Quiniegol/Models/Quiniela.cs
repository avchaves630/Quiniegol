using System;
using System.Collections.Generic;
using System.Linq;

namespace Quiniegol.Models
{
    /// <summary>
    /// Modelo que representa una quiniela (liga de apuestas deportivas).
    /// </summary>
    public class Quiniela : ICSVSerializable, IIdentifiable
    {
        public Quiniela(string id, string name, bool isPrivate, string ownerUsername, List<string> memberUsernames, List<string> notificationTimeline)
        {
            this.Id = id;
            this.Name = name;
            this.IsPrivate = isPrivate;
            this.OwnerUsername = ownerUsername;
            this.MemberUsernames = memberUsernames ?? new List<string>();
            this.NotificationTimeline = notificationTimeline ?? new List<string>();
        }

        public Quiniela(string[] datos)
        {
            this.Id = datos.Length > 0 ? datos[0].Trim() : string.Empty;
            this.Name = datos.Length > 1 ? datos[1].Trim() : string.Empty;

            bool isPriv = false;
            if (datos.Length > 2 && !string.IsNullOrWhiteSpace(datos[2]) && bool.TryParse(datos[2].Trim(), out bool parsedPriv))
            {
                isPriv = parsedPriv;
            }
            this.IsPrivate = isPriv;

            this.OwnerUsername = datos.Length > 3 ? datos[3].Trim() : string.Empty;

            this.MemberUsernames = new List<string>();
            if (datos.Length > 4 && !string.IsNullOrWhiteSpace(datos[4]))
            {
                this.MemberUsernames = datos[4].Split(';').Select(s => s.Trim()).Where(s => !string.IsNullOrEmpty(s)).ToList();
            }

            this.NotificationTimeline = new List<string>();
            if (datos.Length > 5 && !string.IsNullOrWhiteSpace(datos[5]))
            {
                this.NotificationTimeline = datos[5].Split(';').Select(s => s.Trim()).Where(s => !string.IsNullOrEmpty(s)).ToList();
            }
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public bool IsPrivate { get; set; }
        public string OwnerUsername { get; set; }
        public List<string> MemberUsernames { get; set; }
        public List<string> NotificationTimeline { get; set; }

        /// <summary>
        /// Retorna el identificador único de la quiniela.
        /// </summary>
        public string GetId()
        {
            return this.Id;
        }

        /// <summary>
        /// Convierte la quiniela a una línea de texto en formato CSV.
        /// </summary>
        public string ToCSVLine()
        {
            string membersStr = this.MemberUsernames != null ? string.Join(";", this.MemberUsernames) : string.Empty;
            string timelineStr = this.NotificationTimeline != null ? string.Join(";", this.NotificationTimeline) : string.Empty;
            return $"{Id},{Name},{IsPrivate},{OwnerUsername},{membersStr},{timelineStr}";
        }

        /// <summary>
        /// Retorna el encabezado de columnas del CSV para quinielas.
        /// </summary>
        public string GetHeader()
        {
            return "Id,Name,IsPrivate,OwnerUsername,MemberUsernames,NotificationTimeline";
        }
    }
}
