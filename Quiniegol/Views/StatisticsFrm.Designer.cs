namespace Quiniegol.Views
{
    partial class StatisticsFrm
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblStart = new System.Windows.Forms.Label();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.lblEnd = new System.Windows.Forms.Label();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.btnCompute = new System.Windows.Forms.Button();
            this.panelStats = new System.Windows.Forms.Panel();
            this.lblAvgGoalsVal = new System.Windows.Forms.Label();
            this.lblAvgGoals = new System.Windows.Forms.Label();
            this.lblSurpriseVal = new System.Windows.Forms.Label();
            this.lblSurprise = new System.Windows.Forms.Label();
            this.lblMostPredVal = new System.Windows.Forms.Label();
            this.lblMostPred = new System.Windows.Forms.Label();
            this.lblMostCorrectUserVal = new System.Windows.Forms.Label();
            this.lblMostCorrectUser = new System.Windows.Forms.Label();
            this.lblMostCorrectMatchVal = new System.Windows.Forms.Label();
            this.lblMostCorrectMatch = new System.Windows.Forms.Label();
            this.lblRepeatedResultVal = new System.Windows.Forms.Label();
            this.lblRepeatedResult = new System.Windows.Forms.Label();
            this.lblMostBetVal = new System.Windows.Forms.Label();
            this.lblMostBet = new System.Windows.Forms.Label();
            this.panelStats.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(25, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(248, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Estadísticas en Vivo 📊";
            // 
            // lblStart
            // 
            this.lblStart.AutoSize = true;
            this.lblStart.Location = new System.Drawing.Point(30, 70);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(69, 13);
            this.lblStart.TabIndex = 1;
            this.lblStart.Text = "Fecha Inicial:";
            // 
            // dtpStart
            // 
            this.dtpStart.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStart.Location = new System.Drawing.Point(33, 90);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(180, 20);
            this.dtpStart.TabIndex = 2;
            // 
            // lblEnd
            // 
            this.lblEnd.AutoSize = true;
            this.lblEnd.Location = new System.Drawing.Point(240, 70);
            this.lblEnd.Name = "lblEnd";
            this.lblEnd.Size = new System.Drawing.Size(64, 13);
            this.lblEnd.TabIndex = 3;
            this.lblEnd.Text = "Fecha Final:";
            // 
            // dtpEnd
            // 
            this.dtpEnd.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEnd.Location = new System.Drawing.Point(243, 90);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(180, 20);
            this.dtpEnd.TabIndex = 4;
            // 
            // btnCompute
            // 
            this.btnCompute.Location = new System.Drawing.Point(450, 83);
            this.btnCompute.Name = "btnCompute";
            this.btnCompute.Size = new System.Drawing.Size(130, 30);
            this.btnCompute.TabIndex = 5;
            this.btnCompute.Text = "Calcular Reporte";
            this.btnCompute.UseVisualStyleBackColor = true;
            this.btnCompute.Click += new System.EventHandler(this.btnCompute_Click);
            // 
            // panelStats
            // 
            this.panelStats.Controls.Add(this.lblAvgGoalsVal);
            this.panelStats.Controls.Add(this.lblAvgGoals);
            this.panelStats.Controls.Add(this.lblSurpriseVal);
            this.panelStats.Controls.Add(this.lblSurprise);
            this.panelStats.Controls.Add(this.lblMostPredVal);
            this.panelStats.Controls.Add(this.lblMostPred);
            this.panelStats.Controls.Add(this.lblMostCorrectUserVal);
            this.panelStats.Controls.Add(this.lblMostCorrectUser);
            this.panelStats.Controls.Add(this.lblMostCorrectMatchVal);
            this.panelStats.Controls.Add(this.lblMostCorrectMatch);
            this.panelStats.Controls.Add(this.lblRepeatedResultVal);
            this.panelStats.Controls.Add(this.lblRepeatedResult);
            this.panelStats.Controls.Add(this.lblMostBetVal);
            this.panelStats.Controls.Add(this.lblMostBet);
            this.panelStats.Location = new System.Drawing.Point(30, 140);
            this.panelStats.Name = "panelStats";
            this.panelStats.Size = new System.Drawing.Size(550, 350);
            this.panelStats.TabIndex = 6;
            // 
            // lblAvgGoalsVal
            // 
            this.lblAvgGoalsVal.AutoSize = true;
            this.lblAvgGoalsVal.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblAvgGoalsVal.Location = new System.Drawing.Point(280, 290);
            this.lblAvgGoalsVal.Name = "lblAvgGoalsVal";
            this.lblAvgGoalsVal.Size = new System.Drawing.Size(35, 19);
            this.lblAvgGoalsVal.TabIndex = 13;
            this.lblAvgGoalsVal.Text = "N/A";
            // 
            // lblAvgGoals
            // 
            this.lblAvgGoals.AutoSize = true;
            this.lblAvgGoals.Location = new System.Drawing.Point(30, 290);
            this.lblAvgGoals.Name = "lblAvgGoals";
            this.lblAvgGoals.Size = new System.Drawing.Size(152, 13);
            this.lblAvgGoals.TabIndex = 12;
            this.lblAvgGoals.Text = "Promedio de Goles por Partido:";
            // 
            // lblSurpriseVal
            // 
            this.lblSurpriseVal.AutoSize = true;
            this.lblSurpriseVal.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblSurpriseVal.Location = new System.Drawing.Point(280, 250);
            this.lblSurpriseVal.Name = "lblSurpriseVal";
            this.lblSurpriseVal.Size = new System.Drawing.Size(35, 19);
            this.lblSurpriseVal.TabIndex = 11;
            this.lblSurpriseVal.Text = "N/A";
            // 
            // lblSurprise
            // 
            this.lblSurprise.AutoSize = true;
            this.lblSurprise.Location = new System.Drawing.Point(30, 250);
            this.lblSurprise.Name = "lblSurprise";
            this.lblSurprise.Size = new System.Drawing.Size(89, 13);
            this.lblSurprise.TabIndex = 10;
            this.lblSurprise.Text = "Equipo Sorpresa:";
            // 
            // lblMostPredVal
            // 
            this.lblMostPredVal.AutoSize = true;
            this.lblMostPredVal.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblMostPredVal.Location = new System.Drawing.Point(280, 210);
            this.lblMostPredVal.Name = "lblMostPredVal";
            this.lblMostPredVal.Size = new System.Drawing.Size(35, 19);
            this.lblMostPredVal.TabIndex = 9;
            this.lblMostPredVal.Text = "N/A";
            // 
            // lblMostPred
            // 
            this.lblMostPred.AutoSize = true;
            this.lblMostPred.Location = new System.Drawing.Point(30, 210);
            this.lblMostPred.Name = "lblMostPred";
            this.lblMostPred.Size = new System.Drawing.Size(140, 13);
            this.lblMostPred.TabIndex = 8;
            this.lblMostPred.Text = "Partido con más Pronósticos:";
            // 
            // lblMostCorrectUserVal
            // 
            this.lblMostCorrectUserVal.AutoSize = true;
            this.lblMostCorrectUserVal.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblMostCorrectUserVal.Location = new System.Drawing.Point(280, 170);
            this.lblMostCorrectUserVal.Name = "lblMostCorrectUserVal";
            this.lblMostCorrectUserVal.Size = new System.Drawing.Size(35, 19);
            this.lblMostCorrectUserVal.TabIndex = 7;
            this.lblMostCorrectUserVal.Text = "N/A";
            // 
            // lblMostCorrectUser
            // 
            this.lblMostCorrectUser.AutoSize = true;
            this.lblMostCorrectUser.Location = new System.Drawing.Point(30, 170);
            this.lblMostCorrectUser.Name = "lblMostCorrectUser";
            this.lblMostCorrectUser.Size = new System.Drawing.Size(117, 13);
            this.lblMostCorrectUser.TabIndex = 6;
            this.lblMostCorrectUser.Text = "Usuario con más Éxitos:";
            // 
            // lblMostCorrectMatchVal
            // 
            this.lblMostCorrectMatchVal.AutoSize = true;
            this.lblMostCorrectMatchVal.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblMostCorrectMatchVal.Location = new System.Drawing.Point(280, 130);
            this.lblMostCorrectMatchVal.Name = "lblMostCorrectMatchVal";
            this.lblMostCorrectMatchVal.Size = new System.Drawing.Size(35, 19);
            this.lblMostCorrectMatchVal.TabIndex = 5;
            this.lblMostCorrectMatchVal.Text = "N/A";
            // 
            // lblMostCorrectMatch
            // 
            this.lblMostCorrectMatch.AutoSize = true;
            this.lblMostCorrectMatch.Location = new System.Drawing.Point(30, 130);
            this.lblMostCorrectMatch.Name = "lblMostCorrectMatch";
            this.lblMostCorrectMatch.Size = new System.Drawing.Size(121, 13);
            this.lblMostCorrectMatch.TabIndex = 4;
            this.lblMostCorrectMatch.Text = "Partido con más Aciertos:";
            // 
            // lblRepeatedResultVal
            // 
            this.lblRepeatedResultVal.AutoSize = true;
            this.lblRepeatedResultVal.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblRepeatedResultVal.Location = new System.Drawing.Point(280, 90);
            this.lblRepeatedResultVal.Name = "lblRepeatedResultVal";
            this.lblRepeatedResultVal.Size = new System.Drawing.Size(35, 19);
            this.lblRepeatedResultVal.TabIndex = 3;
            this.lblRepeatedResultVal.Text = "N/A";
            // 
            // lblRepeatedResult
            // 
            this.lblRepeatedResult.AutoSize = true;
            this.lblRepeatedResult.Location = new System.Drawing.Point(30, 90);
            this.lblRepeatedResult.Name = "lblRepeatedResult";
            this.lblRepeatedResult.Size = new System.Drawing.Size(130, 13);
            this.lblRepeatedResult.TabIndex = 2;
            this.lblRepeatedResult.Text = "Resultado más Repetido:";
            // 
            // lblMostBetVal
            // 
            this.lblMostBetVal.AutoSize = true;
            this.lblMostBetVal.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblMostBetVal.Location = new System.Drawing.Point(280, 50);
            this.lblMostBetVal.Name = "lblMostBetVal";
            this.lblMostBetVal.Size = new System.Drawing.Size(35, 19);
            this.lblMostBetVal.TabIndex = 1;
            this.lblMostBetVal.Text = "N/A";
            // 
            // lblMostBet
            // 
            this.lblMostBet.AutoSize = true;
            this.lblMostBet.Location = new System.Drawing.Point(30, 50);
            this.lblMostBet.Name = "lblMostBet";
            this.lblMostBet.Size = new System.Drawing.Size(120, 13);
            this.lblMostBet.TabIndex = 0;
            this.lblMostBet.Text = "Selección más Apostada:";
            // 
            // StatisticsFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 511);
            this.Controls.Add(this.panelStats);
            this.Controls.Add(this.btnCompute);
            this.Controls.Add(this.dtpEnd);
            this.Controls.Add(this.lblEnd);
            this.Controls.Add(this.dtpStart);
            this.Controls.Add(this.lblStart);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "StatisticsFrm";
            this.Text = "Quiniegol - Reporte de Estadísticas";
            this.Load += new System.EventHandler(this.StatisticsFrm_Load);
            this.panelStats.ResumeLayout(false);
            this.panelStats.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblStart;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.Label lblEnd;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.Button btnCompute;
        private System.Windows.Forms.Panel panelStats;
        private System.Windows.Forms.Label lblAvgGoalsVal;
        private System.Windows.Forms.Label lblAvgGoals;
        private System.Windows.Forms.Label lblSurpriseVal;
        private System.Windows.Forms.Label lblSurprise;
        private System.Windows.Forms.Label lblMostPredVal;
        private System.Windows.Forms.Label lblMostPred;
        private System.Windows.Forms.Label lblMostCorrectUserVal;
        private System.Windows.Forms.Label lblMostCorrectUser;
        private System.Windows.Forms.Label lblMostCorrectMatchVal;
        private System.Windows.Forms.Label lblMostCorrectMatch;
        private System.Windows.Forms.Label lblRepeatedResultVal;
        private System.Windows.Forms.Label lblRepeatedResult;
        private System.Windows.Forms.Label lblMostBetVal;
        private System.Windows.Forms.Label lblMostBet;
    }
}
