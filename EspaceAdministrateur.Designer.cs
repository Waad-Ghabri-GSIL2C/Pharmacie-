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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BoxLogin = new System.Windows.Forms.TextBox();
            this.BoxMDP = new System.Windows.Forms.TextBox();
            this.BtnConnexion = new System.Windows.Forms.Button();
            this.BtnCompte = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(165, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Login : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(165, 181);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mot de passe :";
            // 
            // BoxLogin
            // 
            this.BoxLogin.Location = new System.Drawing.Point(400, 116);
            this.BoxLogin.Name = "BoxLogin";
            this.BoxLogin.Size = new System.Drawing.Size(100, 22);
            this.BoxLogin.TabIndex = 2;
            this.BoxLogin.TextChanged += new System.EventHandler(this.BoxLogin_TextChanged);
            // 
            // BoxMDP
            // 
            this.BoxMDP.Location = new System.Drawing.Point(400, 181);
            this.BoxMDP.Name = "BoxMDP";
            this.BoxMDP.Size = new System.Drawing.Size(100, 22);
            this.BoxMDP.TabIndex = 3;
            // 
            // BtnConnexion
            // 
            this.BtnConnexion.Location = new System.Drawing.Point(233, 242);
            this.BtnConnexion.Name = "BtnConnexion";
            this.BtnConnexion.Size = new System.Drawing.Size(233, 48);
            this.BtnConnexion.TabIndex = 4;
            this.BtnConnexion.Text = "Connexion";
            this.BtnConnexion.UseVisualStyleBackColor = true;
            // 
            // BtnCompte
            // 
            this.BtnCompte.Location = new System.Drawing.Point(233, 325);
            this.BtnCompte.Name = "BtnCompte";
            this.BtnCompte.Size = new System.Drawing.Size(233, 48);
            this.BtnCompte.TabIndex = 5;
            this.BtnCompte.Text = "Créer un compte";
            this.BtnCompte.UseVisualStyleBackColor = true;
            // 
            // EspaceAdministrateur
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BtnCompte);
            this.Controls.Add(this.BtnConnexion);
            this.Controls.Add(this.BoxMDP);
            this.Controls.Add(this.BoxLogin);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
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
    }
}