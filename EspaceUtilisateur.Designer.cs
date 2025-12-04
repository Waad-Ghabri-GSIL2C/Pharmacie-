namespace Projet_Pharmacie
{
    partial class EspaceUtilisateur
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.BtnAdministrateur = new System.Windows.Forms.Button();
            this.BtnPharmacien = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(308, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Choisissez votre statut : ";
            // 
            // BtnAdministrateur
            // 
            this.BtnAdministrateur.Location = new System.Drawing.Point(283, 143);
            this.BtnAdministrateur.Name = "BtnAdministrateur";
            this.BtnAdministrateur.Size = new System.Drawing.Size(211, 67);
            this.BtnAdministrateur.TabIndex = 1;
            this.BtnAdministrateur.Text = "Administrateur";
            this.BtnAdministrateur.UseVisualStyleBackColor = true;
            this.BtnAdministrateur.Click += new System.EventHandler(this.BtnAdministrateur_Click);
            // 
            // BtnPharmacien
            // 
            this.BtnPharmacien.Location = new System.Drawing.Point(283, 228);
            this.BtnPharmacien.Name = "BtnPharmacien";
            this.BtnPharmacien.Size = new System.Drawing.Size(211, 67);
            this.BtnPharmacien.TabIndex = 2;
            this.BtnPharmacien.Text = "Pharmacien";
            this.BtnPharmacien.UseVisualStyleBackColor = true;
            this.BtnPharmacien.Click += new System.EventHandler(this.BtnPharmacien_Click);
            // 
            // EspaceUtilisateur
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BtnPharmacien);
            this.Controls.Add(this.BtnAdministrateur);
            this.Controls.Add(this.label1);
            this.Name = "EspaceUtilisateur";
            this.Text = "EspaceUtilisateur";
            this.Load += new System.EventHandler(this.EspaceUtilisateur_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnAdministrateur;
        private System.Windows.Forms.Button BtnPharmacien;
    }
}

