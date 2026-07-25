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

        public Quiniela(string[] props)
        {
            this.Id = props[0];
            this.Name = props[1];
            this.IsPrivate = bool.Parse(props[2]);
            this.OwnerUsername = props[3];

            this.MemberUsernames = new List<string>();
            if (props.Length > 4 && !string.IsNullOrEmpty(props[4]))
            {
                this.MemberUsernames = props[4].Split(';').ToList();
            }

            this.NotificationTimeline = new List<string>();
            if (props.Length > 5 && !string.IsNullOrEmpty(props[5]))
            {
                this.NotificationTimeline = props[5].Split(';').ToList();
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
