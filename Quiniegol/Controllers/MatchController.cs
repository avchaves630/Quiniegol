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
        public DateTime SimulatedSystemDate { get; set; } = new DateTime(2026, 7, 30, 12, 0, 0);

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
                bool updated = this.MatchHandler.Update(MatchesFilePath, match);
                if (updated)
                {
                    CheckAndGenerateNextStage();
                }
                return updated;
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

        /// <summary>
        /// Analiza el estado del torneo y genera dinámicamente los partidos de las siguientes fases.
        /// </summary>
        public void CheckAndGenerateNextStage()
        {
            var groupStageMatches = this.Matches.Where(m => m.Stage.StartsWith("Group", StringComparison.OrdinalIgnoreCase)).ToList();
            bool groupStageFinished = groupStageMatches.Count > 0 && groupStageMatches.All(m => m.IsFinished);

            if (groupStageFinished && !this.Matches.Any(m => m.Stage.Equals("Quarterfinals", StringComparison.OrdinalIgnoreCase)))
            {
                var standA = GetStandingsForGroup("A");
                var standB = GetStandingsForGroup("B");
                var standC = GetStandingsForGroup("C");
                var standD = GetStandingsForGroup("D");

                if (standA.Count >= 2 && standB.Count >= 2 && standC.Count >= 2 && standD.Count >= 2)
                {
                    string t1A = standA[0].TeamName;
                    string t2A = standA[1].TeamName;
                    string t1B = standB[0].TeamName;
                    string t2B = standB[1].TeamName;
                    string t1C = standC[0].TeamName;
                    string t2C = standC[1].TeamName;
                    string t1D = standD[0].TeamName;
                    string t2D = standD[1].TeamName;

                    var qf1 = new Match(17, t1A, t2B, null, null, SimulatedSystemDate.AddDays(2), new List<string>(), false, "Quarterfinals");
                    var qf2 = new Match(18, t1C, t2D, null, null, SimulatedSystemDate.AddDays(2), new List<string>(), false, "Quarterfinals");
                    var qf3 = new Match(19, t1B, t2A, null, null, SimulatedSystemDate.AddDays(3), new List<string>(), false, "Quarterfinals");
                    var qf4 = new Match(20, t1D, t2C, null, null, SimulatedSystemDate.AddDays(3), new List<string>(), false, "Quarterfinals");

                    this.Matches.Add(qf1);
                    this.Matches.Add(qf2);
                    this.Matches.Add(qf3);
                    this.Matches.Add(qf4);

                    this.MatchHandler.Create(MatchesFilePath, qf1);
                    this.MatchHandler.Create(MatchesFilePath, qf2);
                    this.MatchHandler.Create(MatchesFilePath, qf3);
                    this.MatchHandler.Create(MatchesFilePath, qf4);
                }
            }

            var qfMatches = this.Matches.Where(m => m.Stage.Equals("Quarterfinals", StringComparison.OrdinalIgnoreCase)).ToList();
            bool qfFinished = qfMatches.Count == 4 && qfMatches.All(m => m.IsFinished);

            if (qfFinished && !this.Matches.Any(m => m.Stage.Equals("Semifinals", StringComparison.OrdinalIgnoreCase)))
            {
                string w17 = GetWinner(qfMatches.Find(m => m.Id == 17));
                string w18 = GetWinner(qfMatches.Find(m => m.Id == 18));
                string w19 = GetWinner(qfMatches.Find(m => m.Id == 19));
                string w20 = GetWinner(qfMatches.Find(m => m.Id == 20));

                var sf1 = new Match(21, w17, w18, null, null, SimulatedSystemDate.AddDays(2), new List<string>(), false, "Semifinals");
                var sf2 = new Match(22, w19, w20, null, null, SimulatedSystemDate.AddDays(3), new List<string>(), false, "Semifinals");

                this.Matches.Add(sf1);
                this.Matches.Add(sf2);

                this.MatchHandler.Create(MatchesFilePath, sf1);
                this.MatchHandler.Create(MatchesFilePath, sf2);
            }

            var sfMatches = this.Matches.Where(m => m.Stage.Equals("Semifinals", StringComparison.OrdinalIgnoreCase)).ToList();
            bool sfFinished = sfMatches.Count == 2 && sfMatches.All(m => m.IsFinished);

            if (sfFinished && !this.Matches.Any(m => m.Stage.Equals("Final", StringComparison.OrdinalIgnoreCase)))
            {
                string w21 = GetWinner(sfMatches.Find(m => m.Id == 21));
                string w22 = GetWinner(sfMatches.Find(m => m.Id == 22));

                var final = new Match(23, w21, w22, null, null, SimulatedSystemDate.AddDays(2), new List<string>(), false, "Final");

                this.Matches.Add(final);
                this.MatchHandler.Create(MatchesFilePath, final);
            }
        }

        private string GetWinner(Match m)
        {
            if (m == null || !m.HomeScore.HasValue || !m.AwayScore.HasValue) return "TBD";
            if (m.HomeScore.Value > m.AwayScore.Value) return m.HomeTeam;
            if (m.HomeScore.Value < m.AwayScore.Value) return m.AwayTeam;
            return m.HomeTeam;
        }
    }
}
