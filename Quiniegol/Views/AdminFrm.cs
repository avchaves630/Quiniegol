using Quiniegol.Controllers;
using Quiniegol.Models;
using Quiniegol.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Quiniegol.Views
{
    /// <summary>
    /// Formulario de administración del torneo.
    /// </summary>
    public partial class AdminFrm : Form
    {
        private MatchController MatchController { get; set; }
        private UserController UserController { get; set; }
        private PredictionController PredictionController { get; set; }
        private QuinielaController QuinielaController { get; set; }

        public AdminFrm(MatchController matchController, UserController userController, PredictionController predictionController, QuinielaController quinielaController)
        {
            InitializeComponent();
            this.MatchController = matchController;
            this.UserController = userController;
            this.PredictionController = predictionController;
            this.QuinielaController = quinielaController;
        }

        private void AdminFrm_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.CenterParent;
            dtpSimulatedDate.Value = MatchController.SimulatedSystemDate;
            RefreshMatchesGrid();
        }

        private void RefreshMatchesGrid()
        {
            dgvMatches.DataSource = null;
            dgvMatches.Columns.Clear();

            var list = MatchController.Matches.Select(m => new {
                m.Id,
                Partido = $"{m.HomeTeam} vs {m.AwayTeam}",
                Fase = m.Stage,
                Estado = m.IsFinished ? "Finalizado" : "Pendiente",
                Marcador = m.IsFinished ? $"{m.HomeScore} - {m.AwayScore}" : "-"
            }).ToList();

            dgvMatches.DataSource = list;
            if (dgvMatches.Columns.Count > 0)
            {
                dgvMatches.Columns["Id"].Width = 40;
            }
        }

        private void btnUpdateDate_Click(object sender, EventArgs e)
        {
            var newDate = dtpSimulatedDate.Value;
            MatchController.SaveSimulatedDate(newDate);
            MessageBox.Show($"Fecha simulada del sistema actualizada a: {newDate:yyyy-MM-dd HH:mm}");
        }

        private void dgvMatches_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvMatches.SelectedRows.Count > 0)
            {
                var row = dgvMatches.SelectedRows[0];
                int id = Convert.ToInt32(row.Cells["Id"].Value);
                var match = MatchController.Matches.Find(m => m.Id == id);

                if (match != null)
                {
                    lblHomeTeamName.Text = match.HomeTeam;
                    lblAwayTeamName.Text = match.AwayTeam;
                    numHomeScore.Value = match.HomeScore ?? 0;
                    numAwayScore.Value = match.AwayScore ?? 0;
                    txtScorers.Text = match.Scorers != null ? string.Join(";", match.Scorers) : string.Empty;
                    chkFinished.Checked = match.IsFinished;
                }
            }
        }

        private void btnSaveMatch_Click(object sender, EventArgs e)
        {
            if (dgvMatches.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor seleccione un partido de la lista.");
                return;
            }

            var row = dgvMatches.SelectedRows[0];
            int matchId = Convert.ToInt32(row.Cells["Id"].Value);
            var match = MatchController.Matches.Find(m => m.Id == matchId);

            if (match != null)
            {
                var oldLeaders = new Dictionary<string, string>();
                foreach (var q in QuinielaController.Quinielas)
                {
                    var rank = QuinielaController.GetLeagueRanking(q.Id, UserController);
                    if (rank.Count > 0 && rank[0].Score > 0)
                    {
                        oldLeaders[q.Id] = rank[0].Username;
                    }
                }

                match.HomeScore = (int)numHomeScore.Value;
                match.AwayScore = (int)numAwayScore.Value;
                match.Scorers = string.IsNullOrWhiteSpace(txtScorers.Text) ? new List<string>() : txtScorers.Text.Split(';').Select(s => s.Trim()).ToList();
                match.IsFinished = chkFinished.Checked;

                bool saved = MatchController.SaveMatch(match);

                if (saved)
                {
                    if (match.IsFinished)
                    {
                        PredictionController.RecomputeAllUserScores(UserController, MatchController.Matches);

                        var matchPredictions = PredictionController.Predictions.Where(p => p.MatchId == match.Id).ToList();
                        foreach (var pred in matchPredictions)
                        {
                            int points = PredictionController.CalculatePoints(pred, match);
                            if (points > 0)
                            {
                                string msg = points == 5
                                    ? $"{pred.Username} acertó el marcador de {match.HomeTeam} vs {match.AwayTeam} ({match.HomeScore}-{match.AwayScore}) obteniendo 5 pts! 🎉"
                                    : $"{pred.Username} acertó el ganador de {match.HomeTeam} vs {match.AwayTeam} obteniendo 2 pts! 👍";

                                var user = UserController.FindUser(pred.Username);
                                if (user != null && user.Quinielas != null)
                                {
                                    foreach (var qId in user.Quinielas)
                                    {
                                        QuinielaController.AddNotification(qId, msg);
                                    }
                                }
                            }
                        }

                        UserController.RecalculateInsignias(PredictionController.Predictions, MatchController.Matches, QuinielaController.Quinielas);

                        foreach (var q in QuinielaController.Quinielas)
                        {
                            var rank = QuinielaController.GetLeagueRanking(q.Id, UserController);
                            if (rank.Count > 0 && rank[0].Score > 0)
                            {
                                string newLeader = rank[0].Username;
                                oldLeaders.TryGetValue(q.Id, out string oldLeader);

                                if (newLeader != oldLeader)
                                {
                                    QuinielaController.AddNotification(q.Id, $"¡NUEVO LÍDER! {rank[0].Name} ({newLeader}) ha tomado la cima de la tabla con {rank[0].Score} puntos! 👑");
                                }
                            }

                            if (rank.Count > 1)
                            {
                                var worstPlayer = rank.Last();
                                QuinielaController.AddNotification(q.Id, $"Muro de la Vergüenza: {worstPlayer.Name} ({worstPlayer.Username}) es actualmente el peor jugador de la liga con {worstPlayer.Score} puntos 💀");
                            }
                        }
                    }

                    MessageBox.Show("Partido actualizado y guardado correctamente.");
                    RefreshMatchesGrid();
                }
                else
                {
                    MessageBox.Show("Error al guardar los datos del partido.");
                }
            }
        }
    }
}
