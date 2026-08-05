using Quiniegol.Controllers;
using Quiniegol.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Quiniegol.Views
{
    /// <summary>
    /// Formulario de visualización de estadísticas del torneo.
    /// </summary>
    public partial class StatisticsFrm : Form
    {
        private List<Match> Matches { get; set; }
        private List<Prediction> Predictions { get; set; }
        private List<User> Users { get; set; }
        private StatisticsController StatisticsController { get; set; }

        public StatisticsFrm()
        {
            InitializeComponent();
            this.StatisticsController = new StatisticsController();
        }

        public StatisticsFrm(List<Match> matches, List<Prediction> predictions, List<User> users)
            : this()
        {
            this.Matches = matches;
            this.Predictions = predictions;
            this.Users = users;
        }

        private void StatisticsFrm_Load(object sender, EventArgs e)
        {
            if (DesignMode || System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime)
                return;

            this.StartPosition = FormStartPosition.CenterParent;
            dtpStart.Value = new DateTime(2026, 7, 10, 0, 0, 0);
            dtpEnd.Value = new DateTime(2026, 7, 30, 23, 59, 59);

            if (Matches != null && Predictions != null && Users != null)
            {
                ComputeAndDisplayStats();
            }
        }

        private void btnCompute_Click(object sender, EventArgs e)
        {
            ComputeAndDisplayStats();
        }

        private void ComputeAndDisplayStats()
        {
            var start = dtpStart.Value;
            var end = dtpEnd.Value;

            if (start > end)
            {
                MessageBox.Show("La fecha inicial no puede ser mayor que la fecha final.");
                return;
            }

            var stats = StatisticsController.ComputeStats(Matches, Predictions, Users, start, end);

            lblMostBetVal.Text = stats["MostBetTeam"];
            lblRepeatedResultVal.Text = stats["MostRepeatedResult"];
            lblMostCorrectMatchVal.Text = stats["MostCorrectMatch"];
            lblMostCorrectUserVal.Text = stats["MostCorrectUser"];
            lblMostPredVal.Text = stats["MostPredictedMatch"];
            lblSurpriseVal.Text = stats["SurpriseTeam"];
            lblAvgGoalsVal.Text = stats["AverageGoals"];
        }
    }
}
