namespace Projet_Pharmacie
{
    partial class EspaceAdministrateur
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EspaceAdministrateur));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BoxLogin = new System.Windows.Forms.TextBox();
            this.BoxMDP = new System.Windows.Forms.TextBox();
            this.BtnConnexion = new System.Windows.Forms.Button();
            this.BtnCompte = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(205, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Login : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(205, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mot de passe :";
            // 
            // BoxLogin
            // 
            this.BoxLogin.Location = new System.Drawing.Point(391, 58);
            this.BoxLogin.Name = "BoxLogin";
            this.BoxLogin.Size = new System.Drawing.Size(138, 22);
            this.BoxLogin.TabIndex = 2;
            this.BoxLogin.TextChanged += new System.EventHandler(this.BoxLogin_TextChanged);
            // 
            // BoxMDP
            // 
            this.BoxMDP.Location = new System.Drawing.Point(391, 116);
            this.BoxMDP.Name = "BoxMDP";
            this.BoxMDP.Size = new System.Drawing.Size(138, 22);
            this.BoxMDP.TabIndex = 3;
            // 
            // BtnConnexion
            // 
            this.BtnConnexion.BackColor = System.Drawing.Color.ForestGreen;
            this.BtnConnexion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnConnexion.ForeColor = System.Drawing.Color.White;
            this.BtnConnexion.Location = new System.Drawing.Point(268, 164);
            this.BtnConnexion.Name = "BtnConnexion";
            this.BtnConnexion.Size = new System.Drawing.Size(174, 51);
            this.BtnConnexion.TabIndex = 4;
            this.BtnConnexion.Text = "Connexion";
            this.BtnConnexion.UseVisualStyleBackColor = false;
            this.BtnConnexion.Click += new System.EventHandler(this.BtnConnexion_Click);
            // 
            // BtnCompte
            // 
            this.BtnCompte.BackColor = System.Drawing.Color.Green;
            this.BtnCompte.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCompte.ForeColor = System.Drawing.Color.White;
            this.BtnCompte.Location = new System.Drawing.Point(268, 322);
            this.BtnCompte.Name = "BtnCompte";
            this.BtnCompte.Size = new System.Drawing.Size(174, 51);
            this.BtnCompte.TabIndex = 5;
            this.BtnCompte.Text = "Créer un compte";
            this.BtnCompte.UseVisualStyleBackColor = false;
            this.BtnCompte.Click += new System.EventHandler(this.BtnCompte_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(205, 278);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(252, 18);
            this.label3.TabIndex = 6;
            this.label3.Text = "Vous n’avez pas encore de compte ?";
            // 
            // EspaceAdministrateur
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(736, 440);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.BtnCompte);
            this.Controls.Add(this.BtnConnexion);
            this.Controls.Add(this.BoxMDP);
            this.Controls.Add(this.BoxLogin);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EspaceAdministrateur";
            this.Text = "EspaceAdministrateur";
            this.Load += new System.EventHandler(this.EspaceAdministrateur_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox BoxLogin;
        private System.Windows.Forms.TextBox BoxMDP;
        private System.Windows.Forms.Button BtnConnexion;
        private System.Windows.Forms.Button BtnCompte;
        private System.Windows.Forms.Label label3;
    }
}