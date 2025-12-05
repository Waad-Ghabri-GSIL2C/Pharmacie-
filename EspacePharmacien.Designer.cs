namespace Projet_Pharmacie
{
    partial class EspacePharmacien
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BoxLogin1 = new System.Windows.Forms.TextBox();
            this.BoxMDP1 = new System.Windows.Forms.TextBox();
            this.BtnConnexion1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(178, 119);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Login : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(178, 194);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mot de passe : ";
            // 
            // BoxLogin1
            // 
            this.BoxLogin1.Location = new System.Drawing.Point(381, 116);
            this.BoxLogin1.Name = "BoxLogin1";
            this.BoxLogin1.Size = new System.Drawing.Size(189, 22);
            this.BoxLogin1.TabIndex = 2;
            this.BoxLogin1.TextChanged += new System.EventHandler(this.BoxLogin1_TextChanged);
            // 
            // BoxMDP1
            // 
            this.BoxMDP1.Location = new System.Drawing.Point(381, 188);
            this.BoxMDP1.Name = "BoxMDP1";
            this.BoxMDP1.Size = new System.Drawing.Size(189, 22);
            this.BoxMDP1.TabIndex = 3;
            // 
            // BtnConnexion1
            // 
            this.BtnConnexion1.Location = new System.Drawing.Point(287, 268);
            this.BtnConnexion1.Name = "BtnConnexion1";
            this.BtnConnexion1.Size = new System.Drawing.Size(148, 54);
            this.BtnConnexion1.TabIndex = 4;
            this.BtnConnexion1.Text = "Connexion";
            this.BtnConnexion1.UseVisualStyleBackColor = true;
            this.BtnConnexion1.Click += new System.EventHandler(this.BtnConnexion1_Click);
            // 
            // EspacePharmacien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 422);
            this.Controls.Add(this.BtnConnexion1);
            this.Controls.Add(this.BoxMDP1);
            this.Controls.Add(this.BoxLogin1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "EspacePharmacien";
            this.Text = "EspacePharmacien";
            this.Load += new System.EventHandler(this.EspacePharmacien_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox BoxLogin1;
        private System.Windows.Forms.TextBox BoxMDP1;
        private System.Windows.Forms.Button BtnConnexion1;
    }
}