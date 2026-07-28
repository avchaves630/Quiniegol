namespace Quiniegol.Views
{
    partial class MainDashboardFrm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.btnNavLeagues = new System.Windows.Forms.Button();
            this.btnNavRankings = new System.Windows.Forms.Button();
            this.btnNavMatches = new System.Windows.Forms.Button();
            this.btnNavHistory = new System.Windows.Forms.Button();
            this.btnNavPredictions = new System.Windows.Forms.Button();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.btnStats = new System.Windows.Forms.Button();
            this.btnAdmin = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblUserProfile = new System.Windows.Forms.Label();
            this.lblAppTitle = new System.Windows.Forms.Label();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.pnlPredictions = new System.Windows.Forms.Panel();
            this.btnSavePrediction = new System.Windows.Forms.Button();
            this.lblPredictionVs = new System.Windows.Forms.Label();
            this.numAwayPred = new System.Windows.Forms.NumericUpDown();
            this.numHomePred = new System.Windows.Forms.NumericUpDown();
            this.lblAwayPredTeam = new System.Windows.Forms.Label();
            this.lblHomePredTeam = new System.Windows.Forms.Label();
            this.dgvPredictionsMatches = new System.Windows.Forms.DataGridView();
            this.lblPredictionsTitle = new System.Windows.Forms.Label();
            this.pnlHistory = new System.Windows.Forms.Panel();
            this.dgvHistory = new System.Windows.Forms.DataGridView();
            this.lblHistoryTitle = new System.Windows.Forms.Label();
            this.pnlMatches = new System.Windows.Forms.Panel();
            this.tabMatchesSub = new System.Windows.Forms.TabControl();
            this.tabLast5 = new System.Windows.Forms.TabPage();
            this.dgvLast5 = new System.Windows.Forms.DataGridView();
            this.tabNext24 = new System.Windows.Forms.TabPage();
            this.dgvNext24 = new System.Windows.Forms.DataGridView();
            this.tabGroups = new System.Windows.Forms.TabPage();
            this.cmbGroupSelect = new System.Windows.Forms.ComboBox();
            this.dgvGroupStandings = new System.Windows.Forms.DataGridView();
            this.tabBrackets = new System.Windows.Forms.TabPage();
            this.dgvBrackets = new System.Windows.Forms.DataGridView();
            this.lblMatchesTitle = new System.Windows.Forms.Label();
            this.pnlRankings = new System.Windows.Forms.Panel();
            this.dgvRankings = new System.Windows.Forms.DataGridView();
            this.lblRankingsTitle = new System.Windows.Forms.Label();
            this.pnlLeagues = new System.Windows.Forms.Panel();
            this.btnJoinLeague = new System.Windows.Forms.Button();
            this.btnCreateLeague = new System.Windows.Forms.Button();
            this.txtJoinLeagueId = new System.Windows.Forms.TextBox();
            this.lblTimeline = new System.Windows.Forms.Label();
            this.lblLeagueRanking = new System.Windows.Forms.Label();
            this.lstTimeline = new System.Windows.Forms.ListBox();
            this.dgvLeagueRanking = new System.Windows.Forms.DataGridView();
            this.lstLeagues = new System.Windows.Forms.ListBox();
            this.lblLeaguesListTitle = new System.Windows.Forms.Label();
            this.lblLeaguesTitle = new System.Windows.Forms.Label();
            this.pnlSidebar.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.pnlPredictions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAwayPred)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHomePred)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPredictionsMatches)).BeginInit();
            this.pnlHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).BeginInit();
            this.pnlMatches.SuspendLayout();
            this.tabMatchesSub.SuspendLayout();
            this.tabLast5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLast5)).BeginInit();
            this.tabNext24.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNext24)).BeginInit();
            this.tabGroups.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGroupStandings)).BeginInit();
            this.tabBrackets.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBrackets)).BeginInit();
            this.pnlRankings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRankings)).BeginInit();
            this.pnlLeagues.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLeagueRanking)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlSidebar
            // 
            this.pnlSidebar.Controls.Add(this.btnNavLeagues);
            this.pnlSidebar.Controls.Add(this.btnNavRankings);
            this.pnlSidebar.Controls.Add(this.btnNavMatches);
            this.pnlSidebar.Controls.Add(this.btnNavHistory);
            this.pnlSidebar.Controls.Add(this.btnNavPredictions);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Location = new System.Drawing.Point(0, 80);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Size = new System.Drawing.Size(200, 531);
            this.pnlSidebar.TabIndex = 0;
            // 
            // btnNavLeagues
            // 
            this.btnNavLeagues.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNavLeagues.Location = new System.Drawing.Point(0, 180);
            this.btnNavLeagues.Name = "btnNavLeagues";
            this.btnNavLeagues.Size = new System.Drawing.Size(200, 45);
            this.btnNavLeagues.TabIndex = 4;
            this.btnNavLeagues.Text = "Mis Quinielas 🏆";
            this.btnNavLeagues.UseVisualStyleBackColor = true;
            this.btnNavLeagues.Click += new System.EventHandler(this.btnNavLeagues_Click);
            // 
            // btnNavRankings
            // 
            this.btnNavRankings.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNavRankings.Location = new System.Drawing.Point(0, 135);
            this.btnNavRankings.Name = "btnNavRankings";
            this.btnNavRankings.Size = new System.Drawing.Size(200, 45);
            this.btnNavRankings.TabIndex = 3;
            this.btnNavRankings.Text = "Ranking Global 🏅";
            this.btnNavRankings.UseVisualStyleBackColor = true;
            this.btnNavRankings.Click += new System.EventHandler(this.btnNavRankings_Click);
            // 
            // btnNavMatches
            // 
            this.btnNavMatches.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNavMatches.Location = new System.Drawing.Point(0, 90);
            this.btnNavMatches.Name = "btnNavMatches";
            this.btnNavMatches.Size = new System.Drawing.Size(200, 45);
            this.btnNavMatches.TabIndex = 2;
            this.btnNavMatches.Text = "Partidos y Tablas 📅";
            this.btnNavMatches.UseVisualStyleBackColor = true;
            this.btnNavMatches.Click += new System.EventHandler(this.btnNavMatches_Click);
            // 
            // btnNavHistory
            // 
            this.btnNavHistory.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNavHistory.Location = new System.Drawing.Point(0, 45);
            this.btnNavHistory.Name = "btnNavHistory";
            this.btnNavHistory.Size = new System.Drawing.Size(200, 45);
            this.btnNavHistory.TabIndex = 1;
            this.btnNavHistory.Text = "Mi Historial 📖";
            this.btnNavHistory.UseVisualStyleBackColor = true;
            this.btnNavHistory.Click += new System.EventHandler(this.btnNavHistory_Click);
            // 
            // btnNavPredictions
            // 
            this.btnNavPredictions.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNavPredictions.Location = new System.Drawing.Point(0, 0);
            this.btnNavPredictions.Name = "btnNavPredictions";
            this.btnNavPredictions.Size = new System.Drawing.Size(200, 45);
            this.btnNavPredictions.TabIndex = 0;
            this.btnNavPredictions.Text = "Pronosticar ⚽";
            this.btnNavPredictions.UseVisualStyleBackColor = true;
            this.btnNavPredictions.Click += new System.EventHandler(this.btnNavPredictions_Click);
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.btnStats);
            this.pnlHeader.Controls.Add(this.btnAdmin);
            this.pnlHeader.Controls.Add(this.btnLogout);
            this.pnlHeader.Controls.Add(this.lblDate);
            this.pnlHeader.Controls.Add(this.lblUserProfile);
            this.pnlHeader.Controls.Add(this.lblAppTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(984, 80);
            this.pnlHeader.TabIndex = 1;
            // 
            // btnStats
            // 
            this.btnStats.Location = new System.Drawing.Point(670, 35);
            this.btnStats.Name = "btnStats";
            this.btnStats.Size = new System.Drawing.Size(100, 40);
            this.btnStats.TabIndex = 5;
            this.btnStats.Text = "Estadísticas 📊";
            this.btnStats.UseVisualStyleBackColor = true;
            this.btnStats.Click += new System.EventHandler(this.btnStats_Click);
            // 
            // btnAdmin
            // 
            this.btnAdmin.Location = new System.Drawing.Point(776, 26);
            this.btnAdmin.Name = "btnAdmin";
            this.btnAdmin.Size = new System.Drawing.Size(100, 40);
            this.btnAdmin.TabIndex = 4;
            this.btnAdmin.Text = "Administrar 🛠️";
            this.btnAdmin.UseVisualStyleBackColor = true;
            this.btnAdmin.Click += new System.EventHandler(this.btnAdmin_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(882, 26);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(90, 40);
            this.btnLogout.TabIndex = 3;
            this.btnLogout.Text = "Salir 🚪";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(235, 45);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(120, 13);
            this.lblDate.TabIndex = 2;
            this.lblDate.Text = "Fecha del Sistema: N/A";
            // 
            // lblUserProfile
            // 
            this.lblUserProfile.AutoSize = true;
            this.lblUserProfile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserProfile.Location = new System.Drawing.Point(235, 20);
            this.lblUserProfile.Name = "lblUserProfile";
            this.lblUserProfile.Size = new System.Drawing.Size(114, 15);
            this.lblUserProfile.TabIndex = 1;
            this.lblUserProfile.Text = "Usuario: N/A | Pts: 0";
            // 
            // lblAppTitle
            // 
            this.lblAppTitle.AutoSize = true;
            this.lblAppTitle.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppTitle.Location = new System.Drawing.Point(20, 15);
            this.lblAppTitle.Name = "lblAppTitle";
            this.lblAppTitle.Size = new System.Drawing.Size(220, 45);
            this.lblAppTitle.TabIndex = 0;
            this.lblAppTitle.Text = "Quiniegol ⚽";
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.pnlPredictions);
            this.pnlContent.Controls.Add(this.pnlHistory);
            this.pnlContent.Controls.Add(this.pnlMatches);
            this.pnlContent.Controls.Add(this.pnlRankings);
            this.pnlContent.Controls.Add(this.pnlLeagues);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(200, 80);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(784, 531);
            this.pnlContent.TabIndex = 2;
            // 
            // pnlPredictions
            // 
            this.pnlPredictions.Controls.Add(this.btnSavePrediction);
            this.pnlPredictions.Controls.Add(this.lblPredictionVs);
            this.pnlPredictions.Controls.Add(this.numAwayPred);
            this.pnlPredictions.Controls.Add(this.numHomePred);
            this.pnlPredictions.Controls.Add(this.lblAwayPredTeam);
            this.pnlPredictions.Controls.Add(this.lblHomePredTeam);
            this.pnlPredictions.Controls.Add(this.dgvPredictionsMatches);
            this.pnlPredictions.Controls.Add(this.lblPredictionsTitle);
            this.pnlPredictions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPredictions.Location = new System.Drawing.Point(0, 0);
            this.pnlPredictions.Name = "pnlPredictions";
            this.pnlPredictions.Size = new System.Drawing.Size(784, 531);
            this.pnlPredictions.TabIndex = 0;
            // 
            // btnSavePrediction
            // 
            this.btnSavePrediction.Location = new System.Drawing.Point(514, 448);
            this.btnSavePrediction.Name = "btnSavePrediction";
            this.btnSavePrediction.Size = new System.Drawing.Size(150, 40);
            this.btnSavePrediction.TabIndex = 7;
            this.btnSavePrediction.Text = "Guardar Pronóstico";
            this.btnSavePrediction.UseVisualStyleBackColor = true;
            this.btnSavePrediction.Click += new System.EventHandler(this.btnSavePrediction_Click);
            // 
            // lblPredictionVs
            // 
            this.lblPredictionVs.AutoSize = true;
            this.lblPredictionVs.Location = new System.Drawing.Point(290, 462);
            this.lblPredictionVs.Name = "lblPredictionVs";
            this.lblPredictionVs.Size = new System.Drawing.Size(18, 13);
            this.lblPredictionVs.TabIndex = 6;
            this.lblPredictionVs.Text = "vs";
            // 
            // numAwayPred
            // 
            this.numAwayPred.Location = new System.Drawing.Point(325, 460);
            this.numAwayPred.Name = "numAwayPred";
            this.numAwayPred.Size = new System.Drawing.Size(50, 20);
            this.numAwayPred.TabIndex = 5;
            // 
            // numHomePred
            // 
            this.numHomePred.Location = new System.Drawing.Point(220, 460);
            this.numHomePred.Name = "numHomePred";
            this.numHomePred.Size = new System.Drawing.Size(50, 20);
            this.numHomePred.TabIndex = 4;
            // 
            // lblAwayPredTeam
            // 
            this.lblAwayPredTeam.AutoSize = true;
            this.lblAwayPredTeam.Location = new System.Drawing.Point(395, 462);
            this.lblAwayPredTeam.Name = "lblAwayPredTeam";
            this.lblAwayPredTeam.Size = new System.Drawing.Size(63, 13);
            this.lblAwayPredTeam.TabIndex = 3;
            this.lblAwayPredTeam.Text = "Equipo Visita";
            // 
            // lblHomePredTeam
            // 
            this.lblHomePredTeam.AutoSize = true;
            this.lblHomePredTeam.Location = new System.Drawing.Point(120, 462);
            this.lblHomePredTeam.Name = "lblHomePredTeam";
            this.lblHomePredTeam.Size = new System.Drawing.Size(65, 13);
            this.lblHomePredTeam.TabIndex = 2;
            this.lblHomePredTeam.Text = "Equipo Local";
            // 
            // dgvPredictionsMatches
            // 
            this.dgvPredictionsMatches.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPredictionsMatches.Location = new System.Drawing.Point(25, 60);
            this.dgvPredictionsMatches.Name = "dgvPredictionsMatches";
            this.dgvPredictionsMatches.Size = new System.Drawing.Size(730, 360);
            this.dgvPredictionsMatches.TabIndex = 1;
            this.dgvPredictionsMatches.SelectionChanged += new System.EventHandler(this.dgvPredictionsMatches_SelectionChanged);
            // 
            // lblPredictionsTitle
            // 
            this.lblPredictionsTitle.AutoSize = true;
            this.lblPredictionsTitle.Location = new System.Drawing.Point(25, 20);
            this.lblPredictionsTitle.Name = "lblPredictionsTitle";
            this.lblPredictionsTitle.Size = new System.Drawing.Size(146, 13);
            this.lblPredictionsTitle.TabIndex = 0;
            this.lblPredictionsTitle.Text = "Pronosticar Partidos Próximos";
            // 
            // pnlHistory
            // 
            this.pnlHistory.Controls.Add(this.dgvHistory);
            this.pnlHistory.Controls.Add(this.lblHistoryTitle);
            this.pnlHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlHistory.Location = new System.Drawing.Point(0, 0);
            this.pnlHistory.Name = "pnlHistory";
            this.pnlHistory.Size = new System.Drawing.Size(784, 531);
            this.pnlHistory.TabIndex = 1;
            // 
            // dgvHistory
            // 
            this.dgvHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistory.Location = new System.Drawing.Point(25, 60);
            this.dgvHistory.Name = "dgvHistory";
            this.dgvHistory.Size = new System.Drawing.Size(730, 440);
            this.dgvHistory.TabIndex = 2;
            // 
            // lblHistoryTitle
            // 
            this.lblHistoryTitle.AutoSize = true;
            this.lblHistoryTitle.Location = new System.Drawing.Point(25, 20);
            this.lblHistoryTitle.Name = "lblHistoryTitle";
            this.lblHistoryTitle.Size = new System.Drawing.Size(131, 13);
            this.lblHistoryTitle.TabIndex = 1;
            this.lblHistoryTitle.Text = "Mi Historial de Pronósticos";
            // 
            // pnlMatches
            // 
            this.pnlMatches.Controls.Add(this.tabMatchesSub);
            this.pnlMatches.Controls.Add(this.lblMatchesTitle);
            this.pnlMatches.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMatches.Location = new System.Drawing.Point(0, 0);
            this.pnlMatches.Name = "pnlMatches";
            this.pnlMatches.Size = new System.Drawing.Size(784, 531);
            this.pnlMatches.TabIndex = 2;
            // 
            // tabMatchesSub
            // 
            this.tabMatchesSub.Controls.Add(this.tabLast5);
            this.tabMatchesSub.Controls.Add(this.tabNext24);
            this.tabMatchesSub.Controls.Add(this.tabGroups);
            this.tabMatchesSub.Controls.Add(this.tabBrackets);
            this.tabMatchesSub.Location = new System.Drawing.Point(25, 60);
            this.tabMatchesSub.Name = "tabMatchesSub";
            this.tabMatchesSub.SelectedIndex = 0;
            this.tabMatchesSub.Size = new System.Drawing.Size(730, 440);
            this.tabMatchesSub.TabIndex = 3;
            this.tabMatchesSub.SelectedIndexChanged += new System.EventHandler(this.tabMatchesSub_SelectedIndexChanged);
            // 
            // tabLast5
            // 
            this.tabLast5.Controls.Add(this.dgvLast5);
            this.tabLast5.Location = new System.Drawing.Point(4, 22);
            this.tabLast5.Name = "tabLast5";
            this.tabLast5.Padding = new System.Windows.Forms.Padding(3);
            this.tabLast5.Size = new System.Drawing.Size(722, 414);
            this.tabLast5.TabIndex = 0;
            this.tabLast5.Text = "Últimos 5 Partidos";
            this.tabLast5.UseVisualStyleBackColor = true;
            // 
            // dgvLast5
            // 
            this.dgvLast5.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLast5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLast5.Location = new System.Drawing.Point(3, 3);
            this.dgvLast5.Name = "dgvLast5";
            this.dgvLast5.Size = new System.Drawing.Size(716, 408);
            this.dgvLast5.TabIndex = 0;
            // 
            // tabNext24
            // 
            this.tabNext24.Controls.Add(this.dgvNext24);
            this.tabNext24.Location = new System.Drawing.Point(4, 22);
            this.tabNext24.Name = "tabNext24";
            this.tabNext24.Padding = new System.Windows.Forms.Padding(3);
            this.tabNext24.Size = new System.Drawing.Size(722, 414);
            this.tabNext24.TabIndex = 1;
            this.tabNext24.Text = "Próximos (24h)";
            this.tabNext24.UseVisualStyleBackColor = true;
            // 
            // dgvNext24
            // 
            this.dgvNext24.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNext24.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvNext24.Location = new System.Drawing.Point(3, 3);
            this.dgvNext24.Name = "dgvNext24";
            this.dgvNext24.Size = new System.Drawing.Size(716, 408);
            this.dgvNext24.TabIndex = 0;
            // 
            // tabGroups
            // 
            this.tabGroups.Controls.Add(this.cmbGroupSelect);
            this.tabGroups.Controls.Add(this.dgvGroupStandings);
            this.tabGroups.Location = new System.Drawing.Point(4, 22);
            this.tabGroups.Name = "tabGroups";
            this.tabGroups.Size = new System.Drawing.Size(722, 414);
            this.tabGroups.TabIndex = 2;
            this.tabGroups.Text = "Tablas de Grupos";
            this.tabGroups.UseVisualStyleBackColor = true;
            // 
            // cmbGroupSelect
            // 
            this.cmbGroupSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGroupSelect.FormattingEnabled = true;
            this.cmbGroupSelect.Items.AddRange(new object[] {
            "Grupo A",
            "Grupo B",
            "Grupo C",
            "Grupo D"});
            this.cmbGroupSelect.Location = new System.Drawing.Point(20, 15);
            this.cmbGroupSelect.Name = "cmbGroupSelect";
            this.cmbGroupSelect.Size = new System.Drawing.Size(150, 21);
            this.cmbGroupSelect.TabIndex = 1;
            this.cmbGroupSelect.SelectedIndexChanged += new System.EventHandler(this.cmbGroupSelect_SelectedIndexChanged);
            // 
            // dgvGroupStandings
            // 
            this.dgvGroupStandings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGroupStandings.Location = new System.Drawing.Point(20, 50);
            this.dgvGroupStandings.Name = "dgvGroupStandings";
            this.dgvGroupStandings.Size = new System.Drawing.Size(680, 345);
            this.dgvGroupStandings.TabIndex = 0;
            // 
            // tabBrackets
            // 
            this.tabBrackets.Controls.Add(this.dgvBrackets);
            this.tabBrackets.Location = new System.Drawing.Point(4, 22);
            this.tabBrackets.Name = "tabBrackets";
            this.tabBrackets.Size = new System.Drawing.Size(722, 414);
            this.tabBrackets.TabIndex = 3;
            this.tabBrackets.Text = "Cruces Fases Finales";
            this.tabBrackets.UseVisualStyleBackColor = true;
            // 
            // dgvBrackets
            // 
            this.dgvBrackets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBrackets.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBrackets.Location = new System.Drawing.Point(0, 0);
            this.dgvBrackets.Name = "dgvBrackets";
            this.dgvBrackets.Size = new System.Drawing.Size(722, 414);
            this.dgvBrackets.TabIndex = 0;
            // 
            // lblMatchesTitle
            // 
            this.lblMatchesTitle.AutoSize = true;
            this.lblMatchesTitle.Location = new System.Drawing.Point(25, 20);
            this.lblMatchesTitle.Name = "lblMatchesTitle";
            this.lblMatchesTitle.Size = new System.Drawing.Size(97, 13);
            this.lblMatchesTitle.TabIndex = 2;
            this.lblMatchesTitle.Text = "Detalles de Torneo";
            // 
            // pnlRankings
            // 
            this.pnlRankings.Controls.Add(this.dgvRankings);
            this.pnlRankings.Controls.Add(this.lblRankingsTitle);
            this.pnlRankings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRankings.Location = new System.Drawing.Point(0, 0);
            this.pnlRankings.Name = "pnlRankings";
            this.pnlRankings.Size = new System.Drawing.Size(784, 531);
            this.pnlRankings.TabIndex = 3;
            // 
            // dgvRankings
            // 
            this.dgvRankings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRankings.Location = new System.Drawing.Point(25, 60);
            this.dgvRankings.Name = "dgvRankings";
            this.dgvRankings.Size = new System.Drawing.Size(730, 440);
            this.dgvRankings.TabIndex = 2;
            // 
            // lblRankingsTitle
            // 
            this.lblRankingsTitle.AutoSize = true;
            this.lblRankingsTitle.Location = new System.Drawing.Point(25, 20);
            this.lblRankingsTitle.Name = "lblRankingsTitle";
            this.lblRankingsTitle.Size = new System.Drawing.Size(111, 13);
            this.lblRankingsTitle.TabIndex = 1;
            this.lblRankingsTitle.Text = "Tabla de Clasificación";
            // 
            // pnlLeagues
            // 
            this.pnlLeagues.Controls.Add(this.btnJoinLeague);
            this.pnlLeagues.Controls.Add(this.btnCreateLeague);
            this.pnlLeagues.Controls.Add(this.txtJoinLeagueId);
            this.pnlLeagues.Controls.Add(this.lblTimeline);
            this.pnlLeagues.Controls.Add(this.lblLeagueRanking);
            this.pnlLeagues.Controls.Add(this.lstTimeline);
            this.pnlLeagues.Controls.Add(this.dgvLeagueRanking);
            this.pnlLeagues.Controls.Add(this.lstLeagues);
            this.pnlLeagues.Controls.Add(this.lblLeaguesListTitle);
            this.pnlLeagues.Controls.Add(this.lblLeaguesTitle);
            this.pnlLeagues.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLeagues.Location = new System.Drawing.Point(0, 0);
            this.pnlLeagues.Name = "pnlLeagues";
            this.pnlLeagues.Size = new System.Drawing.Size(784, 531);
            this.pnlLeagues.TabIndex = 4;
            // 
            // btnJoinLeague
            // 
            this.btnJoinLeague.Location = new System.Drawing.Point(620, 15);
            this.btnJoinLeague.Name = "btnJoinLeague";
            this.btnJoinLeague.Size = new System.Drawing.Size(130, 30);
            this.btnJoinLeague.TabIndex = 9;
            this.btnJoinLeague.Text = "Unirse a Quiniela";
            this.btnJoinLeague.UseVisualStyleBackColor = true;
            this.btnJoinLeague.Click += new System.EventHandler(this.btnJoinLeague_Click);
            // 
            // btnCreateLeague
            // 
            this.btnCreateLeague.Location = new System.Drawing.Point(220, 15);
            this.btnCreateLeague.Name = "btnCreateLeague";
            this.btnCreateLeague.Size = new System.Drawing.Size(130, 30);
            this.btnCreateLeague.TabIndex = 8;
            this.btnCreateLeague.Text = "Crear Quiniela";
            this.btnCreateLeague.UseVisualStyleBackColor = true;
            this.btnCreateLeague.Click += new System.EventHandler(this.btnCreateLeague_Click);
            // 
            // txtJoinLeagueId
            // 
            this.txtJoinLeagueId.Location = new System.Drawing.Point(460, 20);
            this.txtJoinLeagueId.Name = "txtJoinLeagueId";
            this.txtJoinLeagueId.Size = new System.Drawing.Size(150, 20);
            this.txtJoinLeagueId.TabIndex = 7;
            // 
            // lblTimeline
            // 
            this.lblTimeline.AutoSize = true;
            this.lblTimeline.Location = new System.Drawing.Point(220, 320);
            this.lblTimeline.Name = "lblTimeline";
            this.lblTimeline.Size = new System.Drawing.Size(116, 13);
            this.lblTimeline.TabIndex = 6;
            this.lblTimeline.Text = "Muro de Notificaciones";
            // 
            // lblLeagueRanking
            // 
            this.lblLeagueRanking.AutoSize = true;
            this.lblLeagueRanking.Location = new System.Drawing.Point(220, 60);
            this.lblLeagueRanking.Name = "lblLeagueRanking";
            this.lblLeagueRanking.Size = new System.Drawing.Size(101, 13);
            this.lblLeagueRanking.TabIndex = 5;
            this.lblLeagueRanking.Text = "Tabla de la Quiniela";
            // 
            // lstTimeline
            // 
            this.lstTimeline.FormattingEnabled = true;
            this.lstTimeline.Location = new System.Drawing.Point(220, 340);
            this.lstTimeline.Name = "lstTimeline";
            this.lstTimeline.Size = new System.Drawing.Size(530, 160);
            this.lstTimeline.TabIndex = 4;
            // 
            // dgvLeagueRanking
            // 
            this.dgvLeagueRanking.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLeagueRanking.Location = new System.Drawing.Point(220, 80);
            this.dgvLeagueRanking.Name = "dgvLeagueRanking";
            this.dgvLeagueRanking.Size = new System.Drawing.Size(530, 220);
            this.dgvLeagueRanking.TabIndex = 3;
            // 
            // lstLeagues
            // 
            this.lstLeagues.FormattingEnabled = true;
            this.lstLeagues.Location = new System.Drawing.Point(25, 80);
            this.lstLeagues.Name = "lstLeagues";
            this.lstLeagues.Size = new System.Drawing.Size(170, 420);
            this.lstLeagues.TabIndex = 2;
            this.lstLeagues.SelectedIndexChanged += new System.EventHandler(this.lstLeagues_SelectedIndexChanged);
            // 
            // lblLeaguesListTitle
            // 
            this.lblLeaguesListTitle.AutoSize = true;
            this.lblLeaguesListTitle.Location = new System.Drawing.Point(25, 60);
            this.lblLeaguesListTitle.Name = "lblLeaguesListTitle";
            this.lblLeaguesListTitle.Size = new System.Drawing.Size(69, 13);
            this.lblLeaguesListTitle.TabIndex = 1;
            this.lblLeaguesListTitle.Text = "Mis Quinielas";
            // 
            // lblLeaguesTitle
            // 
            this.lblLeaguesTitle.AutoSize = true;
            this.lblLeaguesTitle.Location = new System.Drawing.Point(25, 20);
            this.lblLeaguesTitle.Name = "lblLeaguesTitle";
            this.lblLeaguesTitle.Size = new System.Drawing.Size(85, 13);
            this.lblLeaguesTitle.TabIndex = 0;
            this.lblLeaguesTitle.Text = "Manejo de Ligas";
            // 
            // MainDashboardFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 611);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlSidebar);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainDashboardFrm";
            this.Text = "Quiniegol - Dashboard";
            this.Load += new System.EventHandler(this.MainDashboardFrm_Load);
            this.pnlSidebar.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlContent.ResumeLayout(false);
            this.pnlPredictions.ResumeLayout(false);
            this.pnlPredictions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAwayPred)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHomePred)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPredictionsMatches)).EndInit();
            this.pnlHistory.ResumeLayout(false);
            this.pnlHistory.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).EndInit();
            this.pnlMatches.ResumeLayout(false);
            this.pnlMatches.PerformLayout();
            this.tabMatchesSub.ResumeLayout(false);
            this.tabLast5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLast5)).EndInit();
            this.tabNext24.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNext24)).EndInit();
            this.tabGroups.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGroupStandings)).EndInit();
            this.tabBrackets.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBrackets)).EndInit();
            this.pnlRankings.ResumeLayout(false);
            this.pnlRankings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRankings)).EndInit();
            this.pnlLeagues.ResumeLayout(false);
            this.pnlLeagues.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLeagueRanking)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.Button btnNavLeagues;
        private System.Windows.Forms.Button btnNavRankings;
        private System.Windows.Forms.Button btnNavMatches;
        private System.Windows.Forms.Button btnNavHistory;
        private System.Windows.Forms.Button btnNavPredictions;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblUserProfile;
        private System.Windows.Forms.Label lblAppTitle;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Panel pnlPredictions;
        private System.Windows.Forms.Panel pnlHistory;
        private System.Windows.Forms.Panel pnlMatches;
        private System.Windows.Forms.Panel pnlRankings;
        private System.Windows.Forms.Panel pnlLeagues;
        private System.Windows.Forms.DataGridView dgvPredictionsMatches;
        private System.Windows.Forms.Label lblPredictionsTitle;
        private System.Windows.Forms.Button btnSavePrediction;
        private System.Windows.Forms.Label lblPredictionVs;
        private System.Windows.Forms.NumericUpDown numAwayPred;
        private System.Windows.Forms.NumericUpDown numHomePred;
        private System.Windows.Forms.Label lblAwayPredTeam;
        private System.Windows.Forms.Label lblHomePredTeam;
        private System.Windows.Forms.DataGridView dgvHistory;
        private System.Windows.Forms.Label lblHistoryTitle;
        private System.Windows.Forms.TabControl tabMatchesSub;
        private System.Windows.Forms.TabPage tabLast5;
        private System.Windows.Forms.DataGridView dgvLast5;
        private System.Windows.Forms.TabPage tabNext24;
        private System.Windows.Forms.DataGridView dgvNext24;
        private System.Windows.Forms.TabPage tabGroups;
        private System.Windows.Forms.TabPage tabBrackets;
        private System.Windows.Forms.Label lblMatchesTitle;
        private System.Windows.Forms.DataGridView dgvGroupStandings;
        private System.Windows.Forms.ComboBox cmbGroupSelect;
        private System.Windows.Forms.DataGridView dgvBrackets;
        private System.Windows.Forms.DataGridView dgvRankings;
        private System.Windows.Forms.Label lblRankingsTitle;
        private System.Windows.Forms.ListBox lstLeagues;
        private System.Windows.Forms.Label lblLeaguesListTitle;
        private System.Windows.Forms.Label lblLeaguesTitle;
        private System.Windows.Forms.Button btnJoinLeague;
        private System.Windows.Forms.Button btnCreateLeague;
        private System.Windows.Forms.TextBox txtJoinLeagueId;
        private System.Windows.Forms.Label lblTimeline;
        private System.Windows.Forms.Label lblLeagueRanking;
        private System.Windows.Forms.ListBox lstTimeline;
        private System.Windows.Forms.DataGridView dgvLeagueRanking;
        private System.Windows.Forms.Button btnAdmin;
        private System.Windows.Forms.Button btnStats;
    }
}
