using Quiniegol.Controllers.Abstractions;
using Quiniegol.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Quiniegol.Controllers
{
    /// <summary>
    /// Controlador que gestiona los pronósticos de los usuarios y el cálculo de puntajes.
    /// </summary>
    public class PredictionController
    {
        private IDataHandler<Prediction> DataHandler { get; set; }
        private string FilePath { get; set; }

        public List<Prediction> Predictions { get; private set; }

        public PredictionController(IDataHandler<Prediction> dataHandler, string filePath)
        {
            this.DataHandler = dataHandler;
            this.FilePath = filePath;
            this.Load();
        }

        /// <summary>
        /// Recarga los pronósticos desde el archivo de datos.
        /// </summary>
        public void Load()
        {
            this.Predictions = this.DataHandler.Load(FilePath) ?? new List<Prediction>();
        }

        /// <summary>
        /// Guarda o actualiza el pronóstico de un usuario para un partido.
        /// </summary>
        public bool SavePrediction(string username, int matchId, int predictedHome, int predictedAway, DateTime simulatedSystemDate, Match match)
        {
            if (match.MatchDate <= simulatedSystemDate)
            {
                return false;
            }

            var id = $"{username}_{matchId}";
            var existing = this.Predictions.Find(p => p.GetId().Equals(id, StringComparison.OrdinalIgnoreCase));

            if (existing != null)
            {
                existing.PredictedHomeScore = predictedHome;
                existing.PredictedAwayScore = predictedAway;
                existing.DateCreated = simulatedSystemDate;
                return this.DataHandler.Update(FilePath, existing);
            }
            else
            {
                var newPred = new Prediction(username, matchId, predictedHome, predictedAway, simulatedSystemDate);
                this.Predictions.Add(newPred);
                return this.DataHandler.Create(FilePath, newPred);
            }
        }

        /// <summary>
        /// Retorna todos los pronósticos realizados por el usuario indicado.
        /// </summary>
        public List<Prediction> GetPredictionsForUser(string username)
        {
            return this.Predictions.Where(p => p.Username.Equals(username, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        /// <summary>
        /// Calcula los puntos obtenidos por un pronóstico según el resultado real del partido.
        /// </summary>
        public int CalculatePoints(Prediction pred, Match match)
        {
            if (pred == null || match == null || !match.IsFinished || !match.HomeScore.HasValue || !match.AwayScore.HasValue)
            {
                return 0;
            }

            int actH = match.HomeScore.Value;
            int actA = match.AwayScore.Value;
            int predH = pred.PredictedHomeScore;
            int predA = pred.PredictedAwayScore;

            if (actH == predH && actA == predA)
            {
                return 5;
            }

            if ((actH > actA && predH > predA) ||
                (actH < actA && predH < predA) ||
                (actH == actA && predH == predA))
            {
                return 2;
            }

            return 0;
        }

        /// <summary>
        /// Recalcula el puntaje de todos los usuarios en base a los pronósticos y partidos finalizados.
        /// </summary>
        public void RecomputeAllUserScores(UserController userController, List<Match> allMatches)
        {
            var finishedMatches = allMatches.Where(m => m.IsFinished).ToList();

            foreach (var user in userController.Users.ToList())
            {
                var userPreds = this.Predictions.Where(p => p.Username.Equals(user.Username, StringComparison.OrdinalIgnoreCase)).ToList();
                int totalScore = 0;

                foreach (var pred in userPreds)
                {
                    var match = finishedMatches.Find(m => m.Id == pred.MatchId);
                    if (match != null)
                    {
                        totalScore += CalculatePoints(pred, match);
                    }
                }

                userController.UpdateScore(user.Username, totalScore);
            }
        }
    }
}
