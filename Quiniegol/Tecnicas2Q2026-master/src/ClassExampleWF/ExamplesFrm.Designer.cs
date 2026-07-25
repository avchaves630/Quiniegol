namespace ClassExampleWF
{
    partial class ExamplesFrm
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
            this.elementsSumBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.resultTbx = new System.Windows.Forms.TextBox();
            this.countCharOccurenciesBtn = new System.Windows.Forms.Button();
            this.minMaxBtn = new System.Windows.Forms.Button();
            this.findIndexBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // elementsSumBtn
            // 
            this.elementsSumBtn.Location = new System.Drawing.Point(51, 315);
            this.elementsSumBtn.Name = "elementsSumBtn";
            this.elementsSumBtn.Size = new System.Drawing.Size(184, 51);
            this.elementsSumBtn.TabIndex = 0;
            this.elementsSumBtn.Text = "Suma de elementos";
            this.elementsSumBtn.UseVisualStyleBackColor = true;
            this.elementsSumBtn.Click += new System.EventHandler(this.ElementsSumClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Valor 1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 129);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Valor 2";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(172, 59);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(146, 22);
            this.textBox1.TabIndex = 3;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(172, 123);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(146, 22);
            this.textBox2.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(48, 202);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Result";
            // 
            // resultTbx
            // 
            this.resultTbx.Location = new System.Drawing.Point(172, 196);
            this.resultTbx.Name = "resultTbx";
            this.resultTbx.Size = new System.Drawing.Size(440, 22);
            this.resultTbx.TabIndex = 6;
            // 
            // countCharOccurenciesBtn
            // 
            this.countCharOccurenciesBtn.Location = new System.Drawing.Point(241, 315);
            this.countCharOccurenciesBtn.Name = "countCharOccurenciesBtn";
            this.countCharOccurenciesBtn.Size = new System.Drawing.Size(187, 51);
            this.countCharOccurenciesBtn.TabIndex = 7;
            this.countCharOccurenciesBtn.Text = "Count char occurrences";
            this.countCharOccurenciesBtn.UseVisualStyleBackColor = true;
            this.countCharOccurenciesBtn.Click += new System.EventHandler(this.countCharOccurencies_Click);
            // 
            // minMaxBtn
            // 
            this.minMaxBtn.Location = new System.Drawing.Point(434, 315);
            this.minMaxBtn.Name = "minMaxBtn";
            this.minMaxBtn.Size = new System.Drawing.Size(149, 51);
            this.minMaxBtn.TabIndex = 8;
            this.minMaxBtn.Text = "Min/Max";
            this.minMaxBtn.UseVisualStyleBackColor = true;
            this.minMaxBtn.Click += new System.EventHandler(this.minMaxBtnClick);
            // 
            // findIndexBtn
            // 
            this.findIndexBtn.Location = new System.Drawing.Point(606, 315);
            this.findIndexBtn.Name = "findIndexBtn";
            this.findIndexBtn.Size = new System.Drawing.Size(127, 51);
            this.findIndexBtn.TabIndex = 9;
            this.findIndexBtn.Text = "Find Index";
            this.findIndexBtn.UseVisualStyleBackColor = true;
            this.findIndexBtn.Click += new System.EventHandler(this.findIndexBtnClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.findIndexBtn);
            this.Controls.Add(this.minMaxBtn);
            this.Controls.Add(this.countCharOccurenciesBtn);
            this.Controls.Add(this.resultTbx);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.elementsSumBtn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button elementsSumBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox resultTbx;
        private System.Windows.Forms.Button countCharOccurenciesBtn;
        private System.Windows.Forms.Button minMaxBtn;
        private System.Windows.Forms.Button findIndexBtn;
    }
}

