namespace Quiniegol.Views
{
    partial class AdminFrm
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
            this.lblDateTitle = new System.Windows.Forms.Label();
            this.dtpSimulatedDate = new System.Windows.Forms.DateTimePicker();
            this.btnUpdateDate = new System.Windows.Forms.Button();
            this.dgvMatches = new System.Windows.Forms.DataGridView();
            this.lblMatchesListTitle = new System.Windows.Forms.Label();
            this.panelMatchEdit = new System.Windows.Forms.Panel();
            this.btnSaveMatch = new System.Windows.Forms.Button();
            this.chkFinished = new System.Windows.Forms.CheckBox();
            this.txtScorers = new System.Windows.Forms.TextBox();
            this.lblScorers = new System.Windows.Forms.Label();
            this.lblVs = new System.Windows.Forms.Label();
            this.numAwayScore = new System.Windows.Forms.NumericUpDown();
            this.numHomeScore = new System.Windows.Forms.NumericUpDown();
            this.lblAwayTeamName = new System.Windows.Forms.Label();
            this.lblHomeTeamName = new System.Windows.Forms.Label();
            this.lblEditTitle = new System.Windows.Forms.Label();
            this.lblAdminTitle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMatches)).BeginInit();
            this.panelMatchEdit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAwayScore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHomeScore)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDateTitle
            // 
            this.lblDateTitle.AutoSize = true;
            this.lblDateTitle.Location = new System.Drawing.Point(30, 60);
            this.lblDateTitle.Name = "lblDateTitle";
            this.lblDateTitle.Size = new System.Drawing.Size(124, 13);
            this.lblDateTitle.TabIndex = 0;
            this.lblDateTitle.Text = "Fecha Simulada Sistema";
            // 
            // dtpSimulatedDate
            // 
            this.dtpSimulatedDate.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dtpSimulatedDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpSimulatedDate.Location = new System.Drawing.Point(33, 80);
            this.dtpSimulatedDate.Name = "dtpSimulatedDate";
            this.dtpSimulatedDate.Size = new System.Drawing.Size(200, 20);
            this.dtpSimulatedDate.TabIndex = 1;
            // 
            // btnUpdateDate
            // 
            this.btnUpdateDate.Location = new System.Drawing.Point(250, 75);
            this.btnUpdateDate.Name = "btnUpdateDate";
            this.btnUpdateDate.Size = new System.Drawing.Size(120, 30);
            this.btnUpdateDate.TabIndex = 2;
            this.btnUpdateDate.Text = "Aplicar Fecha";
            this.btnUpdateDate.UseVisualStyleBackColor = true;
            this.btnUpdateDate.Click += new System.EventHandler(this.btnUpdateDate_Click);
            // 
            // dgvMatches
            // 
            this.dgvMatches.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMatches.Location = new System.Drawing.Point(33, 150);
            this.dgvMatches.Name = "dgvMatches";
            this.dgvMatches.Size = new System.Drawing.Size(420, 380);
            this.dgvMatches.TabIndex = 3;
            this.dgvMatches.SelectionChanged += new System.EventHandler(this.dgvMatches_SelectionChanged);
            // 
            // lblMatchesListTitle
            // 
            this.lblMatchesListTitle.AutoSize = true;
            this.lblMatchesListTitle.Location = new System.Drawing.Point(30, 130);
            this.lblMatchesListTitle.Name = "lblMatchesListTitle";
            this.lblMatchesListTitle.Size = new System.Drawing.Size(90, 13);
            this.lblMatchesListTitle.TabIndex = 4;
            this.lblMatchesListTitle.Text = "Lista de Partidos";
            // 
            // panelMatchEdit
            // 
            this.panelMatchEdit.Controls.Add(this.btnSaveMatch);
            this.panelMatchEdit.Controls.Add(this.chkFinished);
            this.panelMatchEdit.Controls.Add(this.txtScorers);
            this.panelMatchEdit.Controls.Add(this.lblScorers);
            this.panelMatchEdit.Controls.Add(this.lblVs);
            this.panelMatchEdit.Controls.Add(this.numAwayScore);
            this.panelMatchEdit.Controls.Add(this.numHomeScore);
            this.panelMatchEdit.Controls.Add(this.lblAwayTeamName);
            this.panelMatchEdit.Controls.Add(this.lblHomeTeamName);
            this.panelMatchEdit.Controls.Add(this.lblEditTitle);
            this.panelMatchEdit.Location = new System.Drawing.Point(480, 150);
            this.panelMatchEdit.Name = "panelMatchEdit";
            this.panelMatchEdit.Size = new System.Drawing.Size(280, 380);
            this.panelMatchEdit.TabIndex = 5;
            // 
            // btnSaveMatch
            // 
            this.btnSaveMatch.Location = new System.Drawing.Point(25, 310);
            this.btnSaveMatch.Name = "btnSaveMatch";
            this.btnSaveMatch.Size = new System.Drawing.Size(230, 40);
            this.btnSaveMatch.TabIndex = 9;
            this.btnSaveMatch.Text = "Guardar Resultado";
            this.btnSaveMatch.UseVisualStyleBackColor = true;
            this.btnSaveMatch.Click += new System.EventHandler(this.btnSaveMatch_Click);
            // 
            // chkFinished
            // 
            this.chkFinished.AutoSize = true;
            this.chkFinished.Location = new System.Drawing.Point(25, 260);
            this.chkFinished.Name = "chkFinished";
            this.chkFinished.Size = new System.Drawing.Size(123, 17);
            this.chkFinished.TabIndex = 8;
            this.chkFinished.Text = "Partido Finalizado?";
            this.chkFinished.UseVisualStyleBackColor = true;
            // 
            // txtScorers
            // 
            this.txtScorers.Location = new System.Drawing.Point(25, 200);
            this.txtScorers.Name = "txtScorers";
            this.txtScorers.Size = new System.Drawing.Size(230, 20);
            this.txtScorers.TabIndex = 7;
            // 
            // lblScorers
            // 
            this.lblScorers.AutoSize = true;
            this.lblScorers.Location = new System.Drawing.Point(22, 180);
            this.lblScorers.Name = "lblScorers";
            this.lblScorers.Size = new System.Drawing.Size(161, 13);
            this.lblScorers.TabIndex = 6;
            this.lblScorers.Text = "Anotadores (Separados por \";\"):";
            // 
            // lblVs
            // 
            this.lblVs.AutoSize = true;
            this.lblVs.Location = new System.Drawing.Point(125, 112);
            this.lblVs.Name = "lblVs";
            this.lblVs.Size = new System.Drawing.Size(18, 13);
            this.lblVs.TabIndex = 5;
            this.lblVs.Text = "vs";
            // 
            // numAwayScore
            // 
            this.numAwayScore.Location = new System.Drawing.Point(155, 110);
            this.numAwayScore.Name = "numAwayScore";
            this.numAwayScore.Size = new System.Drawing.Size(50, 20);
            this.numAwayScore.TabIndex = 4;
            // 
            // numHomeScore
            // 
            this.numHomeScore.Location = new System.Drawing.Point(65, 110);
            this.numHomeScore.Name = "numHomeScore";
            this.numHomeScore.Size = new System.Drawing.Size(50, 20);
            this.numHomeScore.TabIndex = 3;
            // 
            // lblAwayTeamName
            // 
            this.lblAwayTeamName.AutoSize = true;
            this.lblAwayTeamName.Location = new System.Drawing.Point(155, 80);
            this.lblAwayTeamName.Name = "lblAwayTeamName";
            this.lblAwayTeamName.Size = new System.Drawing.Size(68, 13);
            this.lblAwayTeamName.TabIndex = 2;
            this.lblAwayTeamName.Text = "Away Team";
            // 
            // lblHomeTeamName
            // 
            this.lblHomeTeamName.AutoSize = true;
            this.lblHomeTeamName.Location = new System.Drawing.Point(65, 80);
            this.lblHomeTeamName.Name = "lblHomeTeamName";
            this.lblHomeTeamName.Size = new System.Drawing.Size(71, 13);
            this.lblHomeTeamName.TabIndex = 1;
            this.lblHomeTeamName.Text = "Home Team";
            // 
            // lblEditTitle
            // 
            this.lblEditTitle.AutoSize = true;
            this.lblEditTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblEditTitle.Location = new System.Drawing.Point(20, 20);
            this.lblEditTitle.Name = "lblEditTitle";
            this.lblEditTitle.Size = new System.Drawing.Size(161, 21);
            this.lblEditTitle.TabIndex = 0;
            this.lblEditTitle.Text = "Registrar Marcador";
            // 
            // lblAdminTitle
            // 
            this.lblAdminTitle.AutoSize = true;
            this.lblAdminTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblAdminTitle.Location = new System.Drawing.Point(28, 15);
            this.lblAdminTitle.Name = "lblAdminTitle";
            this.lblAdminTitle.Size = new System.Drawing.Size(262, 30);
            this.lblAdminTitle.TabIndex = 6;
            this.lblAdminTitle.Text = "Panel de Administración";
            // 
            // AdminFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 561);
            this.Controls.Add(this.lblAdminTitle);
            this.Controls.Add(this.panelMatchEdit);
            this.Controls.Add(this.lblMatchesListTitle);
            this.Controls.Add(this.dgvMatches);
            this.Controls.Add(this.btnUpdateDate);
            this.Controls.Add(this.dtpSimulatedDate);
            this.Controls.Add(this.lblDateTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "AdminFrm";
            this.Text = "Quiniegol - Panel de Control Administrativo";
            this.Load += new System.EventHandler(this.AdminFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMatches)).EndInit();
            this.panelMatchEdit.ResumeLayout(false);
            this.panelMatchEdit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAwayScore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHomeScore)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDateTitle;
        private System.Windows.Forms.DateTimePicker dtpSimulatedDate;
        private System.Windows.Forms.Button btnUpdateDate;
        private System.Windows.Forms.DataGridView dgvMatches;
        private System.Windows.Forms.Label lblMatchesListTitle;
        private System.Windows.Forms.Panel panelMatchEdit;
        private System.Windows.Forms.Button btnSaveMatch;
        private System.Windows.Forms.CheckBox chkFinished;
        private System.Windows.Forms.TextBox txtScorers;
        private System.Windows.Forms.Label lblScorers;
        private System.Windows.Forms.Label lblVs;
        private System.Windows.Forms.NumericUpDown numAwayScore;
        private System.Windows.Forms.NumericUpDown numHomeScore;
        private System.Windows.Forms.Label lblAwayTeamName;
        private System.Windows.Forms.Label lblHomeTeamName;
        private System.Windows.Forms.Label lblEditTitle;
        private System.Windows.Forms.Label lblAdminTitle;
    }
}
