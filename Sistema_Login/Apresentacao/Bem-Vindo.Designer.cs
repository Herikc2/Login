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
            this.txtBemVindo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtBemVindo
            // 
            this.txtBemVindo.AutoSize = true;
            this.txtBemVindo.Font = new System.Drawing.Font("Calibri", 39.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBemVindo.Location = new System.Drawing.Point(44, 66);
            this.txtBemVindo.Name = "txtBemVindo";
            this.txtBemVindo.Size = new System.Drawing.Size(295, 64);
            this.txtBemVindo.TabIndex = 0;
            this.txtBemVindo.Text = "BEM-VINDO";
            // 
            // Bem_Vindo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 218);
            this.Controls.Add(this.txtBemVindo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Bem_Vindo";
            this.Text = "Bem_Vindo";
            this.Load += new System.EventHandler(this.Bem_Vindo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label txtBemVindo;
    }
}