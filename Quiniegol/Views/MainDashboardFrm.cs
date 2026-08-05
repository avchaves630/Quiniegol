using Quiniegol.Controllers;
using Quiniegol.Models;
using Quiniegol.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Quiniegol.Views
{
    /// <summary>
    /// Formulario principal del panel de control de la aplicación.
    /// </summary>
    public partial class MainDashboardFrm : Form
    {
        private User CurrentUser { get; set; }
        private UserController UserController { get; set; }
        private MatchController MatchController { get; set; }
        private PredictionController PredictionController { get; set; }
        private QuinielaController QuinielaController { get; set; }

        public MainDashboardFrm()
        {
            InitializeComponent();
        }

        public MainDashboardFrm(User user, UserController userController, MatchController matchController, PredictionController predictionController, QuinielaController quinielaController)
            : this()
        {
            this.CurrentUser = user;
            this.UserController = userController;
            this.MatchController = matchController;
            this.PredictionController = predictionController;
            this.QuinielaController = quinielaController;
        }

        private void MainDashboardFrm_Load(object sender, EventArgs e)
        {
            if (DesignMode || System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime)
                return;

            btnAdmin.Visible = CurrentUser != null && CurrentUser.Username.Equals("admin", StringComparison.OrdinalIgnoreCase);
            cmbGroupSelect.SelectedIndex = 0;
            ShowPanel(pnlPredictions);
            RefreshAllData();
        }

        private void RefreshAllData()
        {
            UserController.Load();
            MatchController.Load();
            PredictionController.Load();
            QuinielaController.Load();

            PredictionController.RecomputeAllUserScores(UserController, MatchController.Matches);
            UserController.RecalculateInsignias(PredictionController.Predictions, MatchController.Matches, QuinielaController.Quinielas);

            CurrentUser = UserController.FindUser(CurrentUser.Username) ?? CurrentUser;

            string insigniasStr = CurrentUser.Insignias.Count > 0 ? string.Join(", ", CurrentUser.Insignias) : "Ninguna";
            lblUserProfile.Text = $"Usuario: {CurrentUser.Name} ({CurrentUser.Username}) | País: {CurrentUser.PreferredCountry} | Puntos: {CurrentUser.Score} | Insignias: {insigniasStr}";
            lblDate.Text = $"Fecha Simulada del Sistema: {MatchController.SimulatedSystemDate:yyyy-MM-dd HH:mm}";

            RefreshPredictionsPanel();
            RefreshHistoryPanel();
            RefreshMatchesPanel();
            RefreshRankingsPanel();
            RefreshLeaguesPanel();
        }

        private void ShowPanel(Panel activePanel)
        {
            pnlPredictions.Visible = (activePanel == pnlPredictions);
            pnlHistory.Visible = (activePanel == pnlHistory);
            pnlMatches.Visible = (activePanel == pnlMatches);
            pnlRankings.Visible = (activePanel == pnlRankings);
            pnlLeagues.Visible = (activePanel == pnlLeagues);
        }

        #region Navigation Click Events
        private void btnNavPredictions_Click(object sender, EventArgs e)
        {
            RefreshPredictionsPanel();
            ShowPanel(pnlPredictions);
        }

        private void btnNavHistory_Click(object sender, EventArgs e)
        {
            RefreshHistoryPanel();
            ShowPanel(pnlHistory);
        }

        private void btnNavMatches_Click(object sender, EventArgs e)
        {
            RefreshMatchesPanel();
            ShowPanel(pnlMatches);
        }

        private void btnNavRankings_Click(object sender, EventArgs e)
        {
            RefreshRankingsPanel();
            ShowPanel(pnlRankings);
        }

        private void btnNavLeagues_Click(object sender, EventArgs e)
        {
            RefreshLeaguesPanel();
            ShowPanel(pnlLeagues);
        }
        #endregion

        #region Predictions Panel Logic
        private void RefreshPredictionsPanel()
        {
            dgvPredictionsMatches.DataSource = null;
            dgvPredictionsMatches.Columns.Clear();

            var futureMatches = MatchController.Matches
                .Where(m => m.MatchDate > MatchController.SimulatedSystemDate)
                .OrderBy(m => m.MatchDate)
                .ToList();

            var displayList = futureMatches.Select(m => {
                var userPred = PredictionController.Predictions.Find(p => p.Username.Equals(CurrentUser.Username, StringComparison.OrdinalIgnoreCase) && p.MatchId == m.Id);
                return new {
                    m.Id,
                    Partido = $"{m.HomeTeam} vs {m.AwayTeam}",
                    Fecha = m.MatchDate.ToString("yyyy-MM-dd HH:mm"),
                    Grupos = m.Stage,
                    MiPronostico = userPred != null ? $"{userPred.PredictedHomeScore} - {userPred.PredictedAwayScore}" : "No realizado"
                };
            }).ToList();

            dgvPredictionsMatches.DataSource = displayList;
            if (dgvPredictionsMatches.Columns.Count > 0)
            {
                dgvPredictionsMatches.Columns["Id"].Width = 40;
                dgvPredictionsMatches.Columns["MiPronostico"].HeaderText = "Mi Pronóstico";
            }
        }

        private void dgvPredictionsMatches_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPredictionsMatches.SelectedRows.Count > 0)
            {
                var row = dgvPredictionsMatches.SelectedRows[0];
                int matchId = Convert.ToInt32(row.Cells["Id"].Value);
                var match = MatchController.Matches.Find(m => m.Id == matchId);

                if (match != null)
                {
                    lblHomePredTeam.Text = match.HomeTeam;
                    lblAwayPredTeam.Text = match.AwayTeam;

                    var userPred = PredictionController.Predictions.Find(p => p.Username.Equals(CurrentUser.Username, StringComparison.OrdinalIgnoreCase) && p.MatchId == matchId);
                    if (userPred != null)
                    {
                        numHomePred.Value = userPred.PredictedHomeScore;
                        numAwayPred.Value = userPred.PredictedAwayScore;
                    }
                    else
                    {
                        numHomePred.Value = 0;
                        numAwayPred.Value = 0;
                    }
                }
            }
        }

        private void btnSavePrediction_Click(object sender, EventArgs e)
        {
            if (dgvPredictionsMatches.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor seleccione un partido de la lista.");
                return;
            }

            var row = dgvPredictionsMatches.SelectedRows[0];
            int matchId = Convert.ToInt32(row.Cells["Id"].Value);
            var match = MatchController.Matches.Find(m => m.Id == matchId);

            if (match != null)
            {
                int homeP = (int)numHomePred.Value;
                int awayP = (int)numAwayPred.Value;

                bool saved = PredictionController.SavePrediction(
                    CurrentUser.Username,
                    matchId,
                    homeP,
                    awayP,
                    MatchController.SimulatedSystemDate,
                    match
                );

                if (saved)
                {
                    MessageBox.Show("Pronóstico guardado correctamente.");
                    RefreshPredictionsPanel();
                }
                else
                {
                    MessageBox.Show("No se pudo guardar el pronóstico. El partido ya ha iniciado.");
                }
            }
        }
        #endregion

        #region Prediction History Logic
        private void RefreshHistoryPanel()
        {
            dgvHistory.DataSource = null;
            dgvHistory.Columns.Clear();

            var userPreds = PredictionController.GetPredictionsForUser(CurrentUser.Username);
            var displayList = userPreds.Select(p => {
                var match = MatchController.Matches.Find(m => m.Id == p.MatchId);
                int points = match != null && match.IsFinished ? PredictionController.CalculatePoints(p, match) : 0;
                string actScore = match != null && match.IsFinished ? $"{match.HomeScore} - {match.AwayScore}" : "Pendiente";
                return new {
                    FechaPronostico = p.DateCreated.ToString("yyyy-MM-dd HH:mm"),
                    Partido = match != null ? $"{match.HomeTeam} vs {match.AwayTeam}" : "Desconocido",
                    Pronostico = $"{p.PredictedHomeScore} - {p.PredictedAwayScore}",
                    MarcadorReal = actScore,
                    Estado = match != null && match.IsFinished ? "Finalizado" : "No Jugado",
                    PuntosGanados = match != null && match.IsFinished ? points.ToString() : "-"
                };
            }).ToList();

            dgvHistory.DataSource = displayList;
            if (dgvHistory.Columns.Count > 0)
            {
                dgvHistory.Columns["FechaPronostico"].HeaderText = "Fecha Pronóstico";
                dgvHistory.Columns["MarcadorReal"].HeaderText = "Marcador Real";
                dgvHistory.Columns["PuntosGanados"].HeaderText = "Puntos Ganados";
            }
        }
        #endregion

        #region Matches Sub-Panels Logic
        private void RefreshMatchesPanel()
        {
            var last5 = MatchController.Matches
                .Where(m => m.IsFinished)
                .OrderByDescending(m => m.MatchDate)
                .Take(5)
                .Select(m => new {
                    Fecha = m.MatchDate.ToString("yyyy-MM-dd HH:mm"),
                    Partido = $"{m.HomeTeam} vs {m.AwayTeam}",
                    Marcador = $"{m.HomeScore} - {m.AwayScore}",
                    Anotadores = m.Scorers != null ? string.Join(", ", m.Scorers) : "",
                    Grupos = m.Stage
                }).ToList();
            dgvLast5.DataSource = last5;

            var next24 = MatchController.Matches
                .Where(m => !m.IsFinished && m.MatchDate > MatchController.SimulatedSystemDate && m.MatchDate <= MatchController.SimulatedSystemDate.AddHours(24))
                .OrderBy(m => m.MatchDate)
                .Select(m => new {
                    Id = m.Id,
                    Fecha = m.MatchDate.ToString("yyyy-MM-dd HH:mm"),
                    Partido = $"{m.HomeTeam} vs {m.AwayTeam}",
                    Grupos = m.Stage
                }).ToList();
            dgvNext24.DataSource = next24;

            RefreshGroupStandings();
        }

        private void RefreshGroupStandings()
        {
            if (cmbGroupSelect.SelectedItem == null) return;
            string selectedGroupText = cmbGroupSelect.SelectedItem.ToString();
            string groupName = selectedGroupText.Replace("Grupo ", "").Trim();

            var standings = MatchController.GetStandingsForGroup(groupName);
            dgvGroupStandings.DataSource = standings.Select((r, idx) => new {
                Pos = idx + 1,
                Seleccion = r.TeamName,
                PJ = r.Played,
                PG = r.Won,
                PE = r.Drawn,
                PP = r.Lost,
                GF = r.GoalsFor,
                GC = r.GoalsAgainst,
                DG = r.GoalDifference,
                Pts = r.Points
            }).ToList();

            if (dgvGroupStandings.Columns.Count > 0)
            {
                dgvGroupStandings.Columns["Pos"].Width = 40;
                dgvGroupStandings.Columns["Seleccion"].HeaderText = "Selección";
            }
        }

        private void cmbGroupSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshGroupStandings();
        }

        private void tabMatchesSub_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshMatchesPanel();
        }
        #endregion

        #region Global Rankings Logic
        private void RefreshRankingsPanel()
        {
            var rankList = UserController.GetRankingByScoreDesc();
            var display = rankList.Select((u, idx) => new {
                Rank = idx + 1,
                Nombre = u.Name,
                Usuario = u.Username,
                Puntos = u.Score,
                PaisFavorito = u.PreferredCountry,
                Insignias = string.Join(", ", u.Insignias)
            }).ToList();

            dgvRankings.DataSource = display;
            if (dgvRankings.Columns.Count > 0)
            {
                dgvRankings.Columns["Rank"].Width = 45;
                dgvRankings.Columns["PaisFavorito"].HeaderText = "País Favorito";
            }
        }
        #endregion

        #region Leagues (Quinielas) Panel Logic
        private void RefreshLeaguesPanel()
        {
            lstLeagues.Items.Clear();
            var myLeagues = QuinielaController.GetQuinielasForUser(CurrentUser.Username);
            foreach (var q in myLeagues)
            {
                lstLeagues.Items.Add(q.Id);
            }

            if (lstLeagues.Items.Count > 0)
            {
                lstLeagues.SelectedIndex = 0;
            }
            else
            {
                dgvLeagueRanking.DataSource = null;
                lstTimeline.Items.Clear();
            }
        }

        private void lstLeagues_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstLeagues.SelectedItem != null)
            {
                string leagueId = lstLeagues.SelectedItem.ToString();
                var q = QuinielaController.FindQuiniela(leagueId);

                if (q != null)
                {
                    lblLeagueRanking.Text = $"Tabla de posiciones - {q.Name} ({(q.IsPrivate ? "Privada" : "Pública")})";

                    var rankingList = QuinielaController.GetLeagueRanking(leagueId, UserController);
                    dgvLeagueRanking.DataSource = rankingList.Select((u, idx) => new {
                        Pos = idx + 1,
                        Nombre = u.Name,
                        Usuario = u.Username,
                        Puntos = u.Score,
                        Insignias = string.Join(", ", u.Insignias.Where(ins => ins.Contains(q.Name)))
                    }).ToList();

                    if (dgvLeagueRanking.Columns.Count > 0)
                    {
                        dgvLeagueRanking.Columns["Pos"].Width = 40;
                    }

                    lstTimeline.Items.Clear();
                    foreach (var item in q.NotificationTimeline)
                    {
                        lstTimeline.Items.Add(item);
                    }
                }
            }
        }

        private void btnCreateLeague_Click(object sender, EventArgs e)
        {
            using (var prompt = new Form())
            {
                prompt.Width = 350;
                prompt.Height = 250;
                prompt.Text = "Crear Nueva Quiniela";
                prompt.FormBorderStyle = FormBorderStyle.FixedDialog;
                prompt.MaximizeBox = false;

                Label lblId = new Label() { Left = 20, Top = 20, Text = "Código Único (ID):", Width = 150 };
                TextBox txtId = new TextBox() { Left = 20, Top = 40, Width = 280 };
                Label lblName = new Label() { Left = 20, Top = 70, Text = "Nombre de la Quiniela:", Width = 150 };
                TextBox txtName = new TextBox() { Left = 20, Top = 90, Width = 280 };
                CheckBox chkPrivate = new CheckBox() { Left = 20, Top = 130, Text = "Es Privada?", Checked = true };

                Button confirmation = new Button() { Text = "Crear", Left = 110, Width = 100, Top = 160, DialogResult = DialogResult.OK };
                confirmation.Click += (s, ev) => prompt.Close();

                prompt.Controls.Add(lblId);
                prompt.Controls.Add(txtId);
                prompt.Controls.Add(lblName);
                prompt.Controls.Add(txtName);
                prompt.Controls.Add(chkPrivate);
                prompt.Controls.Add(confirmation);

                prompt.StartPosition = FormStartPosition.CenterParent;

                if (prompt.ShowDialog() == DialogResult.OK)
                {
                    string id = txtId.Text.Trim();
                    string name = txtName.Text.Trim();
                    bool isPriv = chkPrivate.Checked;

                    if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(name))
                    {
                        MessageBox.Show("Por favor complete todos los datos.");
                        return;
                    }

                    bool created = QuinielaController.CreateQuiniela(id, name, isPriv, CurrentUser.Username);
                    if (created)
                    {
                        CurrentUser.Quinielas.Add(id);
                        UserController.SaveUser(CurrentUser);

                        MessageBox.Show("¡Quiniela creada correctamente!");
                        RefreshAllData();
                    }
                    else
                    {
                        MessageBox.Show("Error al crear. Es posible que el Código ID ya esté en uso.");
                    }
                }
            }
        }

        private void btnJoinLeague_Click(object sender, EventArgs e)
        {
            string id = txtJoinLeagueId.Text.Trim();
            if (string.IsNullOrEmpty(id))
            {
                MessageBox.Show("Por favor ingrese el código de la quiniela.");
                return;
            }

            var q = QuinielaController.FindQuiniela(id);
            if (q == null)
            {
                MessageBox.Show("No se encontró ninguna quiniela con ese código.");
                return;
            }

            bool joined = QuinielaController.JoinQuiniela(id, CurrentUser.Username);
            if (joined)
            {
                if (!CurrentUser.Quinielas.Contains(id, StringComparer.OrdinalIgnoreCase))
                {
                    CurrentUser.Quinielas.Add(id);
                    UserController.SaveUser(CurrentUser);
                }

                MessageBox.Show($"Te has unido exitosamente a la quiniela: {q.Name}");
                txtJoinLeagueId.Clear();
                RefreshAllData();
            }
            else
            {
                MessageBox.Show("Error al unirse a la quiniela.");
            }
        }
        #endregion

        #region Header Click Events (Admin, Stats, Logout)
        private void btnAdmin_Click(object sender, EventArgs e)
        {
            var adminFrm = new AdminFrm(MatchController, UserController, PredictionController, QuinielaController);
            adminFrm.FormClosed += (s, args) => RefreshAllData();
            adminFrm.ShowDialog();
        }

        private void btnStats_Click(object sender, EventArgs e)
        {
            var statsFrm = new StatisticsFrm(MatchController.Matches, PredictionController.Predictions, UserController.Users);
            statsFrm.ShowDialog();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();

            var loginFrm = new LoginFrm(new LoginController(UserController), MatchController, PredictionController, QuinielaController);
            loginFrm.Show();

            this.Dispose();
        }
        #endregion
    }
}
