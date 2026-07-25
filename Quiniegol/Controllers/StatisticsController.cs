using Quiniegol.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Quiniegol.Controllers
{
    /// <summary>
    /// Controlador encargado de calcular estadísticas en tiempo real dentro de un rango de fechas.
    /// </summary>
    public class StatisticsController
    {
        /// <summary>
        /// Calcula todas las estadísticas del torneo para el rango de fechas indicado.
        /// </summary>
        public Dictionary<string, string> ComputeStats(List<Match> allMatches, List<Prediction> allPredictions, List<User> allUsers, DateTime start, DateTime end)
        {
            var stats = new Dictionary<string, string>
            {
                { "MostBetTeam", "N/A" },
                { "MostRepeatedResult", "N/A" },
                { "MostCorrectMatch", "N/A" },
                { "MostCorrectUser", "N/A" },
                { "MostPredictedMatch", "N/A" },
                { "SurpriseTeam", "N/A" },
                { "AverageGoals", "0.0" }
            };

            var matchesInRange = allMatches.Where(m => m.MatchDate >= start && m.MatchDate <= end).ToList();
            if (matchesInRange.Count == 0) return stats;

            var matchIdsInRange = matchesInRange.Select(m => m.Id).ToHashSet();

            var predictionsInRange = allPredictions.Where(p => p.DateCreated >= start && p.DateCreated <= end && matchIdsInRange.Contains(p.MatchId)).ToList();

            var teamWinBets = new Dictionary<string, int>();
            foreach (var pred in predictionsInRange)
            {
                var match = matchesInRange.Find(m => m.Id == pred.MatchId);
                if (match != null)
                {
                    if (pred.PredictedHomeScore > pred.PredictedAwayScore)
                    {
                        teamWinBets[match.HomeTeam] = teamWinBets.ContainsKey(match.HomeTeam) ? teamWinBets[match.HomeTeam] + 1 : 1;
                    }
                    else if (pred.PredictedAwayScore > pred.PredictedHomeScore)
                    {
                        teamWinBets[match.AwayTeam] = teamWinBets.ContainsKey(match.AwayTeam) ? teamWinBets[match.AwayTeam] + 1 : 1;
                    }
                }
            }
            if (teamWinBets.Count > 0)
            {
                stats["MostBetTeam"] = teamWinBets.OrderByDescending(kv => kv.Value).First().Key;
            }

            var finishedMatchesInRange = matchesInRange.Where(m => m.IsFinished && m.HomeScore.HasValue && m.AwayScore.HasValue).ToList();
            if (finishedMatchesInRange.Count > 0)
            {
                var results = finishedMatchesInRange.Select(m => $"{m.HomeScore.Value}-{m.AwayScore.Value}");
                var resultCounts = results.GroupBy(r => r).ToDictionary(g => g.Key, g => g.Count());
                stats["MostRepeatedResult"] = resultCounts.OrderByDescending(kv => kv.Value).First().Key;
            }

            if (finishedMatchesInRange.Count > 0 && predictionsInRange.Count > 0)
            {
                var matchCorrectCounts = new Dictionary<int, int>();
                foreach (var match in finishedMatchesInRange)
                {
                    int correctCount = 0;
                    var matchPreds = predictionsInRange.Where(p => p.MatchId == match.Id).ToList();
                    foreach (var pred in matchPreds)
                    {
                        int actH = match.HomeScore.Value;
                        int actA = match.AwayScore.Value;
                        int predH = pred.PredictedHomeScore;
                        int predA = pred.PredictedAwayScore;

                        if ((actH == predH && actA == predA) ||
                            (actH > actA && predH > predA) ||
                            (actH < actA && predH < predA) ||
                            (actH == actA && predH == predA))
                        {
                            correctCount++;
                        }
                    }
                    matchCorrectCounts[match.Id] = correctCount;
                }
                if (matchCorrectCounts.Count > 0)
                {
                    int bestMatchId = matchCorrectCounts.OrderByDescending(kv => kv.Value).First().Key;
                    var bm = matchesInRange.Find(m => m.Id == bestMatchId);
                    if (bm != null)
                    {
                        stats["MostCorrectMatch"] = $"{bm.HomeTeam} vs {bm.AwayTeam} ({matchCorrectCounts[bestMatchId]} aciertos)";
                    }
                }
            }

            if (predictionsInRange.Count > 0 && finishedMatchesInRange.Count > 0)
            {
                var userCorrectCounts = new Dictionary<string, int>();
                foreach (var pred in predictionsInRange)
                {
                    var match = finishedMatchesInRange.Find(m => m.Id == pred.MatchId);
                    if (match != null)
                    {
                        int actH = match.HomeScore.Value;
                        int actA = match.AwayScore.Value;
                        int predH = pred.PredictedHomeScore;
                        int predA = pred.PredictedAwayScore;

                        if ((actH == predH && actA == predA) ||
                            (actH > actA && predH > predA) ||
                            (actH < actA && predH < predA) ||
                            (actH == actA && predH == predA))
                        {
                            userCorrectCounts[pred.Username] = userCorrectCounts.ContainsKey(pred.Username) ? userCorrectCounts[pred.Username] + 1 : 1;
                        }
                    }
                }
                if (userCorrectCounts.Count > 0)
                {
                    stats["MostCorrectUser"] = userCorrectCounts.OrderByDescending(kv => kv.Value).First().Key;
                }
            }

            if (predictionsInRange.Count > 0)
            {
                var matchPredCounts = predictionsInRange.GroupBy(p => p.MatchId).ToDictionary(g => g.Key, g => g.Count());
                if (matchPredCounts.Count > 0)
                {
                    int matchId = matchPredCounts.OrderByDescending(kv => kv.Value).First().Key;
                    var match = matchesInRange.Find(m => m.Id == matchId);
                    if (match != null)
                    {
                        stats["MostPredictedMatch"] = $"{match.HomeTeam} vs {match.AwayTeam} ({matchPredCounts[matchId]} pronósticos)";
                    }
                }
            }

            if (finishedMatchesInRange.Count > 0)
            {
                var surpriseScores = new Dictionary<string, int>();
                foreach (var m in finishedMatchesInRange)
                {
                    if (m.HomeScore == m.AwayScore) continue;

                    string winner = m.HomeScore > m.AwayScore ? m.HomeTeam : m.AwayTeam;
                    string loser = m.HomeScore > m.AwayScore ? m.AwayTeam : m.HomeTeam;

                    var preds = predictionsInRange.Where(p => p.MatchId == m.Id).ToList();
                    if (preds.Count == 0) continue;

                    int predWinnerWins = 0;
                    int predLoserWins = 0;

                    foreach (var p in preds)
                    {
                        if (winner == m.HomeTeam)
                        {
                            if (p.PredictedHomeScore > p.PredictedAwayScore) predWinnerWins++;
                            if (p.PredictedAwayScore > p.PredictedHomeScore) predLoserWins++;
                        }
                        else
                        {
                            if (p.PredictedAwayScore > p.PredictedHomeScore) predWinnerWins++;
                            if (p.PredictedHomeScore > p.PredictedAwayScore) predLoserWins++;
                        }
                    }

                    if (predLoserWins > predWinnerWins)
                    {
                        surpriseScores[winner] = surpriseScores.ContainsKey(winner) ? surpriseScores[winner] + 1 : 1;
                    }
                }
                if (surpriseScores.Count > 0)
                {
                    stats["SurpriseTeam"] = surpriseScores.OrderByDescending(kv => kv.Value).First().Key;
                }
            }

            if (finishedMatchesInRange.Count > 0)
            {
                double totalGoals = finishedMatchesInRange.Sum(m => (m.HomeScore ?? 0) + (m.AwayScore ?? 0));
                double avg = totalGoals / finishedMatchesInRange.Count;
                stats["AverageGoals"] = avg.ToString("0.00");
            }

            return stats;
        }
    }
}
