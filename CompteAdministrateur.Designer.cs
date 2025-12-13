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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CompteAdministrateur));
            this.btn_Gestioncomptes = new System.Windows.Forms.Button();
            this.btn_Gestionstock = new System.Windows.Forms.Button();
            this.btn_Gestionfournisseurs = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_retour = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Gestioncomptes
            // 
            this.btn_Gestioncomptes.BackColor = System.Drawing.Color.Green;
            this.btn_Gestioncomptes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Gestioncomptes.ForeColor = System.Drawing.Color.White;
            this.btn_Gestioncomptes.Location = new System.Drawing.Point(166, 127);
            this.btn_Gestioncomptes.Name = "btn_Gestioncomptes";
            this.btn_Gestioncomptes.Size = new System.Drawing.Size(342, 75);
            this.btn_Gestioncomptes.TabIndex = 0;
            this.btn_Gestioncomptes.Text = "Gérer les comptes pharmaciens ";
            this.btn_Gestioncomptes.UseVisualStyleBackColor = false;
            this.btn_Gestioncomptes.Click += new System.EventHandler(this.btn_Gestioncomptes_Click);
            // 
            // btn_Gestionstock
            // 
            this.btn_Gestionstock.BackColor = System.Drawing.Color.Green;
            this.btn_Gestionstock.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Gestionstock.ForeColor = System.Drawing.Color.White;
            this.btn_Gestionstock.Location = new System.Drawing.Point(166, 245);
            this.btn_Gestionstock.Name = "btn_Gestionstock";
            this.btn_Gestionstock.Size = new System.Drawing.Size(342, 75);
            this.btn_Gestionstock.TabIndex = 1;
            this.btn_Gestionstock.Text = "Gérer le stock ";
            this.btn_Gestionstock.UseVisualStyleBackColor = false;
            this.btn_Gestionstock.Click += new System.EventHandler(this.btn_Gestionstock_Click);
            // 
            // btn_Gestionfournisseurs
            // 
            this.btn_Gestionfournisseurs.BackColor = System.Drawing.Color.Green;
            this.btn_Gestionfournisseurs.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Gestionfournisseurs.ForeColor = System.Drawing.Color.White;
            this.btn_Gestionfournisseurs.Location = new System.Drawing.Point(166, 365);
            this.btn_Gestionfournisseurs.Name = "btn_Gestionfournisseurs";
            this.btn_Gestionfournisseurs.Size = new System.Drawing.Size(342, 75);
            this.btn_Gestionfournisseurs.TabIndex = 2;
            this.btn_Gestionfournisseurs.Text = "Gérer les commandes fournisseurs";
            this.btn_Gestionfournisseurs.UseVisualStyleBackColor = false;
            this.btn_Gestionfournisseurs.Click += new System.EventHandler(this.btn_Gestionfournisseurs_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Green;
            this.label1.Location = new System.Drawing.Point(41, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Bienvenue Dr. ";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::Projet_Pharmacie.Properties.Resources.frs;
            this.pictureBox3.Location = new System.Drawing.Point(123, 382);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(37, 38);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 6;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Projet_Pharmacie.Properties.Resources.stock;
            this.pictureBox2.Location = new System.Drawing.Point(123, 264);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(37, 38);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Projet_Pharmacie.Properties.Resources.icon;
            this.pictureBox1.Location = new System.Drawing.Point(123, 144);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(37, 38);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // btn_retour
            // 
            this.btn_retour.BackColor = System.Drawing.Color.LightGreen;
            this.btn_retour.Location = new System.Drawing.Point(475, 486);
            this.btn_retour.Name = "btn_retour";
            this.btn_retour.Size = new System.Drawing.Size(191, 48);
            this.btn_retour.TabIndex = 7;
            this.btn_retour.Text = "Annuler";
            this.btn_retour.UseVisualStyleBackColor = false;
            this.btn_retour.Click += new System.EventHandler(this.btn_retour_Click);
            // 
            // CompteAdministrateur
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(687, 555);
            this.Controls.Add(this.btn_retour);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_Gestionfournisseurs);
            this.Controls.Add(this.btn_Gestionstock);
            this.Controls.Add(this.btn_Gestioncomptes);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CompteAdministrateur";
            this.Text = "Votre compte (admin) ";
            this.Load += new System.EventHandler(this.CompteAdministrateur_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Gestioncomptes;
        private System.Windows.Forms.Button btn_Gestionstock;
        private System.Windows.Forms.Button btn_Gestionfournisseurs;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Button btn_retour;
    }
}