using System;
using System.Collections.Generic;
using System.Linq;

namespace Quiniegol.Models
{
    /// <summary>
    /// Modelo que representa un partido del torneo.
    /// </summary>
    public class Match : ICSVSerializable, IIdentifiable
    {
        public Match(int id, string homeTeam, string awayTeam, int? homeScore, int? awayScore, DateTime matchDate, List<string> scorers, bool isFinished, string stage)
        {
            this.Id = id;
            this.HomeTeam = homeTeam;
            this.AwayTeam = awayTeam;
            this.HomeScore = homeScore;
            this.AwayScore = awayScore;
            this.MatchDate = matchDate;
            this.Scorers = scorers ?? new List<string>();
            this.IsFinished = isFinished;
            this.Stage = stage;
        }

        public Match(string[] props)
        {
            int id = 0;
            if (props.Length > 0 && int.TryParse(props[0].Trim(), out int parsedId))
            {
                id = parsedId;
            }
            this.Id = id;

            this.HomeTeam = props.Length > 1 ? props[1].Trim() : string.Empty;
            this.AwayTeam = props.Length > 2 ? props[2].Trim() : string.Empty;

            if (props.Length > 3 && !string.IsNullOrWhiteSpace(props[3]) && int.TryParse(props[3].Trim(), out int hs))
            {
                this.HomeScore = hs;
            }
            else
            {
                this.HomeScore = null;
            }

            if (props.Length > 4 && !string.IsNullOrWhiteSpace(props[4]) && int.TryParse(props[4].Trim(), out int ascore))
            {
                this.AwayScore = ascore;
            }
            else
            {
                this.AwayScore = null;
            }

            DateTime dt = DateTime.Now;
            if (props.Length > 5 && !string.IsNullOrWhiteSpace(props[5]) && DateTime.TryParse(props[5].Trim(), out DateTime parsedDt))
            {
                dt = parsedDt;
            }
            this.MatchDate = dt;

            this.Scorers = new List<string>();
            if (props.Length > 6 && !string.IsNullOrWhiteSpace(props[6]))
            {
                this.Scorers = props[6].Split(';').Select(s => s.Trim()).Where(s => !string.IsNullOrEmpty(s)).ToList();
            }

            bool isFinished = false;
            if (props.Length > 7 && !string.IsNullOrWhiteSpace(props[7]) && bool.TryParse(props[7].Trim(), out bool parsedFin))
            {
                isFinished = parsedFin;
            }
            this.IsFinished = isFinished;

            string stage = "Group";
            if (props.Length > 8 && !string.IsNullOrWhiteSpace(props[8]))
            {
                stage = props[8].Split(';')[0].Trim();
            }
            this.Stage = stage;
        }

        public int Id { get; set; }
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }
        public int? HomeScore { get; set; }
        public int? AwayScore { get; set; }
        public DateTime MatchDate { get; set; }
        public List<string> Scorers { get; set; }
        public bool IsFinished { get; set; }
        public string Stage { get; set; }

        /// <summary>
        /// Retorna el identificador único del partido como cadena de texto.
        /// </summary>
        public string GetId()
        {
            return this.Id.ToString();
        }

        /// <summary>
        /// Convierte el partido a una línea de texto en formato CSV.
        /// </summary>
        public string ToCSVLine()
        {
            string homeScoreStr = this.HomeScore.HasValue ? this.HomeScore.Value.ToString() : string.Empty;
            string awayScoreStr = this.AwayScore.HasValue ? this.AwayScore.Value.ToString() : string.Empty;
            string scorersStr = this.Scorers != null ? string.Join(";", this.Scorers) : string.Empty;
            return $"{Id},{HomeTeam},{AwayTeam},{homeScoreStr},{awayScoreStr},{MatchDate:yyyy-MM-ddTHH:mm:ss},{scorersStr},{IsFinished},{Stage}";
        }

        /// <summary>
        /// Retorna el encabezado de columnas del CSV para partidos.
        /// </summary>
        public string GetHeader()
        {
            return "Id,HomeTeam,AwayTeam,HomeScore,AwayScore,MatchDate,Scorers,IsFinished,Stage";
        }
    }
}
