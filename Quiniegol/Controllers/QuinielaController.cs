using Quiniegol.Controllers.Abstractions;
using Quiniegol.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Quiniegol.Controllers
{
    /// <summary>
    /// Controlador que gestiona las quinielas, membresías y notificaciones.
    /// </summary>
    public class QuinielaController
    {
        private IDataHandler<Quiniela> DataHandler { get; set; }
        private string FilePath { get; set; }

        public List<Quiniela> Quinielas { get; private set; }

        public QuinielaController(IDataHandler<Quiniela> dataHandler, string filePath)
        {
            this.DataHandler = dataHandler;
            this.FilePath = filePath;
            this.Load();
        }

        /// <summary>
        /// Recarga las quinielas desde el archivo de datos.
        /// </summary>
        public void Load()
        {
            this.Quinielas = this.DataHandler.Load(FilePath) ?? new List<Quiniela>();
        }

        /// <summary>
        /// Busca una quiniela por su identificador único.
        /// </summary>
        public Quiniela FindQuiniela(string id)
        {
            return this.Quinielas.Find(q => q.Id.Equals(id, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Crea una nueva quiniela con el usuario indicado como propietario.
        /// </summary>
        public bool CreateQuiniela(string id, string name, bool isPrivate, string ownerUsername)
        {
            if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(name)) return false;

            var existing = FindQuiniela(id);
            if (existing != null) return false;

            var members = new List<string> { ownerUsername };
            var timeline = new List<string> { $"Quiniela creada por {ownerUsername}!" };

            var newQ = new Quiniela(id, name, isPrivate, ownerUsername, members, timeline);
            this.Quinielas.Add(newQ);

            return this.DataHandler.Create(FilePath, newQ);
        }

        /// <summary>
        /// Permite que un usuario se una a una quiniela existente.
        /// </summary>
        public bool JoinQuiniela(string id, string username)
        {
            var q = FindQuiniela(id);
            if (q == null) return false;

            if (q.MemberUsernames.Contains(username, StringComparer.OrdinalIgnoreCase))
            {
                return true;
            }

            q.MemberUsernames.Add(username);
            q.NotificationTimeline.Insert(0, $"{username} se ha unido a la quiniela!");

            return this.DataHandler.Update(FilePath, q);
        }

        /// <summary>
        /// Retorna todas las quinielas en las que participa el usuario indicado.
        /// </summary>
        public List<Quiniela> GetQuinielasForUser(string username)
        {
            return this.Quinielas.Where(q => q.MemberUsernames.Contains(username, StringComparer.OrdinalIgnoreCase)).ToList();
        }

        /// <summary>
        /// Agrega un mensaje al historial de notificaciones de una quiniela específica.
        /// </summary>
        public void AddNotification(string quinielaId, string message)
        {
            var q = FindQuiniela(quinielaId);
            if (q != null)
            {
                q.NotificationTimeline.Insert(0, $"{DateTime.Now:HH:mm} - {message}");
                if (q.NotificationTimeline.Count > 50)
                {
                    q.NotificationTimeline.RemoveAt(q.NotificationTimeline.Count - 1);
                }
                this.DataHandler.Update(FilePath, q);
            }
        }

        /// <summary>
        /// Retorna la tabla de posiciones de los miembros de una quiniela específica.
        /// </summary>
        public List<User> GetLeagueRanking(string quinielaId, UserController userController)
        {
            var q = FindQuiniela(quinielaId);
            if (q == null) return new List<User>();

            var members = q.MemberUsernames
                .Select(username => userController.FindUser(username))
                .Where(u => u != null)
                .OrderByDescending(u => u.Score)
                .ThenBy(u => u.Username)
                .ToList();

            return members;
        }
    }
}
