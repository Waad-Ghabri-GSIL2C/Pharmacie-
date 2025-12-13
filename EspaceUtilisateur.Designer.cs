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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EspaceUtilisateur));
            this.label1 = new System.Windows.Forms.Label();
            this.BtnAdministrateur = new System.Windows.Forms.Button();
            this.BtnPharmacien = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Green;
            this.label1.Location = new System.Drawing.Point(82, 141);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(558, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bienvenue dans la plateforme de gestion de pharmacie ! ";
            // 
            // BtnAdministrateur
            // 
            this.BtnAdministrateur.BackColor = System.Drawing.Color.Snow;
            this.BtnAdministrateur.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAdministrateur.Location = new System.Drawing.Point(244, 309);
            this.BtnAdministrateur.Name = "BtnAdministrateur";
            this.BtnAdministrateur.Size = new System.Drawing.Size(249, 84);
            this.BtnAdministrateur.TabIndex = 1;
            this.BtnAdministrateur.Text = "Administrateur";
            this.BtnAdministrateur.UseVisualStyleBackColor = true;
            this.BtnAdministrateur.Click += new System.EventHandler(this.BtnAdministrateur_Click);
            // 
            // BtnPharmacien
            // 
            this.BtnPharmacien.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPharmacien.Location = new System.Drawing.Point(244, 423);
            this.BtnPharmacien.Name = "BtnPharmacien";
            this.BtnPharmacien.Size = new System.Drawing.Size(249, 84);
            this.BtnPharmacien.TabIndex = 2;
            this.BtnPharmacien.Text = "Pharmacien";
            this.BtnPharmacien.UseVisualStyleBackColor = true;
            this.BtnPharmacien.Click += new System.EventHandler(this.BtnPharmacien_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(45, 249);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(428, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Merci d’indiquer votre rôle afin d’accéder à votre espace";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Projet_Pharmacie.Properties.Resources.logo_removebg_preview;
            this.pictureBox1.Location = new System.Drawing.Point(290, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(124, 117);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // EspaceUtilisateur
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(722, 587);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BtnPharmacien);
            this.Controls.Add(this.BtnAdministrateur);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EspaceUtilisateur";
            this.Text = "EspaceUtilisateur";
            this.Load += new System.EventHandler(this.EspaceUtilisateur_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnAdministrateur;
        private System.Windows.Forms.Button BtnPharmacien;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

