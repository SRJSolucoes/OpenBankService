namespace SRJBancTransferForm
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbEmpresa = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbUsuarioSRJ = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tbSenhaSRJ = new System.Windows.Forms.TextBox();
            this.tbUsuarioT28 = new System.Windows.Forms.TextBox();
            this.tbSenhaT28 = new System.Windows.Forms.TextBox();
            this.tbSenha4Dig = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(380, 327);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(96, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Processar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Usuário SRJ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Senha SRJ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 15);
            this.label3.TabIndex = 1;
            this.label3.Text = "Usuário T28";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 15);
            this.label4.TabIndex = 1;
            this.label4.Text = "Senha T28";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 82);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 15);
            this.label5.TabIndex = 1;
            this.label5.Text = "Senha de 4 Digitos";
            // 
            // cbEmpresa
            // 
            this.cbEmpresa.FormattingEnabled = true;
            this.cbEmpresa.Location = new System.Drawing.Point(125, 155);
            this.cbEmpresa.Name = "cbEmpresa";
            this.cbEmpresa.Size = new System.Drawing.Size(310, 23);
            this.cbEmpresa.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 158);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 15);
            this.label6.TabIndex = 1;
            this.label6.Text = "Empresa";
            // 
            // tbUsuarioSRJ
            // 
            this.tbUsuarioSRJ.Location = new System.Drawing.Point(125, 98);
            this.tbUsuarioSRJ.Name = "tbUsuarioSRJ";
            this.tbUsuarioSRJ.Size = new System.Drawing.Size(201, 23);
            this.tbUsuarioSRJ.TabIndex = 3;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(9, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(189, 68);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // tbSenhaSRJ
            // 
            this.tbSenhaSRJ.Location = new System.Drawing.Point(125, 127);
            this.tbSenhaSRJ.Name = "tbSenhaSRJ";
            this.tbSenhaSRJ.PasswordChar = '*';
            this.tbSenhaSRJ.Size = new System.Drawing.Size(201, 23);
            this.tbSenhaSRJ.TabIndex = 3;
            // 
            // tbUsuarioT28
            // 
            this.tbUsuarioT28.Location = new System.Drawing.Point(116, 22);
            this.tbUsuarioT28.Name = "tbUsuarioT28";
            this.tbUsuarioT28.Size = new System.Drawing.Size(201, 23);
            this.tbUsuarioT28.TabIndex = 3;
            // 
            // tbSenhaT28
            // 
            this.tbSenhaT28.Location = new System.Drawing.Point(116, 51);
            this.tbSenhaT28.Name = "tbSenhaT28";
            this.tbSenhaT28.Size = new System.Drawing.Size(201, 23);
            this.tbSenhaT28.TabIndex = 3;
            // 
            // tbSenha4Dig
            // 
            this.tbSenha4Dig.Location = new System.Drawing.Point(116, 79);
            this.tbSenha4Dig.Name = "tbSenha4Dig";
            this.tbSenha4Dig.PasswordChar = '*';
            this.tbSenha4Dig.Size = new System.Drawing.Size(94, 23);
            this.tbSenha4Dig.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 78);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(464, 122);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dados SRJ";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(317, 49);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(106, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Mostrar senha";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.tbSenha4Dig);
            this.groupBox2.Controls.Add(this.tbSenhaT28);
            this.groupBox2.Controls.Add(this.tbUsuarioT28);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(9, 206);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(466, 115);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Dados T28";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(212, 79);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(106, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "Mostrar senha";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 361);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.tbSenhaSRJ);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.tbUsuarioSRJ);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbEmpresa);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.Text = "SRJ - Processamente de Pagamentos";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbEmpresa;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbUsuarioSRJ;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox tbSenhaSRJ;
        private System.Windows.Forms.TextBox tbUsuarioT28;
        private System.Windows.Forms.TextBox tbSenhaT28;
        private System.Windows.Forms.TextBox tbSenha4Dig;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}

