using Quiniegol.Controllers.Abstractions;
using Quiniegol.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Quiniegol.Controllers
{
    /// <summary>
    /// Controlador encargado de las operaciones de usuarios y la gestión de insignias.
    /// </summary>
    public class UserController
    {
        private IDataHandler<User> DataHandler { get; set; }
        private string FilePath { get; set; }

        public List<User> Users { get; private set; }

        public UserController(IDataHandler<User> dataHandler, string filePath)
        {
            this.DataHandler = dataHandler;
            this.FilePath = filePath;
            this.Load();
        }

        /// <summary>
        /// Recarga los usuarios desde el archivo de datos.
        /// </summary>
        public void Load()
        {
            this.Users = this.DataHandler.Load(FilePath) ?? new List<User>();
        }

        /// <summary>
        /// Busca un usuario por nombre de usuario o correo electrónico.
        /// </summary>
        public User FindUser(string username)
        {
            if (this.Users != null && this.Users.Count > 0)
            {
                return this.Users.Find(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase) ||
                                            u.Email.Equals(username, StringComparison.OrdinalIgnoreCase));
            }
            return null;
        }

        /// <summary>
        /// Guarda o actualiza un usuario en el sistema.
        /// </summary>
        public bool SaveUser(User user)
        {
            var existing = FindUser(user.Username);
            if (existing != null)
            {
                var index = this.Users.FindIndex(u => u.Username.Equals(user.Username, StringComparison.OrdinalIgnoreCase));
                this.Users[index] = user;
                return this.DataHandler.Update(FilePath, user);
            }
            else
            {
                this.Users.Add(user);
                return this.DataHandler.Create(FilePath, user);
            }
        }

        /// <summary>
        /// Actualiza el puntaje de un usuario en el sistema.
        /// </summary>
        public bool UpdateScore(string username, int score)
        {
            var user = this.FindUser(username);
            if (user == null)
            {
                return false;
            }

            user.Score = score;
            return this.SaveUser(user);
        }

        /// <summary>
        /// Retorna la lista de usuarios ordenada por puntaje de mayor a menor.
        /// </summary>
        public List<User> GetRankingByScoreDesc()
        {
            return this.Users.OrderByDescending(u => u.Score).ThenBy(u => u.Username).ToList();
        }

        /// <summary>
        /// Recalcula y actualiza dinámicamente las insignias de todos los usuarios.
        /// </summary>
        public void RecalculateInsignias(List<Prediction> allPredictions, List<Match> allMatches, List<Quiniela> allQuinielas)
        {
            if (this.Users == null || this.Users.Count == 0) return;

            foreach (var user in this.Users)
            {
                user.Insignias.Clear();
            }

            var finishedMatches = allMatches.Where(m => m.IsFinished).ToList();
            if (finishedMatches.Count > 0)
            {
                var ranking = this.GetRankingByScoreDesc();
                var topScore = ranking.First().Score;
                if (topScore > 0)
                {
                    var leaders = ranking.Where(u => u.Score == topScore).ToList();
                    foreach (var leader in leaders)
                    {
                        leader.Insignias.Add("Líder Global 👑");
                    }
                }

                var worstScore = ranking.Last().Score;
                if (ranking.Count > 1)
                {
                    var worstUsers = ranking.Where(u => u.Score == worstScore).ToList();
                    foreach (var worst in worstUsers)
                    {
                        worst.Insignias.Add("Peor Global 🗑️");
                    }
                }

                var drawGuesses = new Dictionary<string, int>();
                foreach (var u in this.Users) drawGuesses[u.Username] = 0;

                foreach (var pred in allPredictions)
                {
                    var match = finishedMatches.Find(m => m.Id == pred.MatchId);
                    if (match != null && match.HomeScore == match.AwayScore && pred.PredictedHomeScore == pred.PredictedAwayScore)
                    {
                        if (drawGuesses.ContainsKey(pred.Username))
                        {
                            drawGuesses[pred.Username]++;
                        }
                    }
                }

                int maxDraws = drawGuesses.Values.Count > 0 ? drawGuesses.Values.Max() : 0;
                if (maxDraws > 0)
                {
                    var drawKings = drawGuesses.Where(kv => kv.Value == maxDraws).Select(kv => kv.Key).ToList();
                    foreach (var king in drawKings)
                    {
                        var u = FindUser(king);
                        if (u != null) u.Insignias.Add("Rey de los Empates 🤝");
                    }
                }

                foreach (var user in this.Users)
                {
                    var userPreds = allPredictions
                        .Where(p => p.Username.Equals(user.Username, StringComparison.OrdinalIgnoreCase))
                        .OrderBy(p => p.DateCreated)
                        .ToList();

                    int currentStreak = 0;
                    int maxStreak = 0;

                    foreach (var pred in userPreds)
                    {
                        var match = finishedMatches.Find(m => m.Id == pred.MatchId);
                        if (match != null)
                        {
                            bool correct = false;
                            int actH = match.HomeScore.Value;
                            int actA = match.AwayScore.Value;
                            int predH = pred.PredictedHomeScore;
                            int predA = pred.PredictedAwayScore;

                            if (actH == predH && actA == predA)
                            {
                                correct = true;
                            }
                            else if ((actH > actA && predH > predA) ||
                                     (actH < actA && predH < predA) ||
                                     (actH == actA && predH == predA))
                            {
                                correct = true;
                            }

                            if (correct)
                            {
                                currentStreak++;
                                if (currentStreak > maxStreak) maxStreak = currentStreak;
                            }
                            else
                            {
                                currentStreak = 0;
                            }
                        }
                    }

                    if (maxStreak >= 10)
                    {
                        user.Insignias.Add("Racha 10+ 🔥");
                    }
                }

                foreach (var q in allQuinielas)
                {
                    if (q.MemberUsernames.Count < 2) continue;

                    var members = q.MemberUsernames.Select(username => FindUser(username)).Where(u => u != null).ToList();
                    if (members.Count == 0) continue;

                    var sortedMembers = members.OrderByDescending(u => u.Score).ToList();
                    var topLScore = sortedMembers.First().Score;
                    if (topLScore > 0)
                    {
                        var tops = sortedMembers.Where(u => u.Score == topLScore).ToList();
                        foreach (var t in tops)
                        {
                            t.Insignias.Add($"Líder de {q.Name} 🥇");
                        }
                    }

                    var worstLScore = sortedMembers.Last().Score;
                    var worsts = sortedMembers.Where(u => u.Score == worstLScore).ToList();
                    foreach (var w in worsts)
                    {
                        w.Insignias.Add($"Peor de {q.Name} 💀");
                    }
                }
            }

            foreach (var user in this.Users)
            {
                this.DataHandler.Update(FilePath, user);
            }
        }
    }
}
