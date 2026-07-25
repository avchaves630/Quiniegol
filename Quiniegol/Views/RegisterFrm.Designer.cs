namespace Quiniegol.Views
{
    partial class RegisterFrm
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
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblCountry = new System.Windows.Forms.Label();
            this.cmbCountry = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panelContainer = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(30, 60);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(91, 13);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Nombre Completo";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(33, 80);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(240, 20);
            this.txtName.TabIndex = 1;
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(30, 110);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(98, 13);
            this.lblUsername.TabIndex = 2;
            this.lblUsername.Text = "Nombre de Usuario";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(33, 130);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(240, 20);
            this.txtUsername.TabIndex = 3;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(30, 160);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(94, 13);
            this.lblEmail.TabIndex = 4;
            this.lblEmail.Text = "Correo Electrónico";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(33, 180);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(240, 20);
            this.txtEmail.TabIndex = 5;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(30, 210);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(61, 13);
            this.lblPassword.TabIndex = 6;
            this.lblPassword.Text = "Contraseña";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(33, 230);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(240, 20);
            this.txtPassword.TabIndex = 7;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // lblCountry
            // 
            this.lblCountry.AutoSize = true;
            this.lblCountry.Location = new System.Drawing.Point(30, 260);
            this.lblCountry.Name = "lblCountry";
            this.lblCountry.Size = new System.Drawing.Size(73, 13);
            this.lblCountry.TabIndex = 8;
            this.lblCountry.Text = "País Preferido";
            // 
            // cmbCountry
            // 
            this.cmbCountry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCountry.FormattingEnabled = true;
            this.cmbCountry.Location = new System.Drawing.Point(33, 280);
            this.cmbCountry.Name = "cmbCountry";
            this.cmbCountry.Size = new System.Drawing.Size(240, 21);
            this.cmbCountry.TabIndex = 9;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(33, 325);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(110, 35);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Guardar";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(163, 325);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(110, 35);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // panelContainer
            // 
            this.panelContainer.Controls.Add(this.lblTitle);
            this.panelContainer.Controls.Add(this.lblName);
            this.panelContainer.Controls.Add(this.btnCancel);
            this.panelContainer.Controls.Add(this.txtName);
            this.panelContainer.Controls.Add(this.btnSave);
            this.panelContainer.Controls.Add(this.lblUsername);
            this.panelContainer.Controls.Add(this.cmbCountry);
            this.panelContainer.Controls.Add(this.txtUsername);
            this.panelContainer.Controls.Add(this.lblCountry);
            this.panelContainer.Controls.Add(this.lblEmail);
            this.panelContainer.Controls.Add(this.txtPassword);
            this.panelContainer.Controls.Add(this.txtEmail);
            this.panelContainer.Controls.Add(this.lblPassword);
            this.panelContainer.Location = new System.Drawing.Point(40, 20);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(300, 380);
            this.panelContainer.TabIndex = 12;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(50, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(200, 30);
            this.lblTitle.TabIndex = 12;
            this.lblTitle.Text = "Registro de Usuario";
            // 
            // RegisterFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 421);
            this.Controls.Add(this.panelContainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "RegisterFrm";
            this.Text = "Quiniegol - Registro";
            this.panelContainer.ResumeLayout(false);
            this.panelContainer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblCountry;
        private System.Windows.Forms.ComboBox cmbCountry;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel panelContainer;
        private System.Windows.Forms.Label lblTitle;
    }
}
