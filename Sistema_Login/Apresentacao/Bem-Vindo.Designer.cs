namespace Sistema_Login.Apresentacao
{
    partial class Bem_Vindo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Bem_Vindo));
            this.menuTop = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCPF = new System.Windows.Forms.TextBox();
            this.btnEnviar = new System.Windows.Forms.Button();
            this.txtNomeFiltro = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEmailFiltro = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.rdnF = new System.Windows.Forms.RadioButton();
            this.rdnO = new System.Windows.Forms.RadioButton();
            this.rdnM = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.dvgPessoa = new System.Windows.Forms.DataGridView();
            this.btnDeletar = new System.Windows.Forms.Button();
            this.btnInserir = new System.Windows.Forms.Button();
            this.btnExibir = new System.Windows.Forms.Button();
            this.btnAbout = new System.Windows.Forms.Button();
            this.menuTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dvgPessoa)).BeginInit();
            this.SuspendLayout();
            // 
            // menuTop
            // 
            this.menuTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(70)))));
            this.menuTop.Controls.Add(this.btnExit);
            this.menuTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.menuTop.Location = new System.Drawing.Point(0, 0);
            this.menuTop.Name = "menuTop";
            this.menuTop.Size = new System.Drawing.Size(679, 45);
            this.menuTop.TabIndex = 9;
            // 
            // btnExit
            // 
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.Location = new System.Drawing.Point(638, 6);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(30, 30);
            this.btnExit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnExit.TabIndex = 0;
            this.btnExit.TabStop = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(387, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 26);
            this.label1.TabIndex = 10;
            this.label1.Text = "CPF:";
            // 
            // txtCPF
            // 
            this.txtCPF.Location = new System.Drawing.Point(446, 70);
            this.txtCPF.Name = "txtCPF";
            this.txtCPF.Size = new System.Drawing.Size(158, 20);
            this.txtCPF.TabIndex = 11;
            // 
            // btnEnviar
            // 
            this.btnEnviar.Location = new System.Drawing.Point(152, 160);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(73, 34);
            this.btnEnviar.TabIndex = 12;
            this.btnEnviar.Text = "Filtrar";
            this.btnEnviar.UseVisualStyleBackColor = true;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // txtNomeFiltro
            // 
            this.txtNomeFiltro.Location = new System.Drawing.Point(152, 70);
            this.txtNomeFiltro.Name = "txtNomeFiltro";
            this.txtNomeFiltro.Size = new System.Drawing.Size(158, 20);
            this.txtNomeFiltro.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(60, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 26);
            this.label2.TabIndex = 13;
            this.label2.Text = "NOME:";
            // 
            // txtEmailFiltro
            // 
            this.txtEmailFiltro.Location = new System.Drawing.Point(152, 123);
            this.txtEmailFiltro.Name = "txtEmailFiltro";
            this.txtEmailFiltro.Size = new System.Drawing.Size(158, 20);
            this.txtEmailFiltro.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(57, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 26);
            this.label3.TabIndex = 15;
            this.label3.Text = "E-MAIL:";
            // 
            // rdnF
            // 
            this.rdnF.AutoSize = true;
            this.rdnF.ForeColor = System.Drawing.Color.White;
            this.rdnF.Location = new System.Drawing.Point(527, 124);
            this.rdnF.Name = "rdnF";
            this.rdnF.Size = new System.Drawing.Size(67, 17);
            this.rdnF.TabIndex = 17;
            this.rdnF.TabStop = true;
            this.rdnF.Text = "Feminino";
            this.rdnF.UseVisualStyleBackColor = true;
            // 
            // rdnO
            // 
            this.rdnO.AutoSize = true;
            this.rdnO.ForeColor = System.Drawing.Color.White;
            this.rdnO.Location = new System.Drawing.Point(600, 126);
            this.rdnO.Name = "rdnO";
            this.rdnO.Size = new System.Drawing.Size(51, 17);
            this.rdnO.TabIndex = 18;
            this.rdnO.TabStop = true;
            this.rdnO.Text = "Outro";
            this.rdnO.UseVisualStyleBackColor = true;
            // 
            // rdnM
            // 
            this.rdnM.AutoSize = true;
            this.rdnM.ForeColor = System.Drawing.Color.White;
            this.rdnM.Location = new System.Drawing.Point(448, 124);
            this.rdnM.Name = "rdnM";
            this.rdnM.Size = new System.Drawing.Size(73, 17);
            this.rdnM.TabIndex = 19;
            this.rdnM.TabStop = true;
            this.rdnM.Text = "Masculino";
            this.rdnM.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(387, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 26);
            this.label4.TabIndex = 20;
            this.label4.Text = "SEXO:";
            // 
            // dvgPessoa
            // 
            this.dvgPessoa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvgPessoa.Location = new System.Drawing.Point(0, 200);
            this.dvgPessoa.Name = "dvgPessoa";
            this.dvgPessoa.Size = new System.Drawing.Size(679, 223);
            this.dvgPessoa.TabIndex = 21;
            this.dvgPessoa.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dvgPessoa_CellContentClick);
            // 
            // btnDeletar
            // 
            this.btnDeletar.Location = new System.Drawing.Point(417, 160);
            this.btnDeletar.Name = "btnDeletar";
            this.btnDeletar.Size = new System.Drawing.Size(62, 34);
            this.btnDeletar.TabIndex = 22;
            this.btnDeletar.Text = "Deletar";
            this.btnDeletar.UseVisualStyleBackColor = true;
            this.btnDeletar.Click += new System.EventHandler(this.btnDeletar_Click);
            // 
            // btnInserir
            // 
            this.btnInserir.Location = new System.Drawing.Point(329, 160);
            this.btnInserir.Name = "btnInserir";
            this.btnInserir.Size = new System.Drawing.Size(65, 34);
            this.btnInserir.TabIndex = 23;
            this.btnInserir.Text = "Inserir";
            this.btnInserir.UseVisualStyleBackColor = true;
            this.btnInserir.Click += new System.EventHandler(this.btnInserir_Click);
            // 
            // btnExibir
            // 
            this.btnExibir.Location = new System.Drawing.Point(240, 160);
            this.btnExibir.Name = "btnExibir";
            this.btnExibir.Size = new System.Drawing.Size(72, 34);
            this.btnExibir.TabIndex = 24;
            this.btnExibir.Text = "Exibir";
            this.btnExibir.UseVisualStyleBackColor = true;
            this.btnExibir.Click += new System.EventHandler(this.btnExibir_Click);
            // 
            // btnAbout
            // 
            this.btnAbout.Location = new System.Drawing.Point(500, 160);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(62, 34);
            this.btnAbout.TabIndex = 25;
            this.btnAbout.Text = "About";
            this.btnAbout.UseVisualStyleBackColor = true;
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // Bem_Vindo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(46)))));
            this.ClientSize = new System.Drawing.Size(679, 423);
            this.Controls.Add(this.btnAbout);
            this.Controls.Add(this.btnExibir);
            this.Controls.Add(this.btnInserir);
            this.Controls.Add(this.btnDeletar);
            this.Controls.Add(this.dvgPessoa);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.rdnM);
            this.Controls.Add(this.rdnO);
            this.Controls.Add(this.rdnF);
            this.Controls.Add(this.txtEmailFiltro);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNomeFiltro);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnEnviar);
            this.Controls.Add(this.txtCPF);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Bem_Vindo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bem_Vindo";
            this.menuTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dvgPessoa)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel menuTop;
        private System.Windows.Forms.PictureBox btnExit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCPF;
        private System.Windows.Forms.Button btnEnviar;
        private System.Windows.Forms.TextBox txtNomeFiltro;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEmailFiltro;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rdnF;
        private System.Windows.Forms.RadioButton rdnO;
        private System.Windows.Forms.RadioButton rdnM;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dvgPessoa;
        private System.Windows.Forms.Button btnDeletar;
        private System.Windows.Forms.Button btnInserir;
        private System.Windows.Forms.Button btnExibir;
        private System.Windows.Forms.Button btnAbout;
    }
}