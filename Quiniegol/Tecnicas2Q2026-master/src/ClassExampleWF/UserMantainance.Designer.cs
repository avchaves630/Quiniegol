namespace ClassExampleWF
{
    partial class UserMantainance
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
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrev = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.tbxScore = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(811, 542);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(91, 43);
            this.btnNext.TabIndex = 0;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrev
            // 
            this.btnPrev.Location = new System.Drawing.Point(686, 542);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(92, 43);
            this.btnPrev.TabIndex = 1;
            this.btnPrev.Text = "Prev";
            this.btnPrev.UseVisualStyleBackColor = true;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(43, 542);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(190, 43);
            this.btnUpdate.TabIndex = 2;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "label2";
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(147, 48);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(44, 16);
            this.lblUser.TabIndex = 5;
            this.lblUser.Text = "label3";
            // 
            // tbxScore
            // 
            this.tbxScore.Location = new System.Drawing.Point(150, 100);
            this.tbxScore.Name = "tbxScore";
            this.tbxScore.Size = new System.Drawing.Size(120, 22);
            this.tbxScore.TabIndex = 6;
            // 
            // UserMantainance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 627);
            this.Controls.Add(this.tbxScore);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnPrev);
            this.Controls.Add(this.btnNext);
            this.Name = "UserMantainance";
            this.Text = "UserMantainance";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.TextBox tbxScore;
    }
}