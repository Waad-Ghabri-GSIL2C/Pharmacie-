namespace Projet_Pharmacie
{
    partial class CompteAdministrateur
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
            this.btn_Gestioncomptes = new System.Windows.Forms.Button();
            this.btn_Gestionstock = new System.Windows.Forms.Button();
            this.btn_Gestionfournisseurs = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_Gestioncomptes
            // 
            this.btn_Gestioncomptes.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btn_Gestioncomptes.Location = new System.Drawing.Point(150, 151);
            this.btn_Gestioncomptes.Name = "btn_Gestioncomptes";
            this.btn_Gestioncomptes.Size = new System.Drawing.Size(286, 66);
            this.btn_Gestioncomptes.TabIndex = 0;
            this.btn_Gestioncomptes.Text = "Gestion comptes";
            this.btn_Gestioncomptes.UseVisualStyleBackColor = false;
            this.btn_Gestioncomptes.Click += new System.EventHandler(this.btn_Gestioncomptes_Click);
            // 
            // btn_Gestionstock
            // 
            this.btn_Gestionstock.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btn_Gestionstock.Location = new System.Drawing.Point(150, 265);
            this.btn_Gestionstock.Name = "btn_Gestionstock";
            this.btn_Gestionstock.Size = new System.Drawing.Size(286, 66);
            this.btn_Gestionstock.TabIndex = 1;
            this.btn_Gestionstock.Text = "Gestion stock";
            this.btn_Gestionstock.UseVisualStyleBackColor = false;
            this.btn_Gestionstock.Click += new System.EventHandler(this.btn_Gestionstock_Click);
            // 
            // btn_Gestionfournisseurs
            // 
            this.btn_Gestionfournisseurs.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btn_Gestionfournisseurs.Location = new System.Drawing.Point(150, 378);
            this.btn_Gestionfournisseurs.Name = "btn_Gestionfournisseurs";
            this.btn_Gestionfournisseurs.Size = new System.Drawing.Size(286, 66);
            this.btn_Gestionfournisseurs.TabIndex = 2;
            this.btn_Gestionfournisseurs.Text = "Gestion fournisseurs";
            this.btn_Gestionfournisseurs.UseVisualStyleBackColor = false;
            this.btn_Gestionfournisseurs.Click += new System.EventHandler(this.btn_Gestionfournisseurs_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(68, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Bienvenue Dr. ";
            // 
            // CompteAdministrateur
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(599, 504);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_Gestionfournisseurs);
            this.Controls.Add(this.btn_Gestionstock);
            this.Controls.Add(this.btn_Gestioncomptes);
            this.Name = "CompteAdministrateur";
            this.Text = "Votre compte (admin) ";
            this.Load += new System.EventHandler(this.CompteAdministrateur_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Gestioncomptes;
        private System.Windows.Forms.Button btn_Gestionstock;
        private System.Windows.Forms.Button btn_Gestionfournisseurs;
        private System.Windows.Forms.Label label1;
    }
}