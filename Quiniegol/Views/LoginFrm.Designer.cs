namespace Quiniegol.Views
{
    partial class LoginFrm
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
            this.lblUser = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnRegister = new System.Windows.Forms.Button();
            this.panelCard = new System.Windows.Forms.Panel();
            this.panelCard.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(60, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(183, 37);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "QUINIEGOL ⚽";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(30, 80);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(117, 13);
            this.lblUser.TabIndex = 1;
            this.lblUser.Text = "Usuario o Correo Gmail";
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(33, 100);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(240, 20);
            this.txtUser.TabIndex = 2;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(30, 140);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(61, 13);
            this.lblPassword.TabIndex = 3;
            this.lblPassword.Text = "Contraseña";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(33, 160);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(240, 20);
            this.txtPassword.TabIndex = 4;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(33, 210);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(240, 35);
            this.btnLogin.TabIndex = 5;
            this.btnLogin.Text = "Iniciar Sesión";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnRegister
            // 
            this.btnRegister.Location = new System.Drawing.Point(33, 260);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(240, 35);
            this.btnRegister.TabIndex = 6;
            this.btnRegister.Text = "Registrarse";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // panelCard
            // 
            this.panelCard.Controls.Add(this.lblTitle);
            this.panelCard.Controls.Add(this.btnRegister);
            this.panelCard.Controls.Add(this.lblUser);
            this.panelCard.Controls.Add(this.btnLogin);
            this.panelCard.Controls.Add(this.txtUser);
            this.panelCard.Controls.Add(this.txtPassword);
            this.panelCard.Controls.Add(this.lblPassword);
            this.panelCard.Location = new System.Drawing.Point(40, 40);
            this.panelCard.Name = "panelCard";
            this.panelCard.Size = new System.Drawing.Size(300, 320);
            this.panelCard.TabIndex = 7;
            // 
            // LoginFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 411);
            this.Controls.Add(this.panelCard);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "LoginFrm";
            this.Text = "Quiniegol - Iniciar Sesión";
            this.panelCard.ResumeLayout(false);
            this.panelCard.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Panel panelCard;
    }
}
