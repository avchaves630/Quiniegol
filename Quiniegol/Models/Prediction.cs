using System;

namespace Quiniegol.Models
{
    /// <summary>
    /// Modelo que representa el pronóstico de un usuario para un partido.
    /// </summary>
    public class Prediction : ICSVSerializable, IIdentifiable
    {
        public Prediction(string username, int matchId, int predictedHomeScore, int predictedAwayScore, DateTime dateCreated)
        {
            this.Username = username;
            this.MatchId = matchId;
            this.PredictedHomeScore = predictedHomeScore;
            this.PredictedAwayScore = predictedAwayScore;
            this.DateCreated = dateCreated;
        }

        public Prediction(string[] props)
        {
            this.Username = props.Length > 0 ? props[0].Trim() : string.Empty;

            int matchId = 0;
            if (props.Length > 1 && !string.IsNullOrWhiteSpace(props[1]) && int.TryParse(props[1].Trim(), out int parsedId))
            {
                matchId = parsedId;
            }
            this.MatchId = matchId;

            int homeP = 0;
            if (props.Length > 2 && !string.IsNullOrWhiteSpace(props[2]) && int.TryParse(props[2].Trim(), out int parsedHome))
            {
                homeP = parsedHome;
            }
            this.PredictedHomeScore = homeP;

            int awayP = 0;
            if (props.Length > 3 && !string.IsNullOrWhiteSpace(props[3]) && int.TryParse(props[3].Trim(), out int parsedAway))
            {
                awayP = parsedAway;
            }
            this.PredictedAwayScore = awayP;

            DateTime dt = DateTime.Now;
            if (props.Length > 4 && !string.IsNullOrWhiteSpace(props[4]) && DateTime.TryParse(props[4].Trim(), out DateTime parsedDt))
            {
                dt = parsedDt;
            }
            this.DateCreated = dt;
        }

        public string Username { get; set; }
        public int MatchId { get; set; }
        public int PredictedHomeScore { get; set; }
        public int PredictedAwayScore { get; set; }
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// Retorna el identificador único del pronóstico como combinación de usuario y partido.
        /// </summary>
        public string GetId()
        {
            return $"{Username}_{MatchId}";
        }

        /// <summary>
        /// Convierte el pronóstico a una línea de texto en formato CSV.
        /// </summary>
        public string ToCSVLine()
        {
            return $"{Username},{MatchId},{PredictedHomeScore},{PredictedAwayScore},{DateCreated:yyyy-MM-ddTHH:mm:ss}";
        }

        /// <summary>
        /// Retorna el encabezado de columnas del CSV para pronósticos.
        /// </summary>
        public string GetHeader()
        {
            return "Username,MatchId,PredictedHomeScore,PredictedAwayScore,DateCreated";
        }
    }
}
