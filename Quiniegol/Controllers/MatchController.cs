using Quiniegol.Controllers.Abstractions;
using Quiniegol.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Quiniegol.Controllers
{
    /// <summary>
    /// Modelo auxiliar para mostrar la tabla de posiciones de un grupo.
    /// </summary>
    public class GroupStandingRow
    {
        public string TeamName { get; set; }
        public int Played { get; set; }
        public int Won { get; set; }
        public int Drawn { get; set; }
        public int Lost { get; set; }
        public int GoalsFor { get; set; }
        public int GoalsAgainst { get; set; }
        public int GoalDifference => GoalsFor - GoalsAgainst;
        public int Points { get; set; }
    }

    /// <summary>
    /// Controlador que gestiona partidos, equipos, tablas de posiciones, llaves del torneo y la fecha simulada del sistema.
    /// </summary>
    public class MatchController
    {
        private IDataHandler<Match> MatchHandler { get; set; }
        private IDataHandler<Team> TeamHandler { get; set; }
        private string MatchesFilePath { get; set; }
        private string TeamsFilePath { get; set; }

        public List<Match> Matches { get; private set; }
        public List<Team> Teams { get; private set; }
        public DateTime SimulatedSystemDate { get; set; } = new DateTime(2026, 7, 25, 14, 0, 0);

        public MatchController(IDataHandler<Match> matchHandler, IDataHandler<Team> teamHandler, string matchesPath, string teamsPath)
        {
            this.MatchHandler = matchHandler;
            this.TeamHandler = teamHandler;
            this.MatchesFilePath = matchesPath;
            this.TeamsFilePath = teamsPath;

            this.Load();
            this.LoadSimulatedDate();
        }

        /// <summary>
        /// Recarga los partidos y equipos desde los archivos de datos.
        /// </summary>
        public void Load()
        {
            this.Matches = this.MatchHandler.Load(MatchesFilePath) ?? new List<Match>();
            this.Teams = this.TeamHandler.Load(TeamsFilePath) ?? new List<Team>();
        }

        /// <summary>
        /// Guarda o actualiza un partido en el sistema.
        /// </summary>
        public bool SaveMatch(Match match)
        {
            var index = this.Matches.FindIndex(m => m.Id == match.Id);
            if (index >= 0)
            {
                this.Matches[index] = match;
                return this.MatchHandler.Update(MatchesFilePath, match);
            }
            else
            {
                this.Matches.Add(match);
                return this.MatchHandler.Create(MatchesFilePath, match);
            }
        }

        private void LoadSimulatedDate()
        {
            try
            {
                string path = Path.Combine(Path.GetDirectoryName(MatchesFilePath), "simulated_date.txt");
                if (File.Exists(path))
                {
                    string text = File.ReadAllText(path).Trim();
                    if (DateTime.TryParse(text, out DateTime savedDate))
                    {
                        SimulatedSystemDate = savedDate;
                    }
                }
            }
            catch { }
        }

        /// <summary>
        /// Actualiza y persiste la fecha simulada del sistema.
        /// </summary>
        public void SaveSimulatedDate(DateTime newDate)
        {
            this.SimulatedSystemDate = newDate;
            try
            {
                string path = Path.Combine(Path.GetDirectoryName(MatchesFilePath), "simulated_date.txt");
                File.WriteAllText(path, newDate.ToString("yyyy-MM-ddTHH:mm:ss"));
            }
            catch { }
        }

        /// <summary>
        /// Calcula y retorna la tabla de posiciones del grupo indicado.
        /// </summary>
        public List<GroupStandingRow> GetStandingsForGroup(string groupName)
        {
            var groupTeams = this.Teams.Where(t => t.Group.Equals(groupName, StringComparison.OrdinalIgnoreCase)).ToList();
            var standings = groupTeams.Select(t => new GroupStandingRow { TeamName = t.Name }).ToDictionary(r => r.TeamName);

            var groupMatches = this.Matches.Where(m => m.Stage.Equals("Group " + groupName, StringComparison.OrdinalIgnoreCase) && m.IsFinished).ToList();

            foreach (var m in groupMatches)
            {
                if (!standings.ContainsKey(m.HomeTeam) || !standings.ContainsKey(m.AwayTeam)) continue;

                var home = standings[m.HomeTeam];
                var away = standings[m.AwayTeam];

                home.Played++;
                away.Played++;

                int hs = m.HomeScore ?? 0;
                int ascore = m.AwayScore ?? 0;

                home.GoalsFor += hs;
                home.GoalsAgainst += ascore;
                away.GoalsFor += ascore;
                away.GoalsAgainst += hs;

                if (hs > ascore)
                {
                    home.Won++;
                    home.Points += 3;
                    away.Lost++;
                }
                else if (hs < ascore)
                {
                    away.Won++;
                    away.Points += 3;
                    home.Lost++;
                }
                else
                {
                    home.Drawn++;
                    away.Drawn++;
                    home.Points += 1;
                    away.Points += 1;
                }
            }

            return standings.Values
                .OrderByDescending(r => r.Points)
                .ThenByDescending(r => r.GoalDifference)
                .ThenByDescending(r => r.GoalsFor)
                .ThenBy(r => r.TeamName)
                .ToList();
        }
    }
}
