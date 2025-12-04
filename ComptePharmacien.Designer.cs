namespace Projet_Pharmacie
{
    partial class ComptePharmacien
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.dgvStock = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNP = new System.Windows.Forms.TextBox();
            this.txtQte = new System.Windows.Forms.TextBox();
            this.btnRecherche = new System.Windows.Forms.Button();
            this.btnAjouter = new System.Windows.Forms.Button();
            this.btnAfficher = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStock)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvStock
            // 
            this.dgvStock.AllowUserToAddRows = false;
            this.dgvStock.AllowUserToDeleteRows = false;
            this.dgvStock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStock.Location = new System.Drawing.Point(95, 54);
            this.dgvStock.MultiSelect = false;
            this.dgvStock.Name = "dgvStock";
            this.dgvStock.ReadOnly = true;
            this.dgvStock.RowHeadersWidth = 51;
            this.dgvStock.RowTemplate.Height = 24;
            this.dgvStock.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStock.Size = new System.Drawing.Size(861, 150);
            this.dgvStock.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(226, 256);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nom produit :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(605, 259);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Quantité :";
            // 
            // txtNP
            // 
            this.txtNP.Location = new System.Drawing.Point(329, 253);
            this.txtNP.Name = "txtNP";
            this.txtNP.Size = new System.Drawing.Size(120, 22);
            this.txtNP.TabIndex = 3;
            this.txtNP.TextChanged += new System.EventHandler(this.txtNP_TextChanged);
            // 
            // txtQte
            // 
            this.txtQte.Location = new System.Drawing.Point(708, 256);
            this.txtQte.Name = "txtQte";
            this.txtQte.Size = new System.Drawing.Size(120, 22);
            this.txtQte.TabIndex = 4;
            this.txtQte.TextChanged += new System.EventHandler(this.txtQte_TextChanged);
            // 
            // btnRecherche
            // 
            this.btnRecherche.Location = new System.Drawing.Point(229, 308);
            this.btnRecherche.Name = "btnRecherche";
            this.btnRecherche.Size = new System.Drawing.Size(220, 34);
            this.btnRecherche.TabIndex = 5;
            this.btnRecherche.Text = "Rechercher";
            this.btnRecherche.UseVisualStyleBackColor = true;
            this.btnRecherche.Click += new System.EventHandler(this.btnRechercher_Click);
            // 
            // btnAjouter
            // 
            this.btnAjouter.Location = new System.Drawing.Point(608, 308);
            this.btnAjouter.Name = "btnAjouter";
            this.btnAjouter.Size = new System.Drawing.Size(220, 37);
            this.btnAjouter.TabIndex = 6;
            this.btnAjouter.Text = "Ajouter à la liste de vente";
            this.btnAjouter.UseVisualStyleBackColor = true;
            this.btnAjouter.Click += new System.EventHandler(this.btnAjouter_Click);
            // 
            // btnAfficher
            // 
            this.btnAfficher.Location = new System.Drawing.Point(810, 387);
            this.btnAfficher.Name = "btnAfficher";
            this.btnAfficher.Size = new System.Drawing.Size(220, 37);
            this.btnAfficher.TabIndex = 7;
            this.btnAfficher.Text = "Afficher la liste de vente";
            this.btnAfficher.UseVisualStyleBackColor = true;
            this.btnAfficher.Click += new System.EventHandler(this.btnAfficher_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(92, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Les produits du stock : ";
            // 
            // ComptePharmacien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1058, 450);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnAfficher);
            this.Controls.Add(this.btnAjouter);
            this.Controls.Add(this.btnRecherche);
            this.Controls.Add(this.txtQte);
            this.Controls.Add(this.txtNP);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvStock);
            this.Name = "ComptePharmacien";
            this.Text = "Votre compte";
            this.Load += new System.EventHandler(this.ComptePharmacien_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStock)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvStock;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNP;
        private System.Windows.Forms.TextBox txtQte;
        private System.Windows.Forms.Button btnRecherche;
        private System.Windows.Forms.Button btnAjouter;
        private System.Windows.Forms.Button btnAfficher;
        private System.Windows.Forms.Label label3;
    }
}