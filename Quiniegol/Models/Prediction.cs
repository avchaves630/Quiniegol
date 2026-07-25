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
            this.Username = props[0];
            this.MatchId = int.Parse(props[1]);
            this.PredictedHomeScore = int.Parse(props[2]);
            this.PredictedAwayScore = int.Parse(props[3]);
            this.DateCreated = DateTime.Parse(props[4]);
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
