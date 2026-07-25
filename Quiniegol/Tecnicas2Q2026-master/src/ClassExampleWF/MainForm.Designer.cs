namespace ClassExampleWF
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnExamples = new System.Windows.Forms.Button();
            this.btnMantainance = new System.Windows.Forms.Button();
            this.btnRanking = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnExamples
            // 
            this.btnExamples.Location = new System.Drawing.Point(87, 77);
            this.btnExamples.Name = "btnExamples";
            this.btnExamples.Size = new System.Drawing.Size(140, 40);
            this.btnExamples.TabIndex = 0;
            this.btnExamples.Text = "Examples";
            this.btnExamples.UseVisualStyleBackColor = true;
            this.btnExamples.Click += new System.EventHandler(this.btnExamples_Click);
            // 
            // btnMantainance
            // 
            this.btnMantainance.Location = new System.Drawing.Point(87, 138);
            this.btnMantainance.Name = "btnMantainance";
            this.btnMantainance.Size = new System.Drawing.Size(140, 40);
            this.btnMantainance.TabIndex = 1;
            this.btnMantainance.Text = "User Mantainance";
            this.btnMantainance.UseVisualStyleBackColor = true;
            this.btnMantainance.Click += new System.EventHandler(this.btnMantainance_Click);
            // 
            // btnRanking
            // 
            this.btnRanking.Location = new System.Drawing.Point(87, 194);
            this.btnRanking.Name = "btnRanking";
            this.btnRanking.Size = new System.Drawing.Size(140, 40);
            this.btnRanking.TabIndex = 2;
            this.btnRanking.Text = "Ranking";
            this.btnRanking.UseVisualStyleBackColor = true;
            this.btnRanking.Click += new System.EventHandler(this.btnRanking_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnRanking);
            this.Controls.Add(this.btnMantainance);
            this.Controls.Add(this.btnExamples);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnExamples;
        private System.Windows.Forms.Button btnMantainance;
        private System.Windows.Forms.Button btnRanking;
    }
}