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
            this.Id = int.Parse(props[0]);
            this.HomeTeam = props[1];
            this.AwayTeam = props[2];
            this.HomeScore = string.IsNullOrEmpty(props[3]) ? (int?)null : int.Parse(props[3]);
            this.AwayScore = string.IsNullOrEmpty(props[4]) ? (int?)null : int.Parse(props[4]);
            this.MatchDate = DateTime.Parse(props[5]);
            this.Scorers = new List<string>();
            if (props.Length > 6 && !string.IsNullOrEmpty(props[6]))
            {
                this.Scorers = props[6].Split(';').ToList();
            }
            this.IsFinished = props.Length > 7 && bool.Parse(props[7]);
            this.Stage = props.Length > 8 ? props[8] : "Group";
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
