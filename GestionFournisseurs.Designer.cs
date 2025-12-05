namespace Projet_Pharmacie
{
    partial class GestionFournisseurs
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
            this.dgvFournisseurs = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNomProduit = new System.Windows.Forms.TextBox();
            this.txtQuantite = new System.Windows.Forms.TextBox();
            this.txtDelai = new System.Windows.Forms.TextBox();
            this.btnValiderCommande = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dgvCommandes = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFournisseurs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCommandes)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvFournisseurs
            // 
            this.dgvFournisseurs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFournisseurs.Location = new System.Drawing.Point(108, 63);
            this.dgvFournisseurs.Name = "dgvFournisseurs";
            this.dgvFournisseurs.RowHeadersWidth = 51;
            this.dgvFournisseurs.RowTemplate.Height = 24;
            this.dgvFournisseurs.Size = new System.Drawing.Size(812, 150);
            this.dgvFournisseurs.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(89, 250);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nom produit ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(311, 250);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Quantité ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(524, 250);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Délai";
            // 
            // txtNomProduit
            // 
            this.txtNomProduit.Location = new System.Drawing.Point(92, 269);
            this.txtNomProduit.Name = "txtNomProduit";
            this.txtNomProduit.Size = new System.Drawing.Size(146, 22);
            this.txtNomProduit.TabIndex = 4;
            // 
            // txtQuantite
            // 
            this.txtQuantite.Location = new System.Drawing.Point(314, 269);
            this.txtQuantite.Name = "txtQuantite";
            this.txtQuantite.Size = new System.Drawing.Size(146, 22);
            this.txtQuantite.TabIndex = 5;
            // 
            // txtDelai
            // 
            this.txtDelai.Location = new System.Drawing.Point(527, 269);
            this.txtDelai.Name = "txtDelai";
            this.txtDelai.Size = new System.Drawing.Size(146, 22);
            this.txtDelai.TabIndex = 6;
            // 
            // btnValiderCommande
            // 
            this.btnValiderCommande.Location = new System.Drawing.Point(763, 250);
            this.btnValiderCommande.Name = "btnValiderCommande";
            this.btnValiderCommande.Size = new System.Drawing.Size(176, 44);
            this.btnValiderCommande.TabIndex = 7;
            this.btnValiderCommande.Text = "Valider la commande ";
            this.btnValiderCommande.UseVisualStyleBackColor = true;
            this.btnValiderCommande.Click += new System.EventHandler(this.btnValiderCommande_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(37, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(155, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "Passer une commande : ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(37, 358);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(250, 16);
            this.label5.TabIndex = 10;
            this.label5.Text = "Confirmer la réception de la commande : ";
            // 
            // dgvCommandes
            // 
            this.dgvCommandes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCommandes.Location = new System.Drawing.Point(80, 392);
            this.dgvCommandes.Name = "dgvCommandes";
            this.dgvCommandes.RowHeadersWidth = 51;
            this.dgvCommandes.RowTemplate.Height = 24;
            this.dgvCommandes.Size = new System.Drawing.Size(871, 150);
            this.dgvCommandes.TabIndex = 8;
            this.dgvCommandes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCommandes_CellContentClick);
            // 
            // GestionFournisseurs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1081, 608);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dgvCommandes);
            this.Controls.Add(this.btnValiderCommande);
            this.Controls.Add(this.txtDelai);
            this.Controls.Add(this.txtQuantite);
            this.Controls.Add(this.txtNomProduit);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvFournisseurs);
            this.Name = "GestionFournisseurs";
            this.Text = "GestionFournisseurs";
            ((System.ComponentModel.ISupportInitialize)(this.dgvFournisseurs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCommandes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvFournisseurs;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNomProduit;
        private System.Windows.Forms.TextBox txtQuantite;
        private System.Windows.Forms.TextBox txtDelai;
        private System.Windows.Forms.Button btnValiderCommande;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgvCommandes;
    }
}